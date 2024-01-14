using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectHiddenEditorWindow : EditorWindow
{
    #region[��ʼ��]
    [MenuItem("Tools/ProjectHidden")]
    //MenuItem�ж����þ�̬�����η���
    static void ShowWindow()
    {
        var window = GetWindow<ProjectHiddenEditorWindow>();
        window.titleContent = new GUIContent("ProjectHidden");
        window.minSize = new Vector2(300, 500);
        window.Show();
    }
    #endregion
}
