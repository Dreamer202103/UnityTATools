using System;
using System.IO;

using UnityEditor;

using UnityEngine;

namespace ThirdEditionTools
{
    public class ThirdExporter
    {
        public static string GenerateUnityPackageName()
        {
            return "Tools" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
        }

        //已经把这个脚本放在Editor文件夹下面，就不需要加#if UNITY_EDITOR 宏了


        [MenuItem("Tools/ThirdEdition/Editor/导出UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            ThirdEditorUtil.ExportPackage("Assets/Tools", GenerateUnityPackageName() + "unitypackage");
            //MenuItem的复用
            //EditorApplication.ExecuteMenuItem("Tools/FirstEdition/6.MennuItem的复用");
            ThirdEditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }

    }
}