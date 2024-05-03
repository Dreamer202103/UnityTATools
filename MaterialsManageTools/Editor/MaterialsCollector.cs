using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer;
using System.IO;
using System;
using Unity.Burst.Intrinsics;

public class MaterialsCollector : EditorWindow
{
    [MenuItem("Tools/Materials Collector")]
    public static void ShowWindow()
    {
        //显示窗口
        EditorWindow.GetWindow(typeof(MaterialsCollector));
    }


   List<Material> materialsL = new List<Material>();
    // private List<string> materialsR = new List<string>();
    List<string> materialNameList = new List<string>();
    // 存储文件名的列表  
    private List<string> fileNames = new List<string>();


    public void OnGUI()
    {
        if (GUILayout.Button("Materals Collection"))
        {

            // 注意：这里使用Application.persistentDataPath作为示例，因为直接访问Assets文件夹可能受限
            //string fullPath = Path.Combine(Application.persistentDataPath, "Materials"); 
            string fullPath = "F:\\GitProject\\UnityTATools\\Assets\\Art\\Materials";
             // 获取该文件夹下的所有文件  
            string[] files = Directory.GetFiles(fullPath);
           // 将文件名（不包含路径）添加到列表中  
           foreach (string file in files)
           {

                // 使用Path.GetFileName获取文件名（不包括路径）  
                //string fileName = Path.GetFileName(file);
                // 使用Path.GetFileNameWithoutExtension获取文件名（不包括路径和扩展名）
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
                // 如果你想要过滤掉 .mat 文件，可以在获取文件名后进行检查  
                if (!fileNameWithoutExt.EndsWith(".mat", StringComparison.OrdinalIgnoreCase))
                {
                    // 这不是一个 .mat 文件，可以进行其他操作  
                    //Console.WriteLine("这不是一个 .mat 文件");
                }
                else
                {
                    // 这是一个 .mat 文件，你可能想要忽略它或者进行特殊处理  
                    //Console.WriteLine("这是一个 .mat 文件");
                    fileNames.Add(fileNameWithoutExt);
                    //Debug.Log("1" + fileNameWithoutExt);
                }

                
               
           }


           Renderer[] renderers = Selection.activeGameObject.GetComponentsInChildren<Renderer>();
           foreach (Renderer renderer in renderers)
           {
                Material[] materials = renderer.sharedMaterials;
                foreach (Material material in materials)
                {
                  

                    foreach(Material mat in materialsL)
                    {
                        if(mat.name == material.name)
                        {
                            continue;
                            Debug.Log("2" + materialsL.Count);
                        }
                        else
                        {
                            materialsL.Add(mat);
                            materialNameList.Add(mat.name);
                        }
                    }

                    //materialNameList.Add(material.name);
                    //if (!ContainsMaterial(material))
                   //{
                        //materialNameList = materialsL.Select(material => material.name).ToList();
                        //materialsL.Add(material);
                        //materialNameList.Add(material.name);
                        // materialsR.Add(material.name);
                        //Debug.Log("2" + materialsL.Count);
                   //}
                    
                }
           }

           
           
        
        }
        
    }
    private bool ContainsMaterial(Material material)
    {
        foreach (Material mat in materialsL)
        {
            if (mat.name == material.name) // 检查材质名称是否相同  
            {
                return true; // 如果找到相同的材质名称，则返回true  
            }
        }
        return false; // 如果没有找到，则返回false  
    }

}
