using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ThirdEditionTools
{
    public class MathUtilExample
    {
#if UNITY_EDITOR
        [MenuItem("Tools/ThirdEdition/Example/5.概率函数和随机函数", false, 5)]
#endif

        private static void MenuClicked()
        {
            //概率函数
            Debug.Log(ThirdMathUtil.ThirdPercent(50));
            //随机函数
            var randomAge = ThirdMathUtil.ThirdGetRandomValueFrom(new float[] { 0.5f, 2, 3 });
            Debug.Log(randomAge);
        }


    }
}
