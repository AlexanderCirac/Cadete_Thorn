using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace C_Thorn.UI.Settings
{
    public class SC_SettingsUIController : MonoBehaviour
    {
          #region Attributes
          [Header("UI Settings")]
          [SerializeField] private Image _brightness;
          [SerializeField] private Slider _sliderBrightness;
          [SerializeField] private Toggle _optionToggle;
          private AudioSource _music;
          [SerializeField] private Slider _sliderMusic;
          [Header("Activate Panel left Hand")]
          [SerializeField] private GameObject _panelLeftHand;
          [SerializeField] private GameObject _panelRightHand;
          private bool _endCorrutineSetting = false;
          private int _idLeft_Hand = 0;
          private int _valuebrightness = 0;
          private int _valueMusic = 0;
          //Main Tools
          [HideInInspector] public SC_DatosJugador _dataPlayer;
          //events
          public event Action OnSettings;
          #endregion

          #region UnityCall
          private void Awake()
          {
              StartCoroutine(nameof(GetDateJugadorCorrutine));
              StartCoroutine(nameof(CorrutineChangePanelLeftHand));
          }
          private void Start()
          {
              _music = _dataPlayer.GetComponentInChildren<AudioSource>();
              OnSettings += ApplicateUISettings;
              StartCoroutine(nameof(CorrutineSettings));
          }
          private void OnDestroy()
          {
              _endCorrutineSetting = true;
              OnSettings -= ApplicateUISettings;
          }
          #endregion

          #region Methods
          IEnumerator GetDateJugadorCorrutine()
          {
              while(_dataPlayer == null)
              {   
                  _dataPlayer = FindObjectOfType<SC_DatosJugador>();
                  yield return null;
              }
          }
            IEnumerator CorrutineSettings()
          {
                while(!_endCorrutineSetting)
                {
                    if(OnSettings != null)
                        OnSettings();
                    yield return null;
                }
          }
          void ApplicateUISettings()
          {
              //brightness intensity controller
              _brightness.color = new Color(_brightness.color.r, _brightness.color.g, _brightness.color.b, _dataPlayer.m_Numero_Brillo - 0.1f);
              //Controll volum of music
              _music.volume = _dataPlayer.m_volumenMusica;
              //left-handed or right-handed Controller
              if (_idLeft_Hand == 0) 
              { 
                  _optionToggle.isOn = _dataPlayer.m_Zurdo;
                  _idLeft_Hand = 1;
              }
              else
              _dataPlayer.m_Zurdo = _optionToggle.isOn;

              //Aplicate value sliders Brightness and music
              if (_dataPlayer.m_Numero_Brillo != 0 && _valuebrightness != 1)
              {
                  _sliderBrightness.value = _dataPlayer.m_Numero_Brillo;
                  _valuebrightness = 1;
              }
              else
              {
                  _dataPlayer.m_Numero_Brillo = _sliderBrightness.value;
              }
              if (_dataPlayer.m_volumenMusica != 0 && _valueMusic != 1)
              {
                  _sliderMusic.value = _dataPlayer.m_volumenMusica;
                  _valueMusic = 1;
              }
              else
              {
                  _dataPlayer.m_volumenMusica = _sliderMusic.value;
              }
          }

          IEnumerator CorrutineChangePanelLeftHand()
          {
              while (!_endCorrutineSetting && _panelLeftHand != null)
              {
                  if (_optionToggle.isOn)
                  {
                      _panelLeftHand.SetActive(true);
                      _panelRightHand.SetActive(false);                      
                  }
                  else
                  {
                      _panelLeftHand.SetActive(false);
                      _panelRightHand.SetActive(true);
                  }
                  yield return null;
              }
          }  
          #endregion
    }
}

