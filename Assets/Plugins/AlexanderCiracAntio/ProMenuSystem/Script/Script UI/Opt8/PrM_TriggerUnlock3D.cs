using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexanderCA.ProMenu.UI
{
    [RequireComponent(typeof(Rigidbody))]
    public class PrM_TriggerUnlock3D : MonoBehaviour
    {

        #region Attributes
        public int _iD;
        #endregion


        #region UnityCalls     
        private void OnTriggerEnter(Collider other)
        {
            if ( other.CompareTag("Player") )
            {
                PrM_Unlock.UnLockID(_iD);
            }
        }

        #endregion
    }
}
