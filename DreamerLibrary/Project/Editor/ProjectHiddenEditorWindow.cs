using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectHiddenEditorWindow : EditorWindow
{
    #region[���ݳ�Ա]
    //һ���ַ���������
    private string[] assetSubPath;
    private bool[] isAssetSubToggle;
    #endregion

    #region[��ʼ��]
    [MenuItem("Tools/ProjectHidden")]
    //MenuItem�ж����þ�̬�����η���
    static void ShowWindow()
    {
        var window = GetWindow<ProjectHiddenEditorWindow>();
        window.titleContent = new GUIContent("ProjectHidden");
        window.minSize = new Vector2(150, 250);
        window.Show();
    }

    //�������ִֻ��һ��
    //���ڴ򿪵�ʱ��ִ��һ��
    void OnEnable()
    {
        assetSubPath = AssetDatabase.GetSubFolders("Assets");
        isAssetSubToggle = new bool[assetSubPath.Length];
        /*foreachѭ��
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
    //���ڹر�ȥִ��
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
    //OnGUI()�л��ƽ���
    //OnGUI()��ÿһ֡��ȥ����
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
    #region[ί��Lambda���ʽ]
    [InitializeOnLoadMethod]
    static void InitHiddenProject()
    {
        string[] _assetSubPath = AssetDatabase.GetSubFolders("Assets");
        EditorApplication.projectWindowItemOnGUI = (string guid, Rect SelectionRect) =>
        {
            
            string path = AssetDatabase.GUIDToAssetPath(guid);
            for (int i = 0; i < _assetSubPath.Length; i++)
            {
                if(path == _assetSubPath[i])
                {
                    string key = string.Format("projectHidden_{0}", _assetSubPath[i]);
                    bool _isToggle= EditorPrefs.GetBool(key);
                    if (!_isToggle)
                    {
                        
                       // EditorGUI.DrawRect(new Rect(SelectionRect.x - 50, SelectionRect.y, SelectionRect.width + 50, SelectionRect.height), new Color(0.22f, 0.22f, 0.22f, 1.0f));
                        EditorGUI.DrawRect(new Rect(SelectionRect.x - 50, SelectionRect.y, SelectionRect.width + 50, SelectionRect.height), new Color(0.22f, 0.22f, 0.22f, 0.0f));
                    }
                }
            }
        };
    }
    #endregion
}
