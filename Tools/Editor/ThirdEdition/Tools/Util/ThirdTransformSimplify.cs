using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ThirdEditionTools
{
    //partial关键字，部分的。需要不断的增加功能的类，在类前面加partial
    //通过partial关键字，理论上可以对已有的类，进行无限的增加实例。
    public partial class ThirdTransformSimplify
    {

        //Transform的归一化
        public static void ThirdIdentity(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
        }
        public static void ThirdSetLocalposX(Transform transform,float x)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            transform.localPosition = localPos;
        }

        public static void ThirdSetLocalposY(Transform transform, float y)
        {
            var localPos = transform.localPosition;
            localPos.y = y;
            transform.localPosition = localPos;
        }

        public static void ThirdSetLocalposZ(Transform transform, float z)
        {
            var localPos = transform.localPosition;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void ThirdSetLocalposXY(Transform transform, float x,float y)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.y = y;
            transform.localPosition = localPos;
        }

        public static void ThirdSetLocalposXZ(Transform transform, float x, float z)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void ThirdSetLocalposYZ(Transform transform, float y, float z)
        {
            var localPos = transform.localPosition;
            localPos.y = y;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void AddChild(Transform parentTrans, Transform childTrans)
        {
            childTrans.SetParent(parentTrans);
        }
    }
}
