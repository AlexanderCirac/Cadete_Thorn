using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace C_Thorn.InGame.Controller
{
    using C_Thorn.Tools.Enums;
    using AlexanderCA.Tools.Generics;
    public class GameController : MonoBehaviour
    {
        #region Attributes
        [Header("Variables Victory")]
        private     Enums_StateGame _state;
        private     int             _currentPoints;
        public      int             _maxPoints;
        public int Puntos
        {
            get { return _currentPoints; }
            set
            {
                _currentPoints = value;
                if ( _currentPoints > _maxPoints )
                    EndingGame();
            }
        }
        [SerializeField] GameObject _panelVictory;
        public Enums_StateGame _stateGame
        {
            get { return _state; }
            set
            {
                _state = value;
                switch ( value )
                {
                    case Enums_StateGame.none:
                        break;
                    case Enums_StateGame.NormalSpeed:
                        NormalSpeed();
                        break;
                    case Enums_StateGame.FastSpeed:
                        StartCoroutine(_SpeedTimeScale());
                        break;
                    case Enums_StateGame.Victory:
                        _victoryButton.gameObject.SetActive(true);
                        EndingGame();
                        break;
                    case Enums_StateGame.Deffet:
                        _defeatButton.gameObject.SetActive(true);
                        EndingGame();
                        break;
                    default:
                        break;
                }
            }
        }
        public static GameController Instance
        {
            get
            {
                return ToolsAlex.SingletonGeneric<GameController>.Instance;
            }
        }
        [Header("Variables endings")]
        [SerializeField]    Button  _victoryButton;
        [SerializeField]    Button  _defeatButton;
        #endregion

        #region private custom method
        IEnumerator _SpeedTimeScale()
        {
            yield return new WaitForSeconds(0.1f);
            Time.timeScale = 2;
            yield return new WaitForSeconds(5f);
            Time.timeScale = 1;
            _state = Enums_StateGame.NormalSpeed;
        }
        void NormalSpeed()
        {
            Time.timeScale = 1;
        }
        void EndingGame()
        {
            _panelVictory.SetActive(true);
            Time.timeScale = 0;
        }
        #endregion
    }
}
