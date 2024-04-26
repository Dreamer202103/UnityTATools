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
    public class CopyTextToClipBoard 
    {

#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/2.文本复制到剪切板",false,2)]
#endif
        private static void MenuClicked()
        {
            //GUIUtility.systemCopyBuffer 是一个Api
            GUIUtility.systemCopyBuffer = "复制文本";
        }
    }
}
