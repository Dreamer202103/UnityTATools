using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class HideExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/ThirdEdition/Example/7.Hide 脚本", false, 7)]

        private static void MenuClicked()
        {
            //这段代码是对引擎是运行状态
            //UnityEditor.EditorApplication让脚本自动运行的API
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject().AddComponent<Hide>();
        }
#endif
    }
}
 