using UnityEngine;
using UnityEngine.UI;

namespace C_Thorn.UI.Settings
{   
    public class SC_SettingsUIController : MyMonoBehaviour
    {
        #region Attributes
        [Header("UI Settings")]
        [SerializeField] Image _brightness;
        [SerializeField] Slider _sliderBrightness;
        [SerializeField] Toggle _optionToggle;
        [SerializeField] Slider _sliderMusic;
        [Header("Activate Panel left Hand")]
        [SerializeField] GameObject _panelLeftHand;
        [SerializeField] GameObject _panelRightHand;
        int _idLeft_Hand = 0;
        int _valuebrightness = 0;
        int _valueMusic = 0;
        #endregion

        #region UnityCall
        private void Start()
        {
            _gameMenus.OnSettings += ApplicateUISettings;
        }
        private void OnDestroy()
        {
            _gameMenus.OnSettings -= ApplicateUISettings;
        }
        #endregion

        #region Methods
        void ApplicateUISettings()
        {
            //brightness intensity controller
            _brightness.color = new Color(_brightness.color.r, _brightness.color.g, _brightness.color.b, _datos.m_Numero_Brillo - 0.1f);
            //Controll volum of music
            Music.volume = _datos.m_volumenMusica;
            //left-handed or right-handed Controller
            if (_idLeft_Hand == 0) 
            { 
                _optionToggle.isOn = _datos.m_Zurdo;
                _idLeft_Hand = 1;
            }
            else
            _datos.m_Zurdo = _optionToggle.isOn;

            //Aplicate value sliders Brightness and music
            if (_datos.m_Numero_Brillo != 0 && _valuebrightness != 1)
            {
                _sliderBrightness.value = _datos.m_Numero_Brillo;
                _valuebrightness = 1;
            }
            else
            {
                _datos.m_Numero_Brillo = _sliderBrightness.value;
            }
            if (_datos.m_volumenMusica != 0 && _valueMusic != 1)
            {
                _sliderMusic.value = _datos.m_volumenMusica;
                _valueMusic = 1;
            }
            else
            {
                _datos.m_volumenMusica = _sliderMusic.value;
            }
            if (!_panelLeftHand)
            {
                _panelLeftHand.SetActive(_optionToggle.isOn);
                _panelRightHand.SetActive(!_optionToggle.isOn);                      

            }
        }
        AudioSource Music { 
            get => _datos.GetComponentInChildren<AudioSource>();
        }
        #endregion
    }
}

