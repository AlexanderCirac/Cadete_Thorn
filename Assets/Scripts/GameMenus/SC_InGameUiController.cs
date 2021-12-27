using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using C_Thorn.UI.Settings;

namespace C_Thorn.UI
{
    public class SC_InGameUiController : MonoBehaviour
    {

          #region Attributes
          [Header("Button")]
          [SerializeField] private Button _quitGame;
          [SerializeField] private Button _buttonMapaJuego;
          [SerializeField] private Button _buttonEnterPause;
          [SerializeField] private Button _buttonExitPause;
           private bool _flipFlopPauseGame = true;
          //Main Tools
          public SC_SettingsUIController _SettingsUIController;
          //Events
          public event Action<bool> OnPausaGame;
          private 
          #endregion

          #region UnityCalls
          void Start()
          {

              OnPausaGame += PausaGame;
              Time.timeScale = 1;
               //button onClick 
              _quitGame.onClick.AddListener(() => Application.Quit());
              _buttonMapaJuego.onClick.AddListener(() => SceneManager.LoadScene(2));
              _buttonEnterPause.onClick.AddListener(() => {
                if (OnPausaGame != null)
                {
                  OnPausaGame(_flipFlopPauseGame = !_flipFlopPauseGame);
                }
              });             
              _buttonExitPause.onClick.AddListener(() => {
             
                if (OnPausaGame != null)
                {
                  OnPausaGame(_flipFlopPauseGame = !_flipFlopPauseGame);
                }
              });
          }

          private void OnDestroy()
          {
              OnPausaGame -=  PausaGame;
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
                Debug.Log("Adios");

             
          }
          #endregion

    }

}
