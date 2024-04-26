using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro.EditorUtilities;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FirstEditionTools
{
    public class GameObjectActiveImprovements : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/13.GameObject µÄÏÔÊ¾¡¢Òþ²Ø¼ò»¯",false,13)]
#endif

        private static void MenuClicked()
        {
            var gameObject = new GameObject();

        }
        public static void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}