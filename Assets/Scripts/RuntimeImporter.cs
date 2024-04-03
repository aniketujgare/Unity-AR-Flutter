using GLTFast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeImporter : MonoBehaviour
{
    public GltfAsset Root;
    public InputField UrlField;
    public void ImportScene()
    => Root.Load(UrlField.text);
}
