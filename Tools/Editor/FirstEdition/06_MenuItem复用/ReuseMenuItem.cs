using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace FirstEditionTools
{
    public class ReuseMenuItem
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/6.MennuItem�ĸ���",false,6)]
        private static void MenuClicked()
        {
            //MenuItem�ĸ���
            EditorApplication.ExecuteMenuItem("Tools/FirstEdition/4.����UnityPackage");
            //Path.Combine���API���԰��������Զ�ת��Ŀ¼
            Application.OpenURL("file:///" + Path.Combine(Application.dataPath, "../"));
        }
#endif
    }
}