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
        }

        private void Start()
        {
            mRigidbody2D.velocity = new Vector2(10, 0);
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