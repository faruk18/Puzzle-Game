using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomanager : MonoBehaviour {

    /// <summary>
    /// Random object of array of 9 object
    /// </summary>
    public GameObject[] RandomObject = new GameObject[9];
	// Use this for initialization
	void Start ()
    {

       
    }
	
	// Update is called once per frame
	void Update () {
        SpwanObject();
    }

    void SpwanObject()
    {
        var Randomnew = Random.Range(0, 8);
        Instantiate(RandomObject[Randomnew], transform.position, Random.rotation);
    }
}
