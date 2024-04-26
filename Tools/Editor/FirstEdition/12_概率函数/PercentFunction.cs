using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FirstEditionTools
{
    public class PercentFunction : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/12.¸ÅÂÊº¯Êý",false,12)]
#endif

        private static void MenuClicked()
        {
            Debug.Log(Percent(50));
        }

        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }
    }
}
