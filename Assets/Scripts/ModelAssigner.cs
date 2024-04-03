using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ModelAssigner : MonoBehaviour
{
    public GameObject Model, currentModel;
    string foldername, filename;
    public bool isAR, isPencil, isColorWheel, isDraw, ModelDownloading, isEraser, isHide, isTextBox, isModels, Test;
    float ModelPerc;
    public TMP_Text ObjectName;
    public ProgressBar progressBar;
    [SerializeField] PlaceOnPlane pl;
    
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "0-AR-MainScene")
        {
            if (!Application.isEditor)
            {
                foldername = PlayerPrefs.GetString("foldername");
                filename = PlayerPrefs.GetString("filename");
                SetModel();
            }
            else
            {
                foldername = "animals";
                filename = "132";
                SetModel();
                //GetComponent<GetRealtedObjects>().enabled = true;
            }
        }

    }

    public void SetFolderName(string category)
    {
        foldername = category;
    }

    public void SetFileName(string file)
    {
        filename = file;
    }

    public void SetModel()
    {
        StartCoroutine(DownloadModel());
    }

    IEnumerator DownloadModel()
    {

        string URL = "https://smartxrfiles1.s3.ap-south-1.amazonaws.com/modellibrary/animals/100/100.unity3d";
        Debug.Log(URL);
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(URL);
        StartCoroutine(progressModels(URL, request));
        ModelDownloading = true;
        yield return request.SendWebRequest();
        ModelDownloading = false;
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error loading");
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            string name = bundle.GetAllAssetNames()[0];
            Model = bundle.LoadAsset(name) as GameObject;
            bundle.Unload(false);
            string trimmedString = Model.name.TrimStart('.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
            if (SceneManager.GetActiveScene().name == "Scene")
            {
                ObjectName.text = trimmedString;
            }
            currentModel=Instantiate(Model);
            
            //currentModel.layer = 7;
            // currentModel.AddComponent<ObjectAutoRotate>();
            Debug.Log("Done");
            Assignmodel();
        }
    }

    void Assignmodel()
    {
       // pl.m_PlacedPrefab = Model;
        //Debug.Log("assignedModelNmae" + pl.m_PlacedPrefab.name);
        
         
        //pl.enabled = true;

    }


    IEnumerator progressModels(String URI, UnityWebRequest request)
    {

        int bundleSize = 0;
        using (UnityWebRequest uwr = UnityWebRequest.Head(URI))
        {
            yield return uwr.SendWebRequest();
            bundleSize = Int32.Parse(uwr.GetResponseHeader("Content-Length"));
        }

       /* while (ModelDownloading)
        {
            ModelPerc = (bundleSize != 0) ? (request.downloadedBytes / (float)bundleSize) : request.downloadProgress;
            progressBar.currentPercent = ModelPerc * 100;
            yield return new WaitForEndOfFrame();

        }*/
    }
}
