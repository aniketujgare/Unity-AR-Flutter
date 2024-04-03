using GLTFast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ModelLoader : MonoBehaviour
{
    public GameObject loadedGameObject;
    public GameObject parentObject;
    public PlaceOnPlane pl;
    bool a = true;
    //private void Awake()
    //{

    //    Debug.Log(parentObject.name);
    //    parentObject = GameObject.Find("ModelLoader");
    //    if (parentObject == null)
    //    {
    //        Debug.LogError("Parent object 'ModelLoader' not found!");
    //    }
    //    Debug.Log(parentObject.name);
    //}
    private void Start()
    {
       
    }
    void Update()
    {
        if (a)
        {
            if (parentObject.transform.childCount > 0)
            {
                Transform childTransform = parentObject.transform.GetChild(0);

                if (childTransform != null)
                {
                    loadedGameObject = childTransform.gameObject;
                    a = false;
                    assign();
                    print("lol");
                }
                else
                {
                    Debug.LogError("Child transform is null!");
                }
            }
            else
            {
                Debug.LogError("No child objects found under parentObject!");
            }
        }
    }

    public void assign()
    {
        pl.placedPrefab = loadedGameObject;
    }
    private GameObject LoadGameObjectFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            // Load the GameObject from the specified file path
            Object loadedObject = Resources.Load(filePath);

            if (loadedObject != null)
            {
                return loadedObject as GameObject;
            }
        }

        return null;
    }
}
