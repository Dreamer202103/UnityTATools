using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class HideExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Tools/ThirdEdition/Example/7.Hide �ű�", false, 7)]

        private static void MenuClicked()
        {
            //��δ����Ƕ�����������״̬
            //UnityEditor.EditorApplication�ýű��Զ����е�API
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject().AddComponent<Hide>();
        }
#endif
    }
}
 