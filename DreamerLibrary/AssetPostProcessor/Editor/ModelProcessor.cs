using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ModelProcessor : AssetPostprocessor
{
    /*
    #region[API��ѧϰ]
    //����һ����Դ���ߵ���һ����Դ��������ͻ�ִ�У�OnPreprocessAsset()��
    //���κ����͵���Դ������ʱִ�У�OnPreprocessAsset()��
    void OnPreprocessAsset()
    {
        Debug.LogError("OnPreprocessAsset");
    }
    //������ģ��ʱִ��(OnPreprocessModel())
    void OnPreprocessModel()
    {
        Debug.LogError("OnPreprocessModel");
    }
    #endregion
    */
    void OnPostprocessModel(GameObject g)
    {
        //ModelImporter��һ����̳�AssetImporter
        //unity����Դ������
        //assetImporter��һ������
        //as ModelImporter
        //ModelImporter modelImporter = assetImporter as ModelImporter;
        //��assetImporterǿ��ת��ModelImporter����
        ModelImporter importer = (ModelImporter)assetImporter;
        importer.isReadable = false;
    }
}
