using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepBystepController : MonoBehaviour {

    /// <summary>
    /// Row of Size
    /// </summary>
    [Header("Number of Row ")]
    public int Row;

    /// <summary>
    /// Column of Size
    /// </summary>
    [Header("Number of Column")]
    public int Column;

    GameController gameController;

    // Use this for initialization
    void Start () {

        // GameController reference scripts
        GameObject gameManager = GameObject.Find("GameController");
        gameController = gameManager.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("Row is" + Row + "Column is" + Column);
        // increase CountStep
        gameController.CountStep++;
        // gameController's row is row
        gameController.Row = Row;
        // gameController's column is column
        gameController.Column = Column;
        // startControl is true
        gameController.StartControl = true;
    }
}
