using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


    public void SceneLoad(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Debug.Log("sceneName to load: " + scenename);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
