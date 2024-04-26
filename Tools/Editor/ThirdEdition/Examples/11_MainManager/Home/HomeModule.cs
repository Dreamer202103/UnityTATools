using System.Collections;
using System.Collections.Generic;
using ThirdEditionTools;
using UnityEngine;

namespace Game
{
    public class HomeModule : MainManager
    {
        //�������ٴ�ʹ��ʱ��override
        protected override void LaunchInDevelopingMode()
        {
            Debug.Log("Developing Mode");
        }

        protected override void LaunchInProductionMode()
        {
            // �����߼�
            // �����߼�
            // ��ʼ��SDK
            // �����ʼ��Ϸ
            GameModule.LoadModule();
        }

        protected override void LaunchInTestMode()
        {
            // �����߼�
            // �����߼�
            // ��ʼ��SDK
            // �����ʼ��Ϸ
            GameModule.LoadModule();
        }
    }
}
