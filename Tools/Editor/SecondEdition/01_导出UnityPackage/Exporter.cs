using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace SecondEditionTools
{
    public class Exporter
    {
        public static string GenerateUnityPackageName()
        {
            return "Tools" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
        }

#if UNITY_EDITOR
        [MenuItem("Tools/SecondEdition/1.导出UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            EditorUtil.ExportPackage("Assets/Tools", GenerateUnityPackageName() + "unitypackage");
            //MenuItem的复用
            //EditorApplication.ExecuteMenuItem("Tools/FirstEdition/6.MennuItem的复用");
            EditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }
#endif
    }
}