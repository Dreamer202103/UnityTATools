using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialsManageTools : EditorWindow
{
    [MenuItem("Tools/MaterialsManageTools",false,0)]
    static void ShowMaterialsManageTools()
    {
        //显示窗口
        EditorWindow.GetWindow(typeof(MaterialsManageTools));
    }
    //绘制窗口
    public void OnGUI()
    {
        if(GUILayout.Button("Materials Manage Tools"))
        {
            //选中当前物体
            GameObject selectGameObject = Selection.activeGameObject;
            if (selectGameObject != null)
            {
                //遍历选中物体的所有子物体的Renderer组件
                Renderer[] render = selectGameObject.GetComponentsInChildren<Renderer>();
                //获取render的类型
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
