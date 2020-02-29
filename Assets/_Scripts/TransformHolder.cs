using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHolder : MonoBehaviour {
    [SerializeField]
    public Transform[] TransformPlace;

    [SerializeField]
    public Transform[] ImagesObject;
    
    private bool[] TransformArray = new bool[8];
    private bool[] ImageArray = new bool[8];

    // Use this for initialization
    void Start()
    {

        TransformArray[0] = false;
        TransformArray[1] = false;
        TransformArray[2] = false;
        TransformArray[3] = false;
        TransformArray[4] = false;
        TransformArray[5] = false;
        TransformArray[6] = false;
        TransformArray[7] = false;
        

        ImageArray[0] = false;
        ImageArray[1] = false;
        ImageArray[2] = false;
        ImageArray[3] = false;
        ImageArray[4] = false;
        ImageArray[5] = false;
        ImageArray[6] = false;
        ImageArray[7] = false;
       





        for (int i = 0; i <= 7; i++)
        {



            var RandomPos = Random.Range(0,8);
           
            if (TransformArray[RandomPos]==false)
            {
                var Imagepos = ImagesObject[Random.Range(0,8)];
               TransformArray[RandomPos] = true;
                Debug.Log("Image Array Call");
                Instantiate(ImagesObject[RandomPos], Imagepos.transform.position, Quaternion.identity);
            }



            TransformArray[RandomPos] = false;
            Debug.Log("Image not call");


        }
       

    }
	// Update is called once per frame
	void Update () {
        
    }
    //void SpwanObject()
    //{
    //    if (ImageArray[i] == false)
    //    {

    //        var RandomPos = Random.Range(0, 9);
    //        var Imagepos = ImagesObject[Random.Range(0, 9)];

    //        Instantiate(ImagesObject[RandomPos], Imagepos.transform.position, Quaternion.identity);
    //        ImageArray[i] = true;
    //    }
  //  }
    
}
