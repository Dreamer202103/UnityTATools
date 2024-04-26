using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ThirdEditionTools
{
    
    public class CommonUtilExample
    {
#if UNITY_EDITOR
        [MenuItem("Tools/ThirdEdition/Example/1.复制文本到剪切板", false, 1)]
#endif
        private static void MenuClicked202()
        {
            // var text = GenerateUnityPackageName();
            CommonUtil.ThirdCopyText("复制的文本");
        }
    }
}

