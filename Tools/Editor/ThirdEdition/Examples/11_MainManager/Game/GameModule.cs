using System;
using System.Collections;
using System.Collections.Generic;
using ThirdEditionTools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameModule : MainManager
    {
        public static void LoadModule()
        {
            SceneManager.LoadScene("Game");
        }

        //�������ٴ�ʹ��ʱ��override
        protected override void LaunchInDevelopingMode()
        {
            // �����߼�
            // ��ʼ��SDK
            // �����ʼ��Ϸ
            Debug.Log("Developing Mode");
        }

        protected override void LaunchInProductionMode()
        {
            Debug.Log("Production Mode");
        }

        protected override void LaunchInTestMode()
        {
            Debug.Log("Test Mode");
        }


    }
}
