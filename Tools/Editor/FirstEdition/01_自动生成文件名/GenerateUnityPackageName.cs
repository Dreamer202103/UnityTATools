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
    public class GenerateUnityPackageName
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/1.���� UnityPackage ����",false,1)]
#endif

        private static void MenuClicked()
        {
            //ʹ����UnitySystem�е�DataTime��Api
            Debug.Log("Tools" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }
    }
}
