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
    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
    //ͨ��partial�ؼ��֣������Ͽ��Զ����е��࣬�������޵�����ʵ����
    public partial class CommonUtil
    {
        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }

#if UNITY_EDITOR
        [MenuItem("Tools/SecondEdition/2.�����ı������а�", false, 2)]
#endif
        private static void MenuClicked202()
        {
            // var text = GenerateUnityPackageName();
            CopyText("���Ƶ��ı�");
        }

    }
}
