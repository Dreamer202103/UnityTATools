using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.IO;


namespace FirstEditionTools
{
    public class TransformIdentity : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/11.Transform πÈ“ªªØ",false,11)]
#endif
        private static void MenuClicked()
        {
            var transform = new GameObject("transform").transform;
            Identity(transform);
        }

        public static void Identity(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
        }
    }
}
