﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Jplayer1"))
        {
            SceneManager.LoadScene("Intro");

        }else if (Input.GetButton("Start"))
        {
            SceneManager.LoadScene("Scene1");
        }
	}
}
