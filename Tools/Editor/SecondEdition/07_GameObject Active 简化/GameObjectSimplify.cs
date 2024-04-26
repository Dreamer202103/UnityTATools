using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro.EditorUtilities;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SecondEditionTools
{
    //partial�ؼ��֣����ֵġ���Ҫ���ϵ����ӹ��ܵ��࣬����ǰ���partial
    //ͨ��partial�ؼ��֣������Ͽ��Զ����е��࣬�������޵�����ʵ����
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
        [MenuItem("Tools/SecondEdition/7.GameObject Active ��", false, 7)]
#endif

        private static void MenuClicked()
        {
            var gameObject = new GameObject();
            Hide(gameObject);
        }
       
    }
 
}