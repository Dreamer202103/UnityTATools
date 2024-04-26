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
        [MenuItem("Tools/SecondEdition/1.����UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            EditorUtil.ExportPackage("Assets/Tools", GenerateUnityPackageName() + "unitypackage");
            //MenuItem�ĸ���
            //EditorApplication.ExecuteMenuItem("Tools/FirstEdition/6.MennuItem�ĸ���");
            EditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }
#endif
    }
}