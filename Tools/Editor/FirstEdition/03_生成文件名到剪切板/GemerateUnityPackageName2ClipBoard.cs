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
    public class GemerateUnityPackageName2ClipBoard
    {

#if UNITY_EDITOR 
        [MenuItem("Tools/FirstEdition/3.生成文件名到剪切板",false,3)]
#endif
        private static void MenuClicked()
        {
            //GUIUtility.systemCopyBuffer 是一个Api
            GUIUtility.systemCopyBuffer = "Tools" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
        }
    }
}
