using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.IO;

namespace SecondEditionTools
{
    public partial class TransformSimplify
    {
        public static void AddChild(Transform parentTrans,Transform childTrans )
        {
            childTrans.SetParent(parentTrans);
        }
    }
    public partial class GameObjectSimplify
    {
        public static void Show(Transform transform)
        {
            transform.gameObject.SetActive(true);
        }

        public static void Hide(Transform transform)
        {
            transform.gameObject.SetActive(false);
        }
    }
    public class PaetialKeyWord
    {
#if UNITY_EDITOR
        [MenuItem("Tools/SecondEdition/8. Partial ¹Ø¼ü×Ö",false,8)]
#endif
        private static void MenuClicked()
        {
            var parentTrans = new GameObject("parentTrans").transform;
            var childTrans = new GameObject("childTrans").transform;
            TransformSimplify.AddChild(parentTrans, childTrans);
            GameObjectSimplify.Hide(parentTrans);
        }
    }
}
