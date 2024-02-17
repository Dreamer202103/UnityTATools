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
        //层级结构
        importer.preserveHierarchy = false;
        //模型压缩,只是压缩包体大小，不能优化内存
        importer.meshCompression = ModelImporterMeshCompression.Low;
        //模型可读写，意思是模型在运行是否可以使用脚本进行读写。
        //打开会消耗内存
        importer.isReadable = false;
        //
        importer.keepQuads = false;
        //
        importer.weldVertices = false;
        //索引格式，当顶点数超过2的16次方的时候。再申请
        importer.indexFormat = ModelImporterIndexFormat.Auto;
        //模型法线的导入设置
        importer.importNormals = ModelImporterNormals.Import;
        //法线的导入
        importer.importTangents = ModelImporterTangents.Import;


    }
}
