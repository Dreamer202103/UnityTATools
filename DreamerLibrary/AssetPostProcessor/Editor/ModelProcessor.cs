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
    //������ģ��ʱִ��(OnPostprocessModel())
    void OnPostprocessModel()
    {
        Debug.LogError("OnPostprocessModel()");
    }
}
