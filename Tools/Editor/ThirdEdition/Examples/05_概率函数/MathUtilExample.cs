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
        [MenuItem("Tools/ThirdEdition/Example/5.���ʺ������������", false, 5)]
#endif

        private static void MenuClicked()
        {
            //���ʺ���
            Debug.Log(ThirdMathUtil.ThirdPercent(50));
            //�������
            var randomAge = ThirdMathUtil.ThirdGetRandomValueFrom(new float[] { 0.5f, 2, 3 });
            Debug.Log(randomAge);
        }


    }
}
