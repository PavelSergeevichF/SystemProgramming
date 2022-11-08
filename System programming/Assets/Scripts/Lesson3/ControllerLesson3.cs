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
    private string _name="";

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
        if (_name.Length > 2)
            _server.StartServer();
        else
            SetText("������� ���");
    }   
    public void ShutDownServer()
    {
        _server.ShutDownServer();
    }
    public void ConnectClient()
    {
        if (_name.Length < 2)
        {
            SetText($"�� �� ����� ���");
        }
        else 
        {
            _client.Connect(_name);
        }
    }
    public void DisconnectClient()
    {
        _client.Disconnect();
    }
    public void Send()
    {
        GetText();
        Debug.Log($"Send");
    }
    public void GetText(string inputText)
    {
    }
    public void GetText()
    {
        if (_name.Length < 2)
        {
            if(_field.text.Length>2)
            {
                _name = _field.text;
                SetText($"���� ��� {_name}, ��� ����� ����� �������: �������� ���");
            }
            else
            {
                SetText($"��� ������� ��������");
            }
        }
        if(_field.text== "�������� ���")
        {
            _name = "";
            SetText("������� ���");
        }
        _field.text = "";
    }
    public void SetText(string inputText)
    {
        _text.text = inputText;
    }
}
