
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ScenesChange : Editor
{
    //Unity编译完成就去调用这个方法
    [InitializeOnLoadMethod]
    static void InitSwitcher()
    {
        SceneView.duringSceneGui += (SceneView scene) => 
        {
            Handles.BeginGUI();
            {
                EditorGUILayout.LabelField("Scenes切换：");
                if (GUILayout.Button("SampleScene", GUILayout.Width(100)))
                {
                    //var SampleScene = AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/SampleScene.unity");
                    //SceneManager.LoadScene("SampleScene");
                    //GraphicsSettings.defaultRenderPipeline = pipline;
                    EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity");

                }
                if (GUILayout.Button("Scenes", GUILayout.Width(100)))
                {
                    //var Scenes = AssetDatabase.LoadAssetAtPath<RenderPipelineAsset>("Assets/Scenes/Scenes.unity");
                    //GraphicsSettings.defaultRenderPipeline = pipline;
                    //SceneManager.LoadScene("Scenes");
                    //AssetDatabase.OpenAsset(Scenes);
                    EditorSceneManager.OpenScene("Assets/Scenes/Scenes.unity");
                }
            }
            Handles.EndGUI();
        };

    }
}
