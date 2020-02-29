using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    /// <summary>
    /// Mode of Level
    /// </summary>
    [Header("Level")]
    public int Level;
    /// <summary>
    /// number of Row
    /// </summary>
    [Header("Number Of Row:")]
    public int Row;
    /// <summary>
    /// number of Row
    /// </summary>
    [Header("Number Of Column:")]
    public int Column;

    /// <summary>
    /// Count of Step
    /// </summary>
    [Header("CountStep")]
    public int CountStep;
    // position of image blank
    public int RowBlank;
    public int ColBlank;
    /// <summary>
    /// Row of Size
    /// </summary>
    [Header("Row of Size")]
    public int SizeRow;

    /// <summary>
    /// Column of Size
    /// </summary>
    [Header("Column of Size")]
    public int SizeCol;
    
    /// <summary>
    /// List of Image Key and run from 0 --->List.count
    /// </summary>
    [Header("List of ImageKey ")]
    public List<GameObject> ImageKeyList;

    /// <summary>
    /// List 0f ImageOfPoints
    /// </summary>
    [Header("List 0f ImageOfPicture")]
    public List<GameObject> ImageOfPointsList;

  
    public bool StartControl = false;
    public bool CheckComplete;
    public bool GameIsComplete;
    /// <summary>
    /// List of CheckPoints
    /// </summary>
    [Header("List of CheckPoints")]
    public List<GameObject> CheckPointsList;

    
    GameObject temp;
    GameObject[,] imageKeyMatrix;
    GameObject[,] imagePointsMatrix;
    GameObject[,] checkPointsMatrix;

    

    // for count checkpoint
    int countPoint = 0;
    // for count imagekey
    int countImageKey = 0;
    // for Count Complete
    int countComplete = 0;
    // Use this for initialization
    void Start () {
        
        //imagekeymatrix new gameobject call and parameter sizeRow and sizecol and position of imagekey
        imageKeyMatrix = new GameObject[SizeRow,SizeCol];
        //imagePointsMatrix new gameobject call and parameter sizeRow and sizecol and position of imagepont
        imagePointsMatrix = new GameObject[SizeRow, SizeCol];
        //checkPointsMatrix new gameobject call and parameter sizeRow and sizecol and position of checkpoint
        checkPointsMatrix = new GameObject[SizeRow, SizeCol];

     
        // check if level is 1 
        if (Level==1)
        {
         
                //if level is 1 then EasyLevel is called
                ImageofEasyLevel();
                Debug.Log("Easy Level");

            
           
        }
        else if(Level==2)
        {
            //if level is 2 then NormalLevel is called
            ImageofNormalLevel();
            Debug.Log("Normal Level");
        }
        else if(Level==3)
       {
            //if level is 3 then HardLevel is called
            ImageofHardLevel();
            Debug.Log("Hard Level");
        }

        CheckPointManager();
        ImageKeyManager();

        // run for row
        for (int r = 0; r < SizeRow; r++)
        {
            //run for column
            for (int c = 0; c < SizeCol; c++)
            {
                //check if the position touch is  not image blank.
                if(imagePointsMatrix[r, c].name.CompareTo("blank")== 0)
                {
                    Debug.Log("Ok");
                    RowBlank = r;
                    ColBlank = c;
                    
                    break;
                   
                }
                
            }
        }


    }
	

    void CheckPointManager()
    {
        // run for row
        for (int r = 0; r < SizeRow; r++)
        {
            //run for column
            for (int c = 0; c < SizeCol; c++)
            {
                //array of checkPointsMatrix is equal to CheckPointsList and Add checkpoint to arraycheckpoint
                checkPointsMatrix[r, c] = CheckPointsList[countPoint];
                countPoint++;
            }
        }
    }

    void ImageKeyManager()
    {
        // run for row
        for (int r = 0; r < SizeRow; r++)
        {
            //run for column
            for (int c = 0; c < SizeCol; c++)
            {
                //array of imageKeyMatrix is equal to ImageKeyList and Add imageKey to arrayimageKey
                imageKeyMatrix[r, c] = ImageKeyList[countImageKey];
                countImageKey++;
            }
        }
    }
	// Update is called once per frame
	void Update () {

      
     
       
        // move for image of points
        if(StartControl)
        {
            StartControl = false;

            if(CountStep==1)
            {
                //check if the position touch is image not image blank and image of points is not null
                if (imagePointsMatrix[Row,Column]!= null &&imagePointsMatrix[Row, Column].name.CompareTo("blank") != 0)
                {
                    if(RowBlank!=Row && ColBlank == Column)
                    { // move 1 cell in row
                        if(Mathf.Abs(Row-RowBlank)==1)
                        {
                            // move
                            // call ImageSort
                            SortImage();
                            //reset countstep
                            CountStep = 0;

                        }
                        else
                        {
                            //reset countstep
                            CountStep = 0;
                        }
                        
                    }
                    else if(RowBlank== Row && ColBlank!= Column)
                    {// move 1 cell in Column
                        if (Mathf.Abs(Column-ColBlank) == 1)
                        {
                            // move
                            // call ImageSort
                            SortImage();
                            CountStep = 0;
                        }
                        else
                        {
                            //reset countstep
                            CountStep = 0;
                        }
                    }
                    else if(RowBlank == Row && ColBlank == Column || RowBlank != Row && ColBlank != Column)
                    {
                        //  not move
                        CountStep = 0;
                        Debug.Log("Image is move");
                    }
                }
            }
            else
            {
                // not move
                CountStep = 0;
                Debug.Log("ImageofPoints are move");
            }
          
        }
        
    }

    private void FixedUpdate()
    {
        if (CheckComplete)
        {
            CheckComplete = false;
            for (int r = 0; r < SizeRow; r++)
            {
                //run for column
                for (int c = 0; c < SizeCol; c++)
                {
                   if(imagePointsMatrix[r,c].gameObject.name.CompareTo(imagePointsMatrix[r,c].gameObject.name)==0)
                    {
                        //increase CountComplete 
                        countComplete++;
                    }
                    else
                    {
                        // out of loop
                        break;
                    }
                }
            }
            // if 9 imageofPoints == 9 imageKey(in 2 array)(checkofPointlist.Count==9)
           if(countComplete == CheckPointsList.Count)
            {
                Debug.Log("Game is complete");
                GameIsComplete = true;
                
                
            }
           else
            {
               
                countComplete = 0;
            }
        }
    }

    /// <summary>
    /// Image Sorting
    /// </summary>
    void SortImage()
    { 
        // sort the position
        // select image blank and save at temp gameobject
        temp = imagePointsMatrix[RowBlank, ColBlank];
        imagePointsMatrix[RowBlank, ColBlank] = null;

        // select image is not image blank and save it at new position
        imagePointsMatrix[RowBlank, ColBlank] = imagePointsMatrix[Row, Column];
        imagePointsMatrix[Row, Column] = null;

        imagePointsMatrix[Row, Column] = temp;

        //set the move for image and set new point for image blank and target of image
        imagePointsMatrix[RowBlank, ColBlank].GetComponent<ImageController>().Target = checkPointsMatrix[RowBlank, ColBlank];
        imagePointsMatrix[Row,Column].GetComponent<ImageController>().Target = checkPointsMatrix[Row,Column];
        // start move the image 
        imagePointsMatrix[RowBlank, ColBlank].GetComponent<ImageController>().startMove = true;
        imagePointsMatrix[Row, Column].GetComponent<ImageController>().startMove = true;

        //set row and column for blank image
        // position touch
        RowBlank = Row;
        ColBlank = Column;

    }
    /// <summary>
    /// Easy Level of Image
    /// </summary>
    void ImageofEasyLevel()
    {

        // easy level for image of point 9 picture
        imagePointsMatrix[0, 0] = ImageOfPointsList[0];
        imagePointsMatrix[0, 1] = ImageOfPointsList[2];
        imagePointsMatrix[0, 2] = ImageOfPointsList[5];
        imagePointsMatrix[1, 0] = ImageOfPointsList[4];
        imagePointsMatrix[1, 1] = ImageOfPointsList[1];
        imagePointsMatrix[1, 2] = ImageOfPointsList[7];
        imagePointsMatrix[2, 0] = ImageOfPointsList[3];
        imagePointsMatrix[2, 1] = ImageOfPointsList[6];
        //image blank
        imagePointsMatrix[2, 2] = ImageOfPointsList[8]; 
        
    }
    void ImageofNormalLevel()
    {
        // Normal Level for image of points 16 picture
        imagePointsMatrix[0, 0] = ImageOfPointsList[4];
        imagePointsMatrix[0, 1] = ImageOfPointsList[0];
        imagePointsMatrix[0, 2] = ImageOfPointsList[1];
        imagePointsMatrix[0, 3] = ImageOfPointsList[2];
        imagePointsMatrix[1, 0] = ImageOfPointsList[8];
        imagePointsMatrix[1, 1] = ImageOfPointsList[6];
        imagePointsMatrix[1, 2] = ImageOfPointsList[7];
        imagePointsMatrix[1, 3] = ImageOfPointsList[11];
        imagePointsMatrix[2, 0] = ImageOfPointsList[12];
        imagePointsMatrix[2, 1] = ImageOfPointsList[5];
        imagePointsMatrix[2, 2] = ImageOfPointsList[14];
        imagePointsMatrix[2, 3] = ImageOfPointsList[10];
        imagePointsMatrix[3, 0] = ImageOfPointsList[13];
        imagePointsMatrix[3, 1] = ImageOfPointsList[9];
        imagePointsMatrix[3, 2] = ImageOfPointsList[15];
        // image is 4 at  position 3 in list
        imagePointsMatrix[3, 3] = ImageOfPointsList[3];
      

    }
    void ImageofHardLevel()
    {
        // Hard Level for image of points 25 picture
        // row firs
        imagePointsMatrix[0, 0] = ImageOfPointsList[5];
        imagePointsMatrix[0, 1] = ImageOfPointsList[2];
        imagePointsMatrix[0, 2] = ImageOfPointsList[3];
        imagePointsMatrix[0, 3] = ImageOfPointsList[4];
        imagePointsMatrix[0, 4] = ImageOfPointsList[9];
        //row 2
        imagePointsMatrix[1, 0] = ImageOfPointsList[10];
        imagePointsMatrix[1, 1] = ImageOfPointsList[1];
        imagePointsMatrix[1, 2] = ImageOfPointsList[12];
        imagePointsMatrix[1, 3] = ImageOfPointsList[7];
        imagePointsMatrix[1, 4] = ImageOfPointsList[8];
        // row 3
        imagePointsMatrix[2, 0] = ImageOfPointsList[15];
        imagePointsMatrix[2, 1] = ImageOfPointsList[6];
        imagePointsMatrix[2, 2] = ImageOfPointsList[13];
        imagePointsMatrix[2, 3] = ImageOfPointsList[14];
        imagePointsMatrix[2, 4] = ImageOfPointsList[19];
        //row 4
        imagePointsMatrix[3, 0] = ImageOfPointsList[20];
        imagePointsMatrix[3, 1] = ImageOfPointsList[11];
        imagePointsMatrix[3, 2] = ImageOfPointsList[22];
        imagePointsMatrix[3, 3] = ImageOfPointsList[17];
        imagePointsMatrix[3, 4] = ImageOfPointsList[18];
        //row 5
        imagePointsMatrix[4, 0] = ImageOfPointsList[21];
        imagePointsMatrix[4, 1] = ImageOfPointsList[16];
        imagePointsMatrix[4, 2] = ImageOfPointsList[23];
        imagePointsMatrix[4, 3] = ImageOfPointsList[24];
        // image blank is number 1 and its at position 0 in list
        imagePointsMatrix[4, 4] = ImageOfPointsList[0]; 
       
    }
}
