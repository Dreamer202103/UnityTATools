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

        //�Ѿ�������ű�����Editor�ļ������棬�Ͳ���Ҫ��#if UNITY_EDITOR ����


        [MenuItem("Tools/ThirdEdition/Editor/����UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            ThirdEditorUtil.ExportPackage("Assets/Tools", GenerateUnityPackageName() + "unitypackage");
            //MenuItem�ĸ���
            //EditorApplication.ExecuteMenuItem("Tools/FirstEdition/6.MennuItem�ĸ���");
            ThirdEditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }

    }
}