using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ModelProcessor : AssetPostprocessor
{
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
    void OnPostprocessModel(GameObject g)
    {
        //ModelImporter��һ����̳�AssetImporter
        //unity����Դ������
        //assetImporter��һ������
        //as ModelImporter
        //ModelImporter modelImporter = assetImporter as ModelImporter;
        //ǿ��ת��
        ModelImporter importer = (ModelImporter)assetImporter;
        Debug.LogError(importer.isReadable);
    }
}
