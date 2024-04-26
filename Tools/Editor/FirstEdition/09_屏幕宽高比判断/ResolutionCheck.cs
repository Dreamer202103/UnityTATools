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
    public class ResolutionCheck : MonoBehaviour
    {
#if UNITY_EDITOR 
        [MenuItem("Tools/FirstEdition/9.��Ļ��߱��ж�",false,9)]
#endif
        private static void MenuClicked()
        {

        }
        /// <summary>
        /// ��ȡ��Ļ��߱�
        /// </summary>
        /// <returns></returns>
        public static float GetAspectRatio()
        {
            return Screen.width > Screen.height ? (float)Screen.width / Screen.height : (float)Screen.height / Screen.width;
         }

        /// <summary>
        /// �Ƿ���Ipad�ֱ���4��3
        /// </summary>
        /// <returns></returns>
        public static bool IsPadResolution()
        {
            var aspect = GetAspectRatio();
            return aspect > 4.0f / 3 - 0.05f && aspect < 4.0f / 3 + 0.05f;
        }

        /// <summary>
        /// �Ƿ����ֻ��ֱ���
        /// </summary>
        /// <returns></returns>
        public static bool IsPhoneResolution()
        {
            var aspect = GetAspectRatio();
            return aspect > 16.0f / 9 - 0.05f && aspect < 16.0f / 9 + 0.05f;
        }

        public static bool IsPhoneVResolution()
        {
            var aspect = GetAspectRatio();
            return aspect > 2436.0f / 1125 - 0.05f && aspect < 2436.0f / 1125 + 0.05f;
        }
    }
}
