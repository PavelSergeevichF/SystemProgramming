using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerLesson3
{
    private Text _text;
    private InputField _field;
    private Server _server;
    private Client _client;

    public ControllerLesson3(Text text, InputField field)
    {
        _text = text;
        _field = field;
        _server = new Server();
        _client = new Client();
    }
    public void Update()
    {
        _server.Update();
        _client.Update();
    }

    public void StartServer()
    {
        _server.StartServer();
    }   
    public void ShutDownServer()
    {
        _server.ShutDownServer();
    }
    public void ConnectClient()
    {
        _client.Connect();
    }
    public void DisconnectClient()
    {
        _client.Disconnect();
    }
    public void Send()
    {
        Debug.Log($"Send");
    }
}
