using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialsManageTools : EditorWindow
{
    [MenuItem("Tools/MaterialsManageTools",false,0)]
    static void ShowMaterialsManageTools()
    {
        //��ʾ����
        EditorWindow.GetWindow(typeof(MaterialsManageTools));
    }
    //���ƴ���
    public void OnGUI()
    {
        if(GUILayout.Button("Materials Manage Tools"))
        {
            //ѡ�е�ǰ����
            GameObject selectGameObject = Selection.activeGameObject;
            if (selectGameObject != null)
            {
                //����ѡ������������������Renderer���
                Renderer[] render = selectGameObject.GetComponentsInChildren<Renderer>();
                //��ȡrender������
                //Debug.Log(render.GetType());
                //for(int i = 0;i < render.Length;i++)
                //{
                //Debug.Log(render[i].name);
                //}
                foreach (var item in render)
                {
                    Debug.Log(item.sharedMaterial.name);
                }
            }

        }
    }
}
