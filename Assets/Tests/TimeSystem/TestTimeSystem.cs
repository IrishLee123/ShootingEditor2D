using System;
using System.Collections;
using System.Collections.Generic;
using FrameworkDesign;
using ShootingEditor2D;
using UnityEngine;

namespace ShootingEditor2D.Tests
{
    public class TestTimeSystem : MonoBehaviour, IController
    {
        private void Start()
        {
            Debug.Log(Time.time);
            
            this.GetSystem<ITimeSystem>().AddDelayTask(1, TestFun_1);
            this.GetSystem<ITimeSystem>().AddDelayTask(2, TestFun_2);
            this.GetSystem<ITimeSystem>().AddDelayTask(3, TestFun_3);
        }

        private void TestFun_1()
        {
            Debug.Log("TestFun_1 call");
            Debug.Log(Time.time);
        }

        private void TestFun_2()
        {
            Debug.Log("TestFun_2 call");
            Debug.Log(Time.time);
        }

        private void TestFun_3()
        {
            Debug.Log("TestFun_3 call");
            Debug.Log(Time.time);
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }
    }
}