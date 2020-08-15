using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Level : MonoBehaviour
{
   
    [SerializeField] int breakAbleBlocks ;
   [SerializeField] SceneLoader sceneLoader;
    GameStatus status;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        status = FindObjectOfType<GameStatus>();

    }
    public void CountBreakAbleBlocks()
    {
        breakAbleBlocks++;
        

    }

    public void BlockDistroyed()
    {
        breakAbleBlocks--;
        if (breakAbleBlocks <= 0) 
        {
            sceneLoader.LoadNextScene();
           
        }

    }
}
