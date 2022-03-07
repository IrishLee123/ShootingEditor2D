using System;
using FrameworkDesign;
using ShootingEditor2D.Command;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Bullet : MonoBehaviour, IController
    {
        private Rigidbody2D mRigidbody2D;

        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();

            Destroy(gameObject, 5);
        }

        private void Start()
        {
            var isRight = Mathf.Sign(transform.lossyScale.x);
            mRigidbody2D.velocity = new Vector2(10 * isRight, 0);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                Destroy(col.gameObject);
                Destroy(gameObject);

                this.SendCommand<KillEnemyCommand>();
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }
    }
}