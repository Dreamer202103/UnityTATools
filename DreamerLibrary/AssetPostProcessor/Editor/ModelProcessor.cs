using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ModelProcessor : AssetPostprocessor
{
    /*
    #region[API的学习]
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
    #endregion
    */
    void OnPostprocessModel(GameObject g)
    {
        //ModelImporter是一个类继承AssetImporter
        //unity的资源导入器
        //assetImporter是一个属性
        //as ModelImporter
        //ModelImporter modelImporter = assetImporter as ModelImporter;
        //将assetImporter强制转换ModelImporter类型
        ModelImporter importer = (ModelImporter)assetImporter;
        importer.isReadable = false;
    }
}
