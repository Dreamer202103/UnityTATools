using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace FirstEditionTools
{
    public class ReuseMenuItem
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/6.MennuItem的复用",false,6)]
        private static void MenuClicked()
        {
            //MenuItem的复用
            EditorApplication.ExecuteMenuItem("Tools/FirstEdition/4.导出UnityPackage");
            //Path.Combine这个API可以帮助我们自动转换目录
            Application.OpenURL("file:///" + Path.Combine(Application.dataPath, "../"));
        }
#endif
    }
}