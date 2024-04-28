using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestEditorWindow : EditorWindow
{
    [MenuItem("Tools/Test")]
    public static void Open()
    {
        TestEditorWindow window = (TestEditorWindow)EditorWindow.GetWindow(typeof(TestEditorWindow),false,"Test",false);
        window.Show();        
    }

    void OnGUI()
    {
        if (GUILayout.Button("Test"))
        {
            //var obj = (Material)AssetDatabase.LoadAssetAtPath("Assets/ToolsLibrary/test.mat",typeof(Material));
            //Debug.LogError(obj.color);
            //选择一个选中的物体
            var obj = Selection.activeObject;
            //获取obj的路径
            string path = AssetDatabase.GetAssetPath(obj);
            Debug.Log(path);
            //string[] path = AssetDatabase.GetAllAssetPaths();
            //foreach(var item in path)
            //{
            //    Debug.LogError(item);
            //}
            //AssetDatabase.DeleteAssets

        }
    }
}
