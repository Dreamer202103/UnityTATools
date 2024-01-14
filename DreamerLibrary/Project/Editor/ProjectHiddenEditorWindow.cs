using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectHiddenEditorWindow : EditorWindow
{
    #region[数据成员]
    //一个字符串的数组
    private string[] assetSubPath;
    private bool[] isAssetSubToggle;
    #endregion

    #region[初始化]
    [MenuItem("Tools/ProjectHidden")]
    //MenuItem中都得用静态来修饰方法
    static void ShowWindow()
    {
        var window = GetWindow<ProjectHiddenEditorWindow>();
        window.titleContent = new GUIContent("ProjectHidden");
        window.minSize = new Vector2(150, 250);
        window.Show();
    }

    //这个方法只执行一次
    //窗口打开的时候执行一次
    void OnEnable()
    {
        assetSubPath = AssetDatabase.GetSubFolders("Assets");
        isAssetSubToggle = new bool[assetSubPath.Length];
        /*foreach循环
        foreach (var item in assetSubPath)
        {
            Debug.LogError(item);
        }
        */
        for (int i = 0; i < assetSubPath.Length; i++)
        {
            //isAssetSubToggle[i] = EditorGUILayout.ToggleLeft(assetSubPath[i], isAssetSubToggle[i]);
            string key = string.Format("projectHidden_{0}", assetSubPath[i]);
            isAssetSubToggle[i] = EditorPrefs.GetBool(key, true);
        }
    }
    //窗口关闭去执行
    void OnDisable()
    {
        for (int i = 0; i < assetSubPath.Length; i++)
        {
            //isAssetSubToggle[i] = EditorGUILayout.ToggleLeft(assetSubPath[i], isAssetSubToggle[i]);
            string key = string.Format("projectHidden_{0}", assetSubPath[i]);
            EditorPrefs.SetBool(key, isAssetSubToggle[i]);
        }
    }
    #endregion

    #region[OnGUI]
    //OnGUI()中绘制界面
    //OnGUI()是每一帧都去绘制
    void OnGUI()
    {
        for (int i = 0; i < assetSubPath.Length; i++)
        {
            isAssetSubToggle[i] = EditorGUILayout.ToggleLeft(assetSubPath[i], isAssetSubToggle[i]);
            string key = string.Format("projectHidden_{0}", assetSubPath[i]);
            EditorPrefs.SetBool(key, isAssetSubToggle[i]);
        }
        
    }
    #endregion
}
