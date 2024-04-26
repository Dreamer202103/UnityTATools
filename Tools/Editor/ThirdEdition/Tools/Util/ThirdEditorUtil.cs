using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEditor;

using UnityEngine;

namespace ThirdEditionTools
{
    //�Ѿ�������ű�����Editor�ļ������棬�Ͳ���Ҫ��#if UNITY_EDITOR ����
    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
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

        [MenuItem("Tools/SecondEdition/3.MenuItem ����", false, 3)]
        private static void MenuClicked()
        {
            CallMenuItem("Tools/SecondEdition/2.�����ı������а�");
        }

        internal static object ThirdPercent(int v)
        {
            throw new NotImplementedException();
        }
    }
}
