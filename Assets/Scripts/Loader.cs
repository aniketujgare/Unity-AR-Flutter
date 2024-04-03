using GLTFast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class Loader : MonoBehaviour
{
    public GltfAsset gl;

    private void Start()
    {
        gl.Url = "https://d3ag5oij4wsyi3.cloudfront.net/classroom_app/models/4.glb";
    }
}
