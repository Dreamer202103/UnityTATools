using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro.EditorUtilities;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SecondEditionTools
{
    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    //通过partial关键字，理论上可以对已有的类，进行无限的增加实例。
    public partial class GameObjectSimplify
    {
        public static void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

#if UNITY_EDITOR
        [MenuItem("Tools/SecondEdition/7.GameObject Active 简化", false, 7)]
#endif

        private static void MenuClicked()
        {
            var gameObject = new GameObject();
            Hide(gameObject);
        }
       
    }
 
}