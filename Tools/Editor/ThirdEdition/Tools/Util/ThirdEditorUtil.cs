using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEditor;

using UnityEngine;

namespace ThirdEditionTools
{
    //已经把这个脚本放在Editor文件夹下面，就不需要加#if UNITY_EDITOR 宏了
    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    public partial class ThirdEditorUtil : MonoBehaviour
    {

        public static void OpenInFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }

        public static void ExportPackage(string assetPathName, string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
        }
        public static void CallMenuItem(string menuPath)
        {
            EditorApplication.ExecuteMenuItem(menuPath);
        }

        [MenuItem("Tools/SecondEdition/3.MenuItem 复用", false, 3)]
        private static void MenuClicked()
        {
            CallMenuItem("Tools/SecondEdition/2.复制文本到剪切板");
        }

        internal static object ThirdPercent(int v)
        {
            throw new NotImplementedException();
        }
    }
}
