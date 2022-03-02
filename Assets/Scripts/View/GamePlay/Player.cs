using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Player : MonoBehaviour
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
        }

        private void FixedUpdate()
        {
            var horizontalMovement = Input.GetAxis("Horizontal");
            mRigidbody2D.velocity = new Vector2(horizontalMovement * 5, mRigidbody2D.velocity.y);

            // jump when key down and player on the ground
            if (mJumpPressed && mGroundCheck.Triggered)
            {
                mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x, 5);
            }

            mJumpPressed = false;
        }
    }
}