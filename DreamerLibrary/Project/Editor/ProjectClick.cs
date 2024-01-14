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

    //Unity编译完成就去调用这个方法
    [InitializeOnLoadMethod]
    //方法必须是静态的才能被调用
    static void InitProject()
    {
        //这个方法用了委托
        //
        EditorApplication.projectWindowItemOnGUI = (string guid, Rect selectionRect) =>
        {
            Debug.LogError(1);
        };
        
    }
}
