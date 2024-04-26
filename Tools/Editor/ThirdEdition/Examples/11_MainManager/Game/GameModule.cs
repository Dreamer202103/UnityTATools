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

        //抽象类再次使用时，override
        protected override void LaunchInDevelopingMode()
        {
            // 加载逻辑
            // 初始化SDK
            // 点击开始游戏
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
