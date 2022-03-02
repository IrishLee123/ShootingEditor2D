using System;
using UnityEngine;

namespace ShootingEditor2D.View.GamePlay
{
    public class CameraController : MonoBehaviour
    {
        private Transform mPlayerTrans;

        private void Update()
        {
            if (!mPlayerTrans)
            {
                var playerGameObj = GameObject.FindWithTag("Player");

                if (playerGameObj)
                {
                    mPlayerTrans = playerGameObj.transform;
                }
                else
                {
                    return;
                }
            }

            var cameraPos = transform.position;
            cameraPos.x = mPlayerTrans.transform.position.x + 2;
            cameraPos.y = mPlayerTrans.transform.position.y + 2;

            transform.position = cameraPos;
        }
    }
}