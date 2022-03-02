using System;
using FrameworkDesign;
using ShootingEditor2D.Command;
using UnityEngine;

namespace ShootingEditor2D.View
{
    public class AttackPlayer : MonoBehaviour, IController
    {
        public int Hurt = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                this.SendCommand(new HurtPlayerCommand(Hurt));
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }
    }
}