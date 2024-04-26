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
        [MenuItem("Tools/FirstEdition/5.打开UnityPackage所在的文件夹",false,5)]

        private static void MenuClicked()
        {
            //Application.OpenURL中传入的参数如果是网址，那么打开的就是网址。如果传入的是“file:///”开头的路径，则打开的是这个目录
            Application.OpenURL("file:///" + Application.dataPath);
        }
#endif
    }
}
