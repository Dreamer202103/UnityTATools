using SecondEditionTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdEditionTools
{
    public class Hide : MonoBehaviourSimplify
    {
        protected override void OnBeforeDestroy()
        {
            
        }

        private void Awake()
        {
            Hide();
        }
        
    }
}
