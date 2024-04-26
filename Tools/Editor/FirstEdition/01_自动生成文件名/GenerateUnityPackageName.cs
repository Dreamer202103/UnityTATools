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
        [MenuItem("Tools/FirstEdition/1.生成 UnityPackage 名字",false,1)]
#endif

        private static void MenuClicked()
        {
            //使用了UnitySystem中的DataTime的Api
            Debug.Log("Tools" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }
    }
}
