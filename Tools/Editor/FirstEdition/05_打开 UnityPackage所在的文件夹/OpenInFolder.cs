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
    public class OpenInFolder
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/5.��UnityPackage���ڵ��ļ���",false,5)]

        private static void MenuClicked()
        {
            //Application.OpenURL�д���Ĳ����������ַ����ô�򿪵ľ�����ַ�����������ǡ�file:///����ͷ��·������򿪵������Ŀ¼
            Application.OpenURL("file:///" + Application.dataPath);
        }
#endif
    }
}
