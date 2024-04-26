using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace SecondEditionTools
{
    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    public partial class EditorUtil : MonoBehaviour
    {

        public static void OpenInFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }
#if UNITY_EDITOR
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


#endif
    }
}
