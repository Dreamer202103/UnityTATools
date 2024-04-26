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

        //MenuItem�ĸ���
        public static void CallMenuItem(string menuPath)
        {
            EditorApplication.ExecuteMenuItem(menuPath);
        }

        public static void OpenInFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }

        //�����������ù���UnityEditor�µ�Api
#if UNITY_EDITOR
        public static void ExportPackage(string assetPathName,string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
        }
#endif

#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/8.�ܽ�֮ǰ�ķ���", false, 8)]
      

        [MenuItem("Tools/FirstEdition/8.�ܽ�֮ǰ�ķ���/1.��ȡ�ļ���", false, 8)]
        private static void MenuClicked()
        {
            Debug.Log(GenerateUnityPackageName());
        }

        [MenuItem("Tools/FirstEdition/8.�ܽ�֮ǰ�ķ���/2.�����ı������а�", false, 9)]
        private static void MenuClicked02()
        {
           // var text = GenerateUnityPackageName();
            CopyText("���Ƶ��ı�");
        }

        [MenuItem("Tools/FirstEdition/8.�ܽ�֮ǰ�ķ���/3.�����ļ��������а�", false, 10)]
        private static void MenuClicked03()
        {
            var text = GenerateUnityPackageName();
            CopyText(text);
        }

        [MenuItem("Tools/FirstEdition/8.�ܽ�֮ǰ�ķ���/4.����UnityPackage", false, 11)]
        private static void MenuClicked04()
        {
            ExportPackage("Assets/Tools",GenerateUnityPackageName() + ".unitypackage");
        }

        [MenuItem("Tools/FirstEdition/8.�ܽ�֮ǰ�ķ���/5.�������ļ���", false, 12)]
        private static void MenuClicked05()
        {
            OpenInFolder(Application.dataPath);
        }
        [MenuItem("Tools/FirstEdition/8.�ܽ�֮ǰ�ķ���/6.MenuItem ����", false, 13)]
        private static void MenuClicked06()
        {
            CallMenuItem("Tools/FirstEdition/8.�ܽ�֮ǰ�ķ���/4.����UnityPackage");
            OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }
#endif
    }
}
