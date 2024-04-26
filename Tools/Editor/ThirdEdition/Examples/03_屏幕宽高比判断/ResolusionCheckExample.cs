using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ThirdEditionTools
{
    public class ResolusionCheckExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("Tools/ThirdEdition/Example/3.��Ļ��߱��ж�", false, 3)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(ThirdResolutionCheck.ThirdIsPadResolution() ? "�� pad" : "���� Pad");
            Debug.Log(ThirdResolutionCheck.ThirdIsPhoneResolution() ? "�� Phone" : "���� Phone");
            Debug.Log(ThirdResolutionCheck.ThirdIsPhoneVResolution() ? "�� IphoneX" : "���� IphoneX");
        }
    }
}
