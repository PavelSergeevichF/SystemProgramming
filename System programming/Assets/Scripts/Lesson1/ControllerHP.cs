using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ControllerHP
{
    private DataHP _dataHP;
    private int _hp = 100;
    private int _sliderData;
    private Text _text;
    private Image _image;
    private Slider _slider;
    private float _workCoroutine = 0;
    private bool _newFrame = true;

    public ControllerHP(Text text, Image image, Slider slider)
    {
        _dataHP = new DataHP(_hp);
        _text = text;
        _image = image;
        _slider = slider;
    }
    public float CheckWork()
    { 
        return _workCoroutine;
    }
    public void ControllerUpdate()
    {
        CheckData();
        _newFrame = true;
    }
    private void CheckData()
    { 
        if(_slider.value!= _sliderData)
        {
            _sliderData = (int)_slider.value;
            if(_sliderData>=0 && _sliderData<=100)
            {
                SetVieweElement(_sliderData);
                _dataHP.HP = _sliderData;
            }
        }
    }
    private void SetVieweElement(int data)
    {
        _text.text = data.ToString();
        float temp = data;
        _image.fillAmount = temp / _dataHP.MaxHP;
    }


    #region Coroutines
    public IEnumerator RecieveHealing(float time)
    {
        while(_workCoroutine<3)
        {
            _workCoroutine += time;
            if (_dataHP.HP + _dataHP.RecieveHP > _dataHP.MaxHP)
            {
                _dataHP.HP = _dataHP.MaxHP;
            }
            else
            {
                _dataHP.HP += _dataHP.RecieveHP;
            }
            _slider.value = _dataHP.HP;
            yield return new WaitForSeconds(time);
        }
        _workCoroutine = 0;
    }
    #endregion


    #region async/await

    public async void StartTasks2Async()
    {
        Task task1 = Task.Run(() => Task1Async());
        Task task2 = Task.Run(() => Task2Async( 60));
        await Task.WhenAll(task1, task2);
    }
    private async void Task1Async()
    {
        Debug.Log("Task1 starts++.");
        await Task.Delay(1000);
        Debug.Log("Task1 finishes.===========");
    }
    private async void Task2Async(int x)
    {
        int tmp = x;
        Debug.Log("Task2 starts++.");
        while(x>0)
        {
            if(_newFrame)
            {
                _newFrame = false;
                x--;
            }
            
            await Task.Yield();
            Debug.Log($"x={x}");
        }
        x = tmp;
        Debug.Log("Task2 finishes.===========");
    }
    #endregion
}
