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
              public string _nameButtonQuiGamet;
              public Button _buttonQuit;
          }
          [Header("Button")]
          [SerializeField] private ButtonQuitsGame[] _buttonsQuit;              
          [System.Serializable]
          public class ButtonLoadLevel
          { 
              public string _nameLoadLevel;
              public Button _buttonLoad;
              public int _intLevelToLoad;
          }
          [SerializeField] private ButtonLoadLevel[] _buttonLoadLevel;         
          [SerializeField] private Button _buttonEnterPause;
          [SerializeField] private Button _buttonExitPause;
          [SerializeField] private Button _buttonVictory;
          [Header("Int")]
          [SerializeField] private int _currentLevel;
          [Header("Text")]
          [SerializeField] private Text _textPoints;
          [SerializeField] private Text _textTaimer;    
          [Header("Panels")]
          [SerializeField] private GameObject _panelVictory;
          [SerializeField] private GameObject _panelDefeat;
          private bool _flipFlopPauseGame = true;
          [System.Serializable] public class VariableTutoLevel 
          {
              public Button _buttonTuto;
              public GameObject _panelTuto;
              public GameObject _panelCountDown;
          }
          [Header("Variable Tuto Level")]
          [SerializeField] private VariableTutoLevel _variableTuto;
          [System.Serializable] public class VariableCountDown 
          {
              public GameObject[] _panelNumer;
              public GameObject _panelCount;
              [HideInInspector]public bool _endCorrutineCount = false;
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
              OnPausaGame += PausaGame;
              OnReloadPoints += ReloadPointsCount;
              
              if(OnReloadPoints != null)
              {
                  OnReloadPoints();
              }

              //button onClick 
              int _raidButtonQuit = 1, a = 0, b = 0, c= 0;
              for (; _raidButtonQuit <= _buttonsQuit.Length; _raidButtonQuit++)
              {
                  _buttonsQuit[_raidButtonQuit - 1]._buttonQuit.onClick.AddListener(() => Application.Quit() );
              }              
              int _raidButtonLoadLevel= 1, e = 0, h = 0, i= 0;
              for (; _raidButtonLoadLevel <= _buttonLoadLevel.Length; _raidButtonLoadLevel++)
              {
                  int _count = _raidButtonLoadLevel;
                  _buttonLoadLevel[_raidButtonLoadLevel - 1]._buttonLoad.onClick.AddListener(() => SceneManager.LoadScene(_buttonLoadLevel[_count-1]._intLevelToLoad) );
              }
              _buttonEnterPause.onClick.AddListener(() => 
              {
                  if (OnPausaGame != null)
                  {
                      OnPausaGame(_flipFlopPauseGame = !_flipFlopPauseGame);
                  }
              });             
              _buttonExitPause.onClick.AddListener(() => 
              {
             
                  if (OnPausaGame != null)
                  {
                      OnPausaGame(_flipFlopPauseGame = !_flipFlopPauseGame);
                  }
              });
              _buttonVictory.onClick.AddListener (() => Win());

              //start to game
              if(_variableTuto._buttonTuto != null)
              { 
                  Time.timeScale = 0;
                  _variableTuto._buttonTuto.onClick.AddListener(StartTutoLevel);
              }
              else
              {
                  Time.timeScale = 1;
                   _variableCount._panelCount.SetActive(true);
                  StartCoroutine(CorrutineCountDown());
              }
              _textTaimer.text =_inGameManager._countTime.ToString();

          }

          private void OnDestroy()
          {
              OnPausaGame -=  PausaGame;
              OnReloadPoints -= ReloadPointsCount;
          }

          private void Update()
          {
              ActivatePanelVictoris();
          }
          #endregion

          #region Methods
          private void PausaGame(bool coso)
          {
              if(!coso)
              {
                  Time.timeScale = 1;
              }
              else
                  Time.timeScale = 0;
          }          
          private void StartTutoLevel()
          {
              if(_variableTuto._panelTuto != null)
                  _variableTuto._panelTuto.SetActive(false);

              if(_variableTuto._panelCountDown != null)
                  _variableTuto._panelCountDown.SetActive(true);

              Time.timeScale = 1;
              StartCoroutine(CorrutineCountDown());
          }        
          IEnumerator CorrutineCountDown()
          {
            while (!_variableCount._endCorrutineCount)
            {   
                StartCountDown();
                yield return null;
            }
          } 
          public  void StartCountDown()
          {
              int i = _variableCount._Count;
              if(i <= _variableCount._panelNumer.Length)
              {   
                    GameObject _objetoToScale = _variableCount._panelNumer[i - 1];
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
                      if (i == _variableCount._panelNumer.Length)
                      {
                          _variableCount._panelCount.SetActive(false);
                          _inGameManager._startToGame = true;
                          StartCoroutine(CorrutineTimeInGame());
                          _variableCount._endCorrutineCount = true;
                      }
                      _variableCount._Count++;
                  }
              }
          }
          private void ReloadPointsCount()
          {
              _textPoints.text = _inGameManager._countPoints + " /" + _inGameManager._countPointsMax;
          }
          IEnumerator CorrutineTimeInGame()
          {
              while(Time.timeScale == 1 && _inGameManager._countTime >= 0 )
              {   
                  if(OnReloadPoints != null)
                        OnReloadPoints();
                  yield return new WaitForSeconds(1);
                  _inGameManager._countTime--;
                  _textTaimer.text =_inGameManager._countTime.ToString();

              }
          }

          private void Win()
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
          private void  ActivatePanelVictoris()
          {
              
              if(_inGameManager._winGame)
                    _panelVictory.SetActive(true);  
                  
              if(_inGameManager._endGame)
                    _panelDefeat.SetActive(true);
             
          }
          #endregion
  }

}
