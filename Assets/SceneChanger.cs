using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public void LoadARScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Load3DViewerScene()
    {
        Debug.Log("pressed button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
