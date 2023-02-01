using UnityEngine;
using UnityEngine.UI;
using C_Thorn.UI;
using System;

namespace C_Thorn.InGame.Player
{
    public class SC_PlayerController : MonoBehaviour
    {
          #region Attributes
          [Header("Button to move player")]
          [SerializeField] Button _playerButton;
          [SerializeField] Camera _playerCamera;

          //to the animation ship or player
          Vector3 _initialVec3;
          [Header("SpaceShip to animate")]
          [SerializeField] private GameObject _shipObject;
          
          //EVENT
          public static event Action OnReloadPoints;
          public static event Action OnIncresTime;
          #endregion

          #region UnityCall
          void Awake() => _initialVec3 = this.transform.position;
          void Start() => _playerButton.GetComponent<SC_UISpecialButtonToHandler>().OnHold.AddListener(ToMove);

          void Update() => ToAnimationShip();

          void OnTriggerEnter(Collider _col)
          {
              if (_col.CompareTag("PowerUPPoints"))
              {
                  OnReloadPoints?.Invoke();
                  Destroy(_col.gameObject);
              }              
              if (_col.CompareTag("Killer"))
                  Destroy(this.gameObject);
              if (_col.CompareTag("PowerUPTime"))
              {
                  OnIncresTime?.Invoke();
                  Destroy(_col.gameObject);
              }
          }
          #endregion

          #region Custom private Methods
          void ToMove()
          {
              Touch touch = Input.GetTouch(0);
              Vector3 mousePosition = new Vector3(touch.position.x, touch.position.y, 65);
              Vector3 objPosition = _playerCamera.ScreenToWorldPoint(mousePosition);

              transform.position = _isInScreenX ? new Vector3(objPosition.x, transform.position.y, transform.position.z) : new Vector3(transform.position.x, transform.position.y, transform.position.z);
              
              transform.position = _isInScreenY ? new Vector3(transform.position.x, objPosition.y, objPosition.z) : new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
              _initialVec3 = this.transform.position;
          }
          void ToAnimationShip()
          {
              if (this.transform.position.x > _initialVec3.x && _shipObject.transform.rotation.z > -0.3)
                  _shipObject.transform.RotateAround(_shipObject.gameObject.transform.position, Vector3.forward, -500 * Time.deltaTime);

              if (_shipObject.transform.position.x < _initialVec3.x && _shipObject.transform.rotation.z < 0.3)
                 _shipObject.transform.RotateAround(_shipObject.gameObject.transform.position, Vector3.forward, 500 * Time.deltaTime);
          }
          bool _isInScreenX { get => (Input.mousePosition.x < (Screen.width - (Screen.width / 10)) && (Input.mousePosition.x > ((Screen.width - System.Math.Abs(Input.mousePosition.x)) - ((Screen.width) - (Screen.width / 6))))); }          
          bool _isInScreenY { get => (Input.mousePosition.y < (Screen.height - (Screen.height / 5)) && (Input.mousePosition.y > ((Screen.height - System.Math.Abs(Input.mousePosition.y)) - ((Screen.height) - (Screen.height / 3) - 50)))); }
          #endregion
    }

}
