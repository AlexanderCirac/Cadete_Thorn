using UnityEngine;

namespace C_Thorn.Game.Characters
{

    using C_Thorn.Tools.Templates;
    public class PlayerInputs : InputTemplate
    {
        #region Attributes
        [Header("Camara controller")]
        [SerializeField] private Camera _camera;
        #endregion

        #region Override Methods
        public override Vector3 GetMove()
        {
            Vector3 _currentPosition = new Vector3(transform.position.x , transform.position.y , transform.position.z);
            bool _isInScreenX = Input.mousePosition.x < ( Screen.width - ( Screen.width / 10 ) ) && ( Input.mousePosition.x > ( ( Screen.width - System.Math.Abs(Input.mousePosition.x) ) - ( ( Screen.width ) - ( Screen.width / 6 ) ) ) ) ; 
            bool _isInScreenY = Input.mousePosition.y < ( Screen.height - ( Screen.height / 5 ) ) && ( Input.mousePosition.y > ( ( Screen.height - System.Math.Abs(Input.mousePosition.y) ) - ( ( Screen.height ) - ( Screen.height / 3 ) - 50 ) ) ) ; 

            if ( _isInScreenX && _isInScreenY )
                _currentPosition = new Vector3(GetMousePosition().x , GetMousePosition().y , GetMousePosition().z);

            return _currentPosition;
        }

        public override bool GetAttack()
        {
            throw new System.NotImplementedException();
        }



        Vector3 GetMousePosition()
        {
            //#if UNITY_IOS || UNITY_IPHONE || UNITY_ANDROID
            //Touch touch = Input.GetTouch(0);
            //Vector3 mousePosition = new Vector3(touch.position.x, touch.position.y, 65);
            //#endif

            #if !UNITY_ANDROID && UNITY_EDITOR || UNITY_EDITOR_LINUX
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 65);
            #endif
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 65);
            Vector3 objPosition = _camera.ScreenToWorldPoint(mousePosition);

            return objPosition;
        }
        #endregion
    }
}
