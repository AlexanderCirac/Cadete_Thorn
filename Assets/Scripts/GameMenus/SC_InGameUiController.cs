using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using C_Thorn.UI.Settings;
using C_Thorn.InGame;

namespace C_Thorn.UI
{
    public class SC_InGameUiController : MonoBehaviour
    {

          #region Attributes
          [System.Serializable]
          public class ButtonQuitsGame
          { 
              [SerializeField] private string _quitName;
              public Button _quitButton;
          }
          [Header("Button")]
          [SerializeField] private ButtonQuitsGame[] _arrayQuitButton;              
          [System.Serializable]
          public class ButtonLoadLevel
          { 
              [SerializeField] private string _loadName;
              public Button _loadButton;
              public int _iDLevel;
          }
          [SerializeField] private ButtonLoadLevel[] _arrayLoadButton;         
          [SerializeField] private Button _enterPauseButton;
          [SerializeField] private Button _exitPauseButton;
          [SerializeField] private Button _victoryButton;
          [Header("Int")]
          [SerializeField] private int _currentLevel;
          [Header("Text")]
          [SerializeField] private Text _pointsText;
          [SerializeField] private Text _taimerText;    
          [Header("Panels")]
          [SerializeField] private GameObject _victoryPanel;
          [SerializeField] private GameObject _defeatPanel;
          private bool _flipFlopPauseGame = true;
          [System.Serializable] public class VariableTutoLevel 
          {   
              [Header("Button")]
              public Button _tutoButton;
              [Header("Panel")]
              public GameObject _tutoPanel;
              public GameObject _countDownPanel;
          }
          [Header("Variable Tuto Level")]
          [SerializeField] private VariableTutoLevel _variableTuto;
          [System.Serializable] public class VariableCountDown 
          {
              public GameObject[] _arrayNumerPanel;
              public GameObject _countPanel;
              [HideInInspector]public bool _endCount = false;
              [HideInInspector]public int _Count = 1;
          }
          [Header("Variable Count Down")]
          [SerializeField] private VariableCountDown _variableCount;

          //Main Tools
          [Header("Main Tools")]
          public SC_SettingsUIController _settingsUIController;
          public SC_InGameManager _inGameManager;

          //Events
          public event Action<bool> OnPausaGame;
          public static event Action OnReloadPoints;
          #endregion

          #region UnityCalls
          void Start()
          {
              // EVENTS
              OnPausaGame += ToPausaGame;
              OnReloadPoints += ToRefreshPoints;
              
              if(OnReloadPoints != null)
              {
                  OnReloadPoints();
              }

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
              _enterPauseButton.onClick.AddListener(() => 
              {
                  if (OnPausaGame != null)
                  {
                      OnPausaGame(_flipFlopPauseGame = !_flipFlopPauseGame);
                  }
              });             
              _exitPauseButton.onClick.AddListener(() => 
              {
             
                  if (OnPausaGame != null)
                  {
                      OnPausaGame(_flipFlopPauseGame = !_flipFlopPauseGame);
                  }
              });
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
              _taimerText.text =_inGameManager._countTime.ToString();
              
          }

          private void OnDestroy()
          {
              OnPausaGame -=  ToPausaGame;
              OnReloadPoints -= ToRefreshPoints;
          }

          private void Update()
          {
              ToPanelVictoris();
          }
          #endregion

          #region Methods
          private void ToPausaGame(bool coso)
          {
              if(!coso)
              {
                  Time.timeScale = 1;
              }
              else
                  Time.timeScale = 0;
          }          
          private void ToStartTuto()
          {
              while (!_variableCount._endCount)
              {
                  if(_variableTuto._tutoPanel != null)
                      _variableTuto._tutoPanel.SetActive(false);

                  if(_variableTuto._countDownPanel != null)
                      _variableTuto._countDownPanel.SetActive(true);

                  Time.timeScale = 1;
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
                          _inGameManager._startToGame = true;
                          StartCoroutine(CorrutineTimeInGame());
                          _variableCount._endCount = true;
                      }
                      _variableCount._Count++;
                  }
              }
          }
          private void ToRefreshPoints()
          {
              _pointsText.text = _inGameManager._countPoints + " /" + _inGameManager._countPointsMax;
          }
          IEnumerator CorrutineTimeInGame()
          {
              while(Time.timeScale == 1 && _inGameManager._countTime >= 0 )
              {   
                  if(OnReloadPoints != null)
                        OnReloadPoints();
                  yield return new WaitForSeconds(1);
                  _inGameManager._countTime--;
                  _taimerText.text =_inGameManager._countTime.ToString();

              }
          }

          private void ToWin()
          {
              if (_currentLevel > _settingsUIController._dataPlayer.m_nivel)
              {
                _settingsUIController._dataPlayer.m_nivel = _settingsUIController._dataPlayer.m_nivel + 1;
                 SceneManager.LoadScene(2);
              }
              else 
              { 
                  SceneManager.LoadScene(2);
              }
          }
          private void  ToPanelVictoris()
          {
              if(_inGameManager._winBool)
                    _victoryPanel.SetActive(true);  
                  
              if(_inGameManager._loseBool)
                    _defeatPanel.SetActive(true);
          }
          #endregion

    }

}
