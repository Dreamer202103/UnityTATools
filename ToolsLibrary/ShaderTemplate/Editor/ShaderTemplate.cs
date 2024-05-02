using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ShaderTemplate 
{
    //CONTEXT后面 接一个物体的组件
    [MenuItem("Assets/Create/Shader/Unlit URP Shader")]
    //下面的方法必须是静态方法
    public static void Init()
    {
        //Debug.LogError(AssetDatabase.AssetPathToGUID("Assets/ToolsLibrary/ShaderTemplate/Model/URPLit.shader"));
        //获取当前被激活的对象
        var guid = Selection.assetGUIDs[0];
        string foldPath = AssetDatabase.GUIDToAssetPath(guid);
        string shaderGUID = "ef42e10cfba4448f58843ce5aec5ca2d";
        if (!AssetDatabase.IsValidFolder(foldPath))
        {
            foldPath = Path.GetDirectoryName(foldPath);
        }

        //string s = AssetDatabase.GetAssetPath(o);
        string path = AssetDatabase.GUIDToAssetPath(shaderGUID);

        string newPath = foldPath + "/" + "Unlit URP Shader.shader";
        newPath = AssetDatabase.GenerateUniqueAssetPath(newPath);
        AssetDatabase.CopyAsset(path, newPath);
    }
}
