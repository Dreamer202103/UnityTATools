using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ThirdEditionTools
{
    public class GameObjectSimplifyExample
    {
#if UNITY_EDITOR
        [MenuItem("Tools/ThirdEdition/Example/6.GameObject API ¼ò»¯", false, 6)]
#endif

        private static void MenuClicked()
        {
            var gameObject = new GameObject();
            ThirdGameObjectSimplify.Hide(gameObject);
        }
    }
}
