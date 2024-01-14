using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectHiddenEditorWindow : EditorWindow
{
    #region[初始化]
    [MenuItem("Tools/ProjectHidden")]
    //MenuItem中都得用静态来修饰方法
    static void ShowWindow()
    {
        var window = GetWindow<ProjectHiddenEditorWindow>();
        window.titleContent = new GUIContent("ProjectHidden");
        window.minSize = new Vector2(300, 500);
        window.Show();
    }
    #endregion
}
