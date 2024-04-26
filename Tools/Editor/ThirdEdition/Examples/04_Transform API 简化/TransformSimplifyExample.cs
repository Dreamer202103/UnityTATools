using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ThirdEditionTools
{
    public class TransformSimplifyExample : MonoBehaviour
    {
      
#if UNITY_EDITOR
            [MenuItem("Tools/ThirdEdition/Example/4.Transform API ¼ò»¯", false, 4)]
#endif

            private static void MenuClicked()
            {
                var transform = new GameObject("transform").transform;
                ThirdTransformSimplify.ThirdSetLocalposX(transform, 5.0f);
                ThirdTransformSimplify.ThirdSetLocalposY(transform, 5.0f);
                ThirdTransformSimplify.ThirdSetLocalposZ(transform, 5.0f);

                ThirdTransformSimplify.ThirdIdentity(transform);

                var parentTrans = new GameObject("parentTrans").transform;
                var childTrans = new GameObject("childTrans").transform;
                ThirdPaetialKeyWord.TransformSimplify.AddChild(parentTrans, childTrans);
                ThirdPaetialKeyWord.GameObjectSimplify.Hide(parentTrans);
             }
        }
 }
