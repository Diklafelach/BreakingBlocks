using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EditGame : MonoBehaviour
{

    Text heading;
    SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        //finding in the canvas the Heading which is the text
        heading = GameObject.Find("Heading").GetComponent<Text>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        //heading = Canvas.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.sceneCountInBuildSettings== sceneLoader.CountScenes()+1)
        {
            heading.text = "You Are The Winning";
        }
        else
            heading.text = "You Lost, Game Over";
    }
}
