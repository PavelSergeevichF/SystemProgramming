using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VieweLesson2 : MonoBehaviour
{
    private ControllerLesson2 _controllerLesson2;
    public List<Text> Texts;
    [SerializeField] private int _count;

    void Start()
    {
        _controllerLesson2 = new ControllerLesson2(this, _count);
    }
    public void ButtonTasck1()
    {
        _controllerLesson2.Tasck1();
    }
    public void ButtonTasck2()
    {
        _controllerLesson2.Tasck2();
    }
}
