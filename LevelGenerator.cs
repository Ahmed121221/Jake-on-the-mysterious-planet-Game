using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //levelPrefabs ===> piece.postion =>>>> pieces 
    public static LevelGenerator instance;
    //one and only one Generetor instance 
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    //already prepared level pieces
    //we will randomly pick one from it 

    //make a copy of it, place it in the scene, <=====1
    // and add this copied level piece at the end of the pieces list <======2

    public Transform levelStartPoint;
    //this is the position of the every first level 

    public List<LevelPiece> pieces = new List<LevelPiece>();
    //old chunks am using it to get the postion of last chunk
    //all level pieces that are in the game at the time.




    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        GenerateInitialPieces();
    }




    public void AddPiece()
    {
        int randomIndex = Random.Range(0, levelPrefabs.Count-1);

        //Instantiating means creating a copy of the object.
        //our chunk
        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
        //unity dosen't copy the parent so
        //the instantiated object will be created on top of the hierarchy

        //we correct this by setiting the parent to the piece object
        // using the transform.SetParent function 
        piece.transform.SetParent(this.transform, false);

        //Vector3 type variable to store the "position" "X, Y, Z "
        Vector3 spawPosition = Vector3.zero;
        // position from which the level starts,
        // or the exit point of the last piece in the pieces


        //here i decide where to put my pice "the postion"
        //depand on if it's my first one or not
        if (pieces.Count == 0)
        {//if firest 
            spawPosition = levelStartPoint.position;

        }
        else
        {
            //take the last point from the last piece
            spawPosition = pieces[pieces.Count-1].exitPoint.position;
        }
        //where am gonna initiate the new chunk
        piece.transform.position = spawPosition;
        //put it in my old pices to new its postion in the next frame ond so on ....
        pieces.Add(piece);


    }//addp
    //.

    public void GenerateInitialPieces()
    {
        for (int i = 0; i < 3; i++)
        {
            AddPiece();
        }
    }


}
