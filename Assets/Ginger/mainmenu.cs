using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour
{

    public InputField ipField;
    public InputField portField;

    public Button hostbutton;
    public Button clientbutton;

	void Start ()
    {
        ipField.onEndEdit.AddListener(UpdateIP);
        portField.onEndEdit.AddListener(UpdatePort);
        hostbutton.onClick.AddListener(HostButton);
        clientbutton.onClick.AddListener(ClientButton);
	}
	
	
	void UpdateIP (string newIP)
    {
        NetworkManager.singleton.networkAddress = newIP;
	}

    void UpdatePort(string port)
    {
        NetworkManager.singleton.networkPort = Int32.Parse(port);
    }

    void HostButton()
    {
        NetworkManager.singleton.StartHost();
    }

    void ClientButton()
    {
        NetworkManager.singleton.StartClient();
    }
}
