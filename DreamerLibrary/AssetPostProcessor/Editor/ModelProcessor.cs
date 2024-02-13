using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ModelProcessor : AssetPostprocessor
{
    //创建一个资源或者导入一个资源这个方法就会执行（OnPreprocessAsset()）
    //当任何类型的资源被导入时执行（OnPreprocessAsset()）
    void OnPreprocessAsset()
    {
        Debug.LogError("OnPreprocessAsset");
    }
    //当导入模型时执行(OnPreprocessModel())
    void OnPreprocessModel()
    {
        Debug.LogError("OnPreprocessModel");
    }
    void OnPostprocessModel(GameObject g)
    {
        Debug.LogError("OnPostprocessModel");
    }
}
