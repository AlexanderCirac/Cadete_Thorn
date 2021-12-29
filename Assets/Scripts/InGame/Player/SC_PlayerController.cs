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
          [SerializeField] private Button _toMovePlayer;
          [SerializeField] private Camera _camaraPlayer;

          //to the animation ship or player
          private Vector3 _saveInitialPos;
          private bool _endCorrutineAnimation = false;
          [Header("SpaceShip to animate")]
          [SerializeField] private GameObject _ship;
          
          //EVENT
          public static event Action OnReloadPoints;
          public static event Action OnIncresTime;
          #endregion

          #region UnityCall
          // Start is called before the first frame update
          void Start()
          {   
              _saveInitialPos = this.transform.position;
              _toMovePlayer.GetComponent<SC_UISpecialButtonToHandler>().OnHold.AddListener(PlayerToMove);
              StartCoroutine(StartCorrutineAnimation());
          }
          private void OnDestroy()
          {
              _endCorrutineAnimation = true;
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
          private void PlayerToMove()
          {
              Touch touch = Input.GetTouch(0);
              Vector3 mousePosition = new Vector3(touch.position.x, touch.position.y, 65);
              Vector3 objPosition = _camaraPlayer.ScreenToWorldPoint(mousePosition);

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
              _saveInitialPos = this.transform.position;
          }
          IEnumerator StartCorrutineAnimation() 
          {
              while(!_endCorrutineAnimation)
              {
                  AnimationShip();
                  yield return null; 
              }
          }
          public void AnimationShip()
          {
              if (this.transform.position.x > _saveInitialPos.x)
              {
                  if (_ship.transform.rotation.z > -0.3)
                  {
                      _ship.transform.RotateAround(_ship.gameObject.transform.position, Vector3.forward, -500 * Time.deltaTime);
                  }
              }
              if (_ship.transform.position.x < _saveInitialPos.x)
              {
                  if (_ship.transform.rotation.z < 0.3)
                  {
                      _ship.transform.RotateAround(_ship.gameObject.transform.position, Vector3.forward, 500 * Time.deltaTime);
                  }
              }
          }
          #endregion

    }

}
