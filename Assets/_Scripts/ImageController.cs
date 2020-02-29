using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour {

    /// <summary>
    /// Target of Gameobject
    /// </summary>
    public GameObject Target;
    /// <summary>
    /// start of moving
    /// </summary>
    public bool startMove;

    GameController gameController;

	// Use this for initialization
	void Start () {
        // GameController reference scripts
        GameObject gameManager = GameObject.Find("GameController");
        gameController = gameManager.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (startMove)
        {
            startMove = false;
            // move to new position
            this.transform.position = Target.transform.position;
            // checkComplete is true
            gameController.CheckComplete = true;
        }
    }
}
