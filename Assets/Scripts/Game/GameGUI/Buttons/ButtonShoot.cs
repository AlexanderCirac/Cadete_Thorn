using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.UI
{
    using C_Thorn.Tools.Interfaces;
    public class ButtonShoot : MonoBehaviour, IButtonAction
    {
        #region Attributes
        [SerializeField] GameObject _bulletPref;
        [SerializeField] GameObject _puntero;
        #endregion
        public void ToButtonAction()
        {
            Instantiate(_bulletPref, _puntero.transform.position, _puntero.transform.rotation);
        }
    }

}
