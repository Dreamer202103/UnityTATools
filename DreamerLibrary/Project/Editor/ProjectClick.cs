using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ProjectClick
{
    [MenuItem("Assets/Test",false,0)]
    static void Test()
    {
        Debug.LogError("Project Test");
    }
}
