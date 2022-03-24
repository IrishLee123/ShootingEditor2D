using System;
using System.Collections;
using System.Collections.Generic;
using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Player : MonoBehaviour, IController
    {
        private Rigidbody2D mRigidbody2D;

        private bool mJumpPressed;

        private Trigget2DCheck mGroundCheck;

        private Gun mGun;

        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();

            mGroundCheck = transform.Find("GroundCheck").GetComponent<Trigget2DCheck>();
            mGun = transform.Find("Gun").GetComponent<Gun>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mJumpPressed = true;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                mGun.Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                mGun.Reload();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                this.SendCommand(new PickGunCommand("UMP9", 45, 45));
            }

            var horizontalMovement = Input.GetAxis("Horizontal");

            if (horizontalMovement < 0 && transform.localScale.x > 0 ||
                horizontalMovement > 0 && transform.localScale.x < 0)
            {
                var localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }

            mRigidbody2D.velocity = new Vector2(horizontalMovement * 5, mRigidbody2D.velocity.y);

            // jump when key down and player on the ground
            if (mJumpPressed && mGroundCheck.Triggered)
            {
                mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x, 5);
            }

            mJumpPressed = false;
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }
    }
}