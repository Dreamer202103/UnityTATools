using System.Collections;
using System.Collections.Generic;
using ThirdEditionTools;
using UnityEngine;

namespace Game
{
    public class HomeModule : MainManager
    {
        //抽象类再次使用时，override
        protected override void LaunchInDevelopingMode()
        {
            Debug.Log("Developing Mode");
        }

        protected override void LaunchInProductionMode()
        {
            // 测试逻辑
            // 加载逻辑
            // 初始化SDK
            // 点击开始游戏
            GameModule.LoadModule();
        }

        protected override void LaunchInTestMode()
        {
            // 测试逻辑
            // 加载逻辑
            // 初始化SDK
            // 点击开始游戏
            GameModule.LoadModule();
        }
    }
}
