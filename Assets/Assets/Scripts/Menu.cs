using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Menu : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        float scrH = Screen.height / 9;
        float scrW = Screen.width / 16;

        if (GUI.Button(new Rect(scrW * 6, scrH * 4, scrW * 2, scrH), "Singleplayer"))
        {
            SceneManager.LoadSceneAsync("Singleplayer");
            Instantiate(player);
        }

        if (GUI.Button(new Rect(scrW * 9, scrH * 4, scrW * 2, scrH), "Multiplayer"))
        {
            SceneManager.LoadSceneAsync("Offline");
            Instantiate(player);
        }
    }
}
