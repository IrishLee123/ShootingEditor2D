using FrameworkDesign;
using ShootingEditor2D.Model;
using ShootingEditor2D.Query;
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
        private Text _bulletBag;
        private Text _gunName;
        private Text _gunState;

        private void Awake()
        {

            _hpText = transform.Find("HpText").GetComponent<Text>();
            _killText = transform.Find("KillText").GetComponent<Text>();
            _bulletText = transform.Find("BulletText").GetComponent<Text>();
            _bulletBag = transform.Find("BulletBag").GetComponent<Text>();
            _gunName = transform.Find("GunName").GetComponent<Text>();
            _gunState = transform.Find("GunState").GetComponent<Text>();

            _hpText.text = "HP: " + this.GetModel<IPlayerModel>().HP.Value + "/3";
            this.GetModel<IPlayerModel>().HP.RegisterOnValueChanged((int v) => { _hpText.text = "HP: " + v + "/3"; })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            _killText.text = "击杀数: " + this.GetSystem<IStatSystem>().KillCount.Value + "";
            this.GetSystem<IStatSystem>().KillCount.RegisterOnValueChanged((int v) =>
                {
                    _killText.text = "击杀数: " + v + "";
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            var mMaxBulletCount = this.SendQuery(new MaxBulletCountQuery(this.GetSystem<IGunSystem>().CurrentGun));
            _bulletText.text = "剩余子弹: " + this.GetSystem<IGunSystem>().CurrentGun.BulletCountInGun.Value + "/" +
                               mMaxBulletCount;
            this.GetSystem<IGunSystem>().CurrentGun.BulletCountInGun.RegisterOnValueChanged((int v) =>
                {
                    var mMaxBulletCount = this.SendQuery(new MaxBulletCountQuery(this.GetSystem<IGunSystem>().CurrentGun));
                    _bulletText.text = "剩余子弹: " + v + "/" + mMaxBulletCount;
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            _bulletBag.text = "背包子弹: " + this.GetSystem<IGunSystem>().CurrentGun.BulletCountOutGun.Value + "";
            this.GetSystem<IGunSystem>().CurrentGun.BulletCountOutGun.RegisterOnValueChanged((int v) =>
                {
                    _bulletBag.text = "背包子弹: " + v;
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            _gunName.text = "枪械名称: " + this.GetSystem<IGunSystem>().CurrentGun.Name.Value + "";
            this.GetSystem<IGunSystem>().CurrentGun.Name.RegisterOnValueChanged((string v) =>
                {
                    _gunName.text = "枪械名称: " + v;
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            _gunState.text = "枪械状态: " + this.GetSystem<IGunSystem>().CurrentGun.State.Value;
            this.GetSystem<IGunSystem>().CurrentGun.State.RegisterOnValueChanged((GunState v) =>
                {
                    _gunState.text = "枪械状态: " + v;
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }
    }
}