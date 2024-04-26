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
    public class ExportUnityPackage
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/4.导出UnityPackage", false, 4)]

        private static void MenuClicked()
        {
            var assetPathName = "Assets";
            var fileName = "Tools" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //AssetDatabase是Unity提供的导出的API
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);

        }

#endif
    }
}
