using UnityEngine;
using UnityEngine.UI;

public class VieweHP : MonoBehaviour
{
    private ControllerHP _controllerHP;
    public Text Text;
    public Image Image;
    public Button Button;
    public Slider Slider;

    void Start()
    {
        _controllerHP = new ControllerHP(Text, Image, Slider);
    }

    // Update is called once per frame
    void Update()
    {
        _controllerHP.ControllerUpdate();
    }
    public void AddHP()
    {
        if(_controllerHP.CheckWork()==0)
        StartCoroutine(_controllerHP.RecieveHealing(0.5f));
    }

    public void ButtonTasck2()
    {
        _controllerHP.StartTasks2Async();
    }
}
