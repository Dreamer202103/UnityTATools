using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SecondEditionTools
{

    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    //通过partial关键字，理论上可以对已有的类，进行无限的增加实例。
    public partial class MathUtil
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }

#if UNITY_EDITOR
        [MenuItem("Tools/SecondEdition/6.概率函数", false, 6)]
#endif

        private static void MenuClicked()
        {
            Debug.Log(Percent(50));
        }

    }
  
}
