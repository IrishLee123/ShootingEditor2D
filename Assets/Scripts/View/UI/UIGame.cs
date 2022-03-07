using FrameworkDesign;
using ShootingEditor2D.Model;
using ShootingEditor2D.System;
using UnityEngine;
using UnityEngine.UI;
using NotImplementedException = System.NotImplementedException;

namespace ShootingEditor2D
{
    public class UIGame : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }

        private Text _hpText;
        private Text _killText;
        private Text _bulletText;

        private void Awake()
        {
            _hpText = transform.Find("HpText").GetComponent<Text>();
            _killText = transform.Find("KillText").GetComponent<Text>();
            _bulletText = transform.Find("BulletText").GetComponent<Text>();

            _hpText.text = "HP: " + this.GetModel<IPlayerModel>().HP.Value + "/3";
            this.GetModel<IPlayerModel>().HP.RegisterOnValueChanged((int v) => { _hpText.text = "HP: " + v + "/3"; })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            _killText.text = "击杀数: " + this.GetSystem<IStatSystem>().KillCount.Value + "";
            this.GetSystem<IStatSystem>().KillCount.RegisterOnValueChanged((int v) =>
                {
                    _killText.text = "击杀数: " + v + "";
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            _bulletText.text = "剩余子弹: " + this.GetSystem<IGunSystem>().CurrentGun.BulletCount.Value + "";
            this.GetSystem<IGunSystem>().CurrentGun.BulletCount.RegisterOnValueChanged((int v) =>
                {
                    _bulletText.text = "剩余子弹: " + v;
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }
    }
}