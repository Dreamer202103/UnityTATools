using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.IO;

namespace FirstEditionTools
{
    public class PreviousFunction
    {
        public static string GenerateUnityPackageName()
        {
            return "Tools" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
        }

        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }

        //MenuItem的复用
        public static void CallMenuItem(string menuPath)
        {
            EditorApplication.ExecuteMenuItem(menuPath);
        }

        public static void OpenInFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }

        //导出方法运用过了UnityEditor下的Api
#if UNITY_EDITOR
        public static void ExportPackage(string assetPathName,string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
        }
#endif

#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/8.总结之前的方法", false, 8)]
      

        [MenuItem("Tools/FirstEdition/8.总结之前的方法/1.获取文件名", false, 8)]
        private static void MenuClicked()
        {
            Debug.Log(GenerateUnityPackageName());
        }

        [MenuItem("Tools/FirstEdition/8.总结之前的方法/2.复制文本到剪切板", false, 9)]
        private static void MenuClicked02()
        {
           // var text = GenerateUnityPackageName();
            CopyText("复制的文本");
        }

        [MenuItem("Tools/FirstEdition/8.总结之前的方法/3.生成文件名到剪切板", false, 10)]
        private static void MenuClicked03()
        {
            var text = GenerateUnityPackageName();
            CopyText(text);
        }

        [MenuItem("Tools/FirstEdition/8.总结之前的方法/4.导出UnityPackage", false, 11)]
        private static void MenuClicked04()
        {
            ExportPackage("Assets/Tools",GenerateUnityPackageName() + ".unitypackage");
        }

        [MenuItem("Tools/FirstEdition/8.总结之前的方法/5.打开所在文件夹", false, 12)]
        private static void MenuClicked05()
        {
            OpenInFolder(Application.dataPath);
        }
        [MenuItem("Tools/FirstEdition/8.总结之前的方法/6.MenuItem 复用", false, 13)]
        private static void MenuClicked06()
        {
            CallMenuItem("Tools/FirstEdition/8.总结之前的方法/4.导出UnityPackage");
            OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }
#endif
    }
}
