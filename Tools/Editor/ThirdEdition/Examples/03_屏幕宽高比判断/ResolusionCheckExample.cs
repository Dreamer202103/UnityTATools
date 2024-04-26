using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ThirdEditionTools
{
    public class ResolusionCheckExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("Tools/ThirdEdition/Example/3.屏幕宽高比判断", false, 3)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(ThirdResolutionCheck.ThirdIsPadResolution() ? "是 pad" : "不是 Pad");
            Debug.Log(ThirdResolutionCheck.ThirdIsPhoneResolution() ? "是 Phone" : "不是 Phone");
            Debug.Log(ThirdResolutionCheck.ThirdIsPhoneVResolution() ? "是 IphoneX" : "不是 IphoneX");
        }
    }
}
