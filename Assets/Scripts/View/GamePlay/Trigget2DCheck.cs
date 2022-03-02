using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Trigget2DCheck : MonoBehaviour
    {
        public LayerMask TargetLayers;

        public int EnterCount;

        public bool Triggered
        {
            get { return EnterCount > 0;  }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IsInLayerMask(col.gameObject, TargetLayers))
            {
                EnterCount++;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (IsInLayerMask(other.gameObject, TargetLayers))
            {
                EnterCount--;
            }
        }

        private bool IsInLayerMask(GameObject obj, LayerMask mask)
        {
            var objLayerMask = 1 << obj.layer;
            return (mask.value & objLayerMask) > 0;
        }
    }
}