using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace C_Thorn.Game.Characters
{

    using C_Thorn.Game.Templates;
    public class PlayerInputs : InputTemplate
    {
        #region Attributes
        [SerializeField] private Button _moveButton;
        [SerializeField] private Camera _camera;
        #endregion
        #region UnityCalls
        private void Awake()
        {
            _moveButton.onClick.AddListener(() => GetMove());
        }
        #endregion
        #region Override Methods
        public override Vector3 GetMove()
        {
            Vector3 _currentPosition = Vector3.zero;

            _currentPosition = _isInScreenX && !_isInScreenY ? new Vector3(GetMousePosition().x , transform.position.y , transform.position.z) : new Vector3(transform.position.x , GetMousePosition().y , GetMousePosition().z);

            return _currentPosition;
        }

        public override bool GetAttack()
        {
            throw new System.NotImplementedException();
        }


        bool _isInScreenX { get => ( Input.mousePosition.x < ( Screen.width - ( Screen.width / 10 ) ) && ( Input.mousePosition.x > ( ( Screen.width - System.Math.Abs(Input.mousePosition.x) ) - ( ( Screen.width ) - ( Screen.width / 6 ) ) ) ) ); }
        bool _isInScreenY { get => ( Input.mousePosition.y < ( Screen.height - ( Screen.height / 5 ) ) && ( Input.mousePosition.y > ( ( Screen.height - System.Math.Abs(Input.mousePosition.y) ) - ( ( Screen.height ) - ( Screen.height / 3 ) - 50 ) ) ) ); }

        Vector3 GetMousePosition()
        {
            Touch touch = Input.GetTouch(0);
            Vector3 mousePosition = new Vector3(touch.position.x, touch.position.y, 65);
            Vector3 objPosition = _camera.ScreenToWorldPoint(mousePosition);

            return objPosition;
        }
        #endregion
    }
}
