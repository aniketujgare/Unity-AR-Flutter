using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Modelmetadata", menuName = "MyCustomObjects/Modelmetadata")]
public class Modelmetadata : ScriptableObject
{
    public string objectName;
    public int objectID;
    // Add other fields as needed
}