using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace C_Thorn.UI
{
    public class SC_InGameUiController : MyMonoBehaviour
    {

        #region Attributes
        [System.Serializable]
        public class ButtonQuitsGame
        { 
            [SerializeField] string _quitName;
            public Button _quitButton;
        }
        [Header("Button")]
        [SerializeField] ButtonQuitsGame[] _arrayQuitButton;              
        [System.Serializable]
        public class ButtonLoadLevel
        { 
            [SerializeField] string _loadName;
            public Button _loadButton;
            public int _iDLevel;
        }
        [SerializeField] ButtonLoadLevel[] _arrayLoadButton;         
        [SerializeField] Button _enterPauseButton;
        [SerializeField] Button _exitPauseButton;
        [SerializeField] Button _victoryButton;
        [Header("Text")]
        [SerializeField] Text _pointsText;
        [SerializeField] Text _taimerText;    
        [Header("Panels")]
        [SerializeField] GameObject _victoryPanel;
        [SerializeField] GameObject _defeatPanel;
        [System.Serializable] public class VariableTutoLevel 
        {   
            [Header("Button")]
            public Button _tutoButton;
            [Header("Panel")]
            public GameObject _tutoPanel;
            public GameObject _countDownPanel;
        }
        [Header("Variable Tuto Level")]
        [SerializeField] VariableTutoLevel _variableTuto;
        [System.Serializable] public class VariableCountDown 
        {
            public GameObject[] _arrayNumerPanel;
            public GameObject _countPanel;
            [HideInInspector] public bool _endCount = false;
            [HideInInspector] public int _Count = 1;
        }
        [Header("Variable Count Down")]
        [SerializeField] VariableCountDown _variableCount;

        #endregion

        #region UnityCalls
        void Start()
        {
            ToRefreshPoints();
            //button onClick 
            for (int i = 1; i <= _arrayQuitButton.Length; i++)
            {
                _arrayQuitButton[i - 1]._quitButton.onClick.AddListener(() => Application.Quit() );
            }              
              
            for (int i = 1; i <= _arrayLoadButton.Length; i++)
            {
                int _count = i;
                _arrayLoadButton[i - 1]._loadButton.onClick.AddListener(() => SceneManager.LoadScene(_arrayLoadButton[_count-1]._iDLevel) );
            }
            _enterPauseButton.onClick.AddListener(() =>  { ToPausa = true; });             
            _exitPauseButton.onClick.AddListener(() => { ToPausa = false; });
            _victoryButton.onClick.AddListener (() => ToWin());

            //start to game
              //If has tuto
            if(_variableTuto._tutoButton != null)
            { 
                Time.timeScale = 0;
                _variableTuto._tutoButton.onClick.AddListener(ToStartTuto);
            }
              //if has not tuto
            else
            {
                Time.timeScale = 1;
                _variableCount._countPanel.SetActive(true);
                ToStartTuto();
            }
            _taimerText.text =_inGameManager._time.ToString();
              
        }

        private void Update()
        {
            ToPanelVictoris();
        }
        #endregion

        #region Methods
        private int GetCurrentLevel{ get => SceneManager.sceneCount; }
        private bool ToPausa{ set => Time.timeScale = value ? 1 : 0; }          
        private void ToStartTuto()
        {
            while (!_variableCount._endCount)
            {
                if(_variableTuto._tutoPanel != null)
                    _variableTuto._tutoPanel.SetActive(false);

                if(_variableTuto._countDownPanel != null)
                    _variableTuto._countDownPanel.SetActive(true);

                ToPausa = false;
                ToCountDown();
            }
        }        
        private  void ToCountDown()
        {
            int i = _variableCount._Count;
            if(i <= _variableCount._arrayNumerPanel.Length)
            {   
                  GameObject _objetoToScale = _variableCount._arrayNumerPanel[i - 1];
                _objetoToScale.SetActive(true);
                if (_objetoToScale.transform.localScale.x > 0.2)
                {
                    _objetoToScale.transform.localScale = new Vector3(_objetoToScale.transform.localScale.x - 1.5f * Time.deltaTime,
                                                          _objetoToScale.transform.localScale.y - 1.5f * Time.deltaTime,
                                                          _objetoToScale.transform.localScale.z);
                }
                else
                {
                    _objetoToScale.SetActive(false);
                    if (i == _variableCount._arrayNumerPanel.Length)
                    {
                        _variableCount._countPanel.SetActive(false);
                        _inGameManager._isStartGame = true;
                        StartCoroutine(CorrutineTimeInGame());
                        _variableCount._endCount = true;
                    }
                    _variableCount._Count++;
                }
            }
        }
        private void ToRefreshPoints()
        {
            _pointsText.text = _inGameManager._totalPoints + " /" + _inGameManager._pointsMax;
        }
        IEnumerator CorrutineTimeInGame()
        {
            while(Time.timeScale == 1 && _inGameManager._time >= 0 )
            {   
                ToRefreshPoints();
                yield return new WaitForSeconds(1);
                _inGameManager._time--;
                _taimerText.text = _inGameManager._time.ToString();

            }
        }

        private void ToWin()
        {
            if (GetCurrentLevel > _datos.m_nivel)
            {
              _datos.m_nivel = _datos.m_nivel + 1;
                SceneManager.LoadScene(2);
            }
            else 
                SceneManager.LoadScene(2);
        }
        private void  ToPanelVictoris()
        {
            if(_inGameManager._isWin)
                  _victoryPanel.SetActive(true);  
                  
            if(_inGameManager._isLoset)
                  _defeatPanel.SetActive(true);
        }
        #endregion

    }

}
