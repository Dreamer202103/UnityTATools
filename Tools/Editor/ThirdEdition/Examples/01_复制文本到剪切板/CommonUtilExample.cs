using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ThirdEditionTools
{
    
    public class CommonUtilExample
    {
#if UNITY_EDITOR
        [MenuItem("Tools/ThirdEdition/Example/1.�����ı������а�", false, 1)]
#endif
        private static void MenuClicked202()
        {
            // var text = GenerateUnityPackageName();
            CommonUtil.ThirdCopyText("���Ƶ��ı�");
        }
    }
}

