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
          [SerializeField] private GameObject _textUIPanel;
          [SerializeField] private Button _loadingButton;
          [Header("Settings UI")]
          [SerializeField] private Image _brightnessImage;
          [SerializeField] private AudioSource _musicAudioSource;
          //Main Tools
          [SerializeField] private SC_DatosJugador _dataPlayer;
          //Events
          private static event Action OnSettings;
          #endregion

          #region UnityCalls
          void Start()
          {     
                //events
                OnSettings += ToControlSettings;

                //Initialize
                Invoke(nameof(ToShowTextUI), 0.5f);

                //buttons OnClick
                _loadingButton.onClick.AddListener( () => SceneManager.LoadScene(1));
                
          }

          private void Update()
          {
                 if(OnSettings != null)
                      OnSettings();
          }
          private void OnDestroy()
          {     
                OnSettings -= ToControlSettings;
          }
          #endregion

          #region Methods
          private  void ToShowTextUI()
          {
                _textUIPanel.SetActive(true);
          }
      
          private void ToControlSettings()
          {
              _brightnessImage.color = new Color(_brightnessImage.color.r, _brightnessImage.color.g, _brightnessImage.color.b, _dataPlayer.m_Numero_Brillo - 0.1f);
              _musicAudioSource.volume = _dataPlayer.m_volumenMusica;
           
          }
          #endregion
    }

}
