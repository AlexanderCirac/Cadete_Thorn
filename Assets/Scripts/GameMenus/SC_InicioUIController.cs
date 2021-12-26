using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace C_Thorn.UI
{
      public class SC_InicioUIController : MonoBehaviour
      {
          #region Attributes
          [SerializeField] private GameObject _objectTextUI;
          [SerializeField] private Button _buttonLoadLevel;
          [SerializeField] private Image _brightness;
          [SerializeField] private AudioSource _music;
          [SerializeField] private bool _endCorrutine = false;
          //Main Tools
          public SC_DatosJugador _dataPlayer;
          //Events
          public event Action OnOptions;
          #endregion

          #region UnityCalls
          void Start()
          {     
                //events
                OnOptions += ControlOptions;
                //Initialize
                StartCoroutine(nameof(CorrutineOptions));
                Invoke(nameof(ShowTextUI), 0.5f);
                //buttons OnClick
                _buttonLoadLevel.onClick.AddListener( () => SceneManager.LoadScene(1));
                
          }
          private void OnDestroy()
          {     
               OnOptions -= ControlOptions;
               _endCorrutine = true;
          }
          #endregion

          #region Methods
          void ShowTextUI()
          {
               _objectTextUI.SetActive(true);
          }
          IEnumerator CorrutineOptions()
          {
               while(!_endCorrutine)
               {
                   if(OnOptions != null)
                     OnOptions();
                  yield return null;
               }
          }
          void ControlOptions()
          {
              _brightness.color = new Color(_brightness.color.r, _brightness.color.g, _brightness.color.b, _dataPlayer.m_Numero_Brillo - 0.1f);
              _music.volume = _dataPlayer.m_volumenMusica;
           
          }
          #endregion
      }

}
