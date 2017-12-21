using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class play : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("lobby", LoadSceneMode.Single);
    }
}