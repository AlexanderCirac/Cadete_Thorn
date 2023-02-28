using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexanderCA.ProMenu.UI
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PrM_TriggerUnlock2D : MonoBehaviour
    {
        #region Attributes
        public int _iD;
        #endregion


        #region UnityCalls     
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ( collision.CompareTag("Player") )
            {
                PrM_Unlock.UnLockID(_iD);
            }
        }
       
        
        #endregion

        #region Costum private Methods

        #endregion

    }
}
