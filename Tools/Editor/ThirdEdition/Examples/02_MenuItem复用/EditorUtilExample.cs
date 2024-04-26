using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ThirdEditionTools
{
    public class EditorUtilExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("Tools/ThirdEdition/Example/2.MenuItem 复用", false, 2)]
        private static void MenuClicked()
        {
            ThirdEditorUtil.CallMenuItem("Tools/ThirdEdition/Example/1.复制文本到剪切板");
        }
#endif
    }
}
