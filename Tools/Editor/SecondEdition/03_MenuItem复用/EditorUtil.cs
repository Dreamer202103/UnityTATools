using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace SecondEditionTools
{
    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
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

        [MenuItem("Tools/SecondEdition/3.MenuItem ����", false, 3)]
        private static void MenuClicked()
        {
            CallMenuItem("Tools/SecondEdition/2.�����ı������а�");
        }


#endif
    }
}
