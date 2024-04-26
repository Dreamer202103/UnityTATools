using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace FirstEditionTools
{
    public class CustemShortCut
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/7.自定义快捷键 %e", false, 7)]
        private static void MenuClicked()
        {
            //MenuItem的复用
            EditorApplication.ExecuteMenuItem("Tools/FirstEdition/6.MennuItem的复用");
        }
#endif
    }
}