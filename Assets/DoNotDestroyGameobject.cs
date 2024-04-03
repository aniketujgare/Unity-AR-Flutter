using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyGameobject : MonoBehaviour
{
    public static DoNotDestroyGameobject instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
