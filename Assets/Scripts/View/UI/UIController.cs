using System;
using FrameworkDesign;
using ShootingEditor2D.Model;
using ShootingEditor2D.System;
using UnityEngine;

namespace ShootingEditor2D.View
{
    public class UIController : MonoBehaviour, IController
    {
        private IStatSystem mStatSystem;
        private IPlayerModel mPlayerModel;

        private void Awake()
        {
            mStatSystem = this.GetSystem<IStatSystem>();
            mPlayerModel = this.GetModel<IPlayerModel>();
        }

        private readonly Lazy<GUIStyle> mLabelStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
        {
            fontSize = 40
        });

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 300, 100), $"生命:{mPlayerModel.HP.Value}/3", mLabelStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 10, 300, 100), $"击杀数量:{mStatSystem.KillCount.Value}",
                mLabelStyle.Value);
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }
    }
}