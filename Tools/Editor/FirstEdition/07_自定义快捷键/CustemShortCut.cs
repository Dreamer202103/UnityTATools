using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace FirstEditionTools
{
    public class CustemShortCut
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/7.�Զ����ݼ� %e", false, 7)]
        private static void MenuClicked()
        {
            //MenuItem�ĸ���
            EditorApplication.ExecuteMenuItem("Tools/FirstEdition/6.MennuItem�ĸ���");
        }
#endif
    }
}