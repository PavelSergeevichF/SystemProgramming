using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class ControllerLesson2
{
    private VieweLesson2 _vieweLesson2;
    private NativeArray<int> _intArray;
    private NativeArray<int> _intArray2;

    private NativeArray<Vector3> _positions; 
    private NativeArray<Vector3> _velocitions;
    private NativeArray<Vector3> _finalPositions;
    private TransformAccessArray _accessArray;
    private int _count;

    public ControllerLesson2(VieweLesson2 vieweLesson2, int count)
    {
        _count = count;
        _vieweLesson2 = vieweLesson2;
        _positions = new NativeArray<Vector3>(_count, Allocator.Persistent);
        _velocitions = new NativeArray<Vector3>(_count, Allocator.Persistent);
        _finalPositions = new NativeArray<Vector3>(_count, Allocator.Persistent);
    }
    public void Tasck1()
    {
        bool check = true;
        _intArray = new NativeArray<int>(new int[] { 10, 3, 4, 8, 6, 12, 9, 8, 5}, Allocator.Persistent);
        MyJob myJob = new MyJob()
        {
            intArr = _intArray,
        };
        JobHandle jobHandle = myJob.Schedule();
        jobHandle.Complete();
        for(int i=0; i < _intArray.Length; i++)
        {
            if(_intArray[i]>0)
            {
                check=false;
            }
        }
        if (check)
        {
            _vieweLesson2.Texts[0].text = "Задача 1 выполнена";
        }
        else 
        {
            _vieweLesson2.Texts[0].text = "Задача 1 не выполнена!";
        }
    }
    private void OnDestroy()
    {
        _intArray.Dispose();
        if(_intArray2!=null)
        {
            _accessArray.Dispose();
            _positions.Dispose();
            _velocitions.Dispose();
            _finalPositions.Dispose();
        }
    }
    public void Tasck2()
    {
        Debug.Log("Tasck2");
        bool check = true;
        _intArray2 = new NativeArray<int>(new int[_count],Allocator.Persistent);
        for(int i=0; i<_count; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            Vector3 vel = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            _positions[i] = pos;
            _velocitions[i] = vel;
        }
        MyJob1 myJob1 = new MyJob1()
        {
            Positions = _positions,
            Velocitions = _velocitions,
            FinalPositions = _finalPositions
        };
        JobHandle jobHandle = myJob1.Schedule(_intArray2.Length,0);
        jobHandle.Complete();
        for (int i = 0; i < _count; i++)
        {
            Debug.Log($" _intArray2= {_intArray2[i]}, FinalPositions= {_finalPositions[i]}");
        }
    }
    public void Tasck3()
    {
        Debug.Log("Tasck3");
        
    }
}
public struct MyJob : IJob
{
    public NativeArray<int> intArr;
    public void Execute()
    {
        int temp = 0;
        do 
        {
            temp = 0;
            for (int i = 0; i < intArr.Length; i++)
            {
                if(intArr[i] >0)
                {
                    intArr[i]--;
                }
                if(intArr[i]>temp)
                {
                    temp = intArr[i];
                }
            }
        }
        while (temp > 0);
    }
}
public struct MyJob1 : IJobParallelFor
{
    public NativeArray<Vector3> Positions;
    public NativeArray<Vector3> Velocitions;
    public NativeArray<Vector3> FinalPositions;

    public void Execute(int index)
    {
        FinalPositions[index] = Positions[index] + Velocitions[index];
    }
}
