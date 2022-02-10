using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using C_Thorn.UI;
using System;
namespace C_Thorn.InGame.Player
{
    public class SC_PlayerController : MonoBehaviour
    {

          #region Attributes
          [Header("Button to move player")]
          [SerializeField] private Button _playerButton;
          [SerializeField] private Camera _playerCamera;

          //to the animation ship or player
          private Vector3 _initialVec3;
          [Header("SpaceShip to animate")]
          [SerializeField] private GameObject _shipObject;
          
          //EVENT
          public static event Action OnReloadPoints;
          public static event Action OnIncresTime;
          #endregion

          #region UnityCall
          private void Awake()
          {
              _initialVec3 = this.transform.position;
          }
          void Start()
          {   
              _playerButton.GetComponent<SC_UISpecialButtonToHandler>().OnHold.AddListener(ToMove);
          }

          private void Update()
          {
              ToAnimationShip();
          }

          private void OnTriggerEnter(Collider _col)
          {
              if (_col.CompareTag("PowerUPPoints"))
              {
                  if(OnReloadPoints != null)
                  {
                      OnReloadPoints();
                  }
                  Destroy(_col.gameObject);
              }              
      
              if (_col.CompareTag("Killer"))
              {
                  Destroy(this.gameObject);
              }
              
              if (_col.CompareTag("PowerUPTime"))
              {
                  if(OnIncresTime != null)
                  {
                      OnIncresTime();
                  }
                  Destroy(_col.gameObject);
              }

          }
          #endregion

          #region Methods
          private void ToMove()
          {
              Touch touch = Input.GetTouch(0);
              Vector3 mousePosition = new Vector3(touch.position.x, touch.position.y, 65);
              Vector3 objPosition = _playerCamera.ScreenToWorldPoint(mousePosition);

              if (Input.mousePosition.x < (Screen.width - (Screen.width / 10)) && (Input.mousePosition.x > ((Screen.width - System.Math.Abs(Input.mousePosition.x)) - ((Screen.width) - (Screen.width / 6)))))
              {
                  transform.position = new Vector3(objPosition.x, transform.position.y, transform.position.z);
              }
              else
              {
                  transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
              }


              if (Input.mousePosition.y < (Screen.height - (Screen.height / 5)) && (Input.mousePosition.y > ((Screen.height - System.Math.Abs(Input.mousePosition.y)) - ((Screen.height) - (Screen.height / 3) - 50))))
              {
                  transform.position = new Vector3(transform.position.x, objPosition.y, objPosition.z);
              }
              else
              {
                  transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
              }
              _initialVec3 = this.transform.position;
          }
          private void ToAnimationShip()
          {
              if (this.transform.position.x > _initialVec3.x)
              {
                  if (_shipObject.transform.rotation.z > -0.3)
                  {
                      _shipObject.transform.RotateAround(_shipObject.gameObject.transform.position, Vector3.forward, -500 * Time.deltaTime);
                  }
              }
              if (_shipObject.transform.position.x < _initialVec3.x)
              {
                  if (_shipObject.transform.rotation.z < 0.3)
                  {
                      _shipObject.transform.RotateAround(_shipObject.gameObject.transform.position, Vector3.forward, 500 * Time.deltaTime);
                  }
              }
          }
          #endregion

    }

}
