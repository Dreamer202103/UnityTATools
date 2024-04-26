using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;


namespace FirstEditionTools
{
    public class TransformLocalImprovements
    {
#if UNITY_EDITOR
        [MenuItem("Tools/FirstEdition/10.Transform ∏≥÷µ”≈ªØ",false,10)]
#endif

        private static void GerneratePackageName()
        {
            var transform = new GameObject("transform").transform;
            SetLocalposX(transform, 5.0f);
            SetLocalposY(transform, 5.0f);
            SetLocalposZ(transform, 5.0f);
        }

        public static void SetLocalposX(Transform transform,float x)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            transform.localPosition = localPos;
        }

        public static void SetLocalposY(Transform transform, float y)
        {
            var localPos = transform.localPosition;
            localPos.y = y;
            transform.localPosition = localPos;
        }

        public static void SetLocalposZ(Transform transform, float z)
        {
            var localPos = transform.localPosition;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void SetLocalposXY(Transform transform, float x,float y)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.y = y;
            transform.localPosition = localPos;
        }

        public static void SetLocalposXZ(Transform transform, float x, float z)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void SetLocalposYZ(Transform transform, float y, float z)
        {
            var localPos = transform.localPosition;
            localPos.y = y;
            localPos.z = z;
            transform.localPosition = localPos;
        }
    }
}
