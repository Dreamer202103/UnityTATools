using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace ThirdEditionTools
{
    public class ThirdResolutionCheck
    {

        /// <summary>
        /// ��ȡ��Ļ��߱�
        /// </summary>
        /// <returns></returns>
        public static float ThirdGetAspectRatio()
        {
            return Screen.width > Screen.height ? (float)Screen.width / Screen.height : (float)Screen.height / Screen.width;
         }

        /// <summary>
        /// �Ƿ���Ipad�ֱ���4��3
        /// </summary>
        /// <returns></returns>
        public static bool ThirdIsPadResolution()
        {
            var aspect = ThirdGetAspectRatio();
            return aspect > 4.0f / 3 - 0.05f && aspect < 4.0f / 3 + 0.05f;
        }

        /// <summary>
        /// �Ƿ����ֻ��ֱ���
        /// </summary>
        /// <returns></returns>
        public static bool ThirdIsPhoneResolution()
        {
            var aspect = ThirdGetAspectRatio();
            return aspect > 16.0f / 9 - 0.05f && aspect < 16.0f / 9 + 0.05f;
        }

        public static bool ThirdIsPhoneVResolution()
        {
            var aspect = ThirdGetAspectRatio();
            return aspect > 2436.0f / 1125 - 0.05f && aspect < 2436.0f / 1125 + 0.05f;
        }
    }
}
