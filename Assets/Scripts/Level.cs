using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //serialize for debbuging

    SceneLoader sceneloader;

    public void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    //count every block that had been called
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void BlockBreaked()
    {
        breakableBlocks--;
        if(breakableBlocks<=0)
        {
            sceneloader.LoadNextScene();
        }

    }
}
