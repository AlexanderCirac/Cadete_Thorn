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
          [Header("Beggining UI")]
          [SerializeField] private GameObject _objectTextUI;
          [SerializeField] private Button _buttonLoadLevel;
          [Header("Settings UI")]
          [SerializeField] private Image _brightness;
          [SerializeField] private AudioSource _music;
           private bool _endCorrutine = false;
          //Main Tools
          [SerializeField] private SC_DatosJugador _dataPlayer;
          //Events
          public event Action OnSettings;
          #endregion

          #region UnityCalls
          void Start()
          {     
                //events
                OnSettings += ControlSettings;
                //Initialize
                StartCoroutine(nameof(CorrutineSettings));
                Invoke(nameof(ShowTextUI), 0.5f);
                //buttons OnClick
                _buttonLoadLevel.onClick.AddListener( () => SceneManager.LoadScene(1));
                
          }
          private void OnDestroy()
          {     
               OnSettings -= ControlSettings;
               _endCorrutine = true;
          }
          #endregion

          #region Methods
          void ShowTextUI()
          {
               _objectTextUI.SetActive(true);
          }
          IEnumerator CorrutineSettings()
          {
               while(!_endCorrutine)
               {
                   if(OnSettings != null)
                     OnSettings();
                  yield return null;
               }
          }
          void ControlSettings()
          {
              _brightness.color = new Color(_brightness.color.r, _brightness.color.g, _brightness.color.b, _dataPlayer.m_Numero_Brillo - 0.1f);
              _music.volume = _dataPlayer.m_volumenMusica;
           
          }
          #endregion
      }

}
