using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VieweLesson3 : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] InputField _field;
    private ControllerLesson3 _controllerLesson3;


    private void Awake()
    {
        _controllerLesson3 = new ControllerLesson3(_text, _field);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() =>    _controllerLesson3.Update();

    public void StartServer() => _controllerLesson3.StartServer();
    public void ShutDownServer() => _controllerLesson3.ShutDownServer();
    public void ConnectClient() => _controllerLesson3.ConnectClient();
    public void DisconnectClient() => _controllerLesson3.DisconnectClient();
    public void Send() => _controllerLesson3.Send();

}
