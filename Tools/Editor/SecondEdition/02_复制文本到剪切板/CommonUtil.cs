using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace SecondEditionTools
{
    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    //通过partial关键字，理论上可以对已有的类，进行无限的增加实例。
    public partial class CommonUtil
    {
        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }

#if UNITY_EDITOR
        [MenuItem("Tools/SecondEdition/2.复制文本到剪切板", false, 2)]
#endif
        private static void MenuClicked202()
        {
            // var text = GenerateUnityPackageName();
            CopyText("复制的文本");
        }

    }
}
