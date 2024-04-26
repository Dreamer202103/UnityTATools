using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SecondEditionTools
{

    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
    //ͨ��partial�ؼ��֣������Ͽ��Զ����е��࣬�������޵�����ʵ����
    public partial class MathUtil
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }

#if UNITY_EDITOR
        [MenuItem("Tools/SecondEdition/6.���ʺ���", false, 6)]
#endif

        private static void MenuClicked()
        {
            Debug.Log(Percent(50));
        }

    }
  
}
