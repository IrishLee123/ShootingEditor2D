using System;
using System.Collections;
using System.Collections.Generic;
using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Gun : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }

        private Bullet mBullet;

        private GunInfo mGunInfo;

        private void Awake()
        {
            mBullet = transform.Find("Bullet").GetComponent<Bullet>();

            mGunInfo = this.GetSystem<IGunSystem>().CurrentGun;
        }

        public void Shoot()
        {
            if (mGunInfo.BulletCount.Value > 0)
            {
                var bullet = Instantiate(mBullet, mBullet.transform.position, mBullet.transform.rotation);
                bullet.transform.localScale = mBullet.transform.lossyScale;
                bullet.gameObject.SetActive(true);
                
                this.SendCommand<ShootCommand>();
            }
        }

        private void OnDestroy()
        {
            // mGunInfo = null;
        }
    }
}