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

    //Unity������ɾ�ȥ�����������
    [InitializeOnLoadMethod]
    //���������Ǿ�̬�Ĳ��ܱ�����
    static void InitProject()
    {
        //�����������ί��
        //
        EditorApplication.projectWindowItemOnGUI = (string guid, Rect selectionRect) =>
        {
            Debug.LogError(1);
        };
        
    }
}
