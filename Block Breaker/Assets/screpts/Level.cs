using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Level : MonoBehaviour
{
   
    [SerializeField] int breakAbleBlocks ;
    // Start is called before the first frame update
   [SerializeField] SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
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
