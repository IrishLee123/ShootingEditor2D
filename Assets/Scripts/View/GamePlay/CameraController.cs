using System;
using System.Timers;
using UnityEngine;

namespace ShootingEditor2D.View.GamePlay
{
    public class CameraController : MonoBehaviour
    {
        private Transform mPlayerTrans;

        private float xMin = -5;
        private float xMax = 5;
        private float yMin = -5;
        private float yMax = 5;

        private Vector3 targetPos;

        private void LateUpdate()
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

            var isRight = Mathf.Sign(mPlayerTrans.localScale.x);

            targetPos.x = mPlayerTrans.transform.position.x + 3 * isRight;
            targetPos.y = mPlayerTrans.transform.position.y + 2;
            targetPos.z = -10;

            var smoothSpeed = 5;

            var position = transform.position;
            position = Vector3.Lerp(position, new Vector3(targetPos.x, targetPos.y, position.z),
                smoothSpeed * Time.deltaTime);

            transform.position = new Vector3(Mathf.Clamp(position.x, xMin, xMax), Mathf.Clamp(position.y, yMin, yMax),
                position.z);
        }
    }
}