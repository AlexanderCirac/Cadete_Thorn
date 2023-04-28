using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace C_Thorn.InGame.IA
{

    using C_Thorn.Tools.Templates;
    public class WallChaleng : BaseAI
    {

        #region Attributes
        [Header("Change Walls")]
        [SerializeField] GameObject _wall1;
        [SerializeField] GameObject _wall2;
        //Animation Blink Walls
        [Header("Blink Walls")]
        [SerializeField] float  _timeBlink, _saveTimeBlink;
        int  _iDWall = 1;
        #endregion

        #region UnityCalls
        void Start() => StartUp();
        #endregion

        #region custom private Methods
        void StartUp()
        {         
            StartCoroutine(CorrutineFlipFlopWalls());
        }
        IEnumerator CorrutineFlipFlopWalls()
        {
            while ( SceneManager.GetActiveScene().isLoaded )
            {
                yield return new WaitForSeconds(_timeBlink);
                _timeBlink = _timeBlink < 0.1f ? _saveTimeBlink : _timeBlink -= ( ( _timeBlink * 20 ) / 100 );
                if ( _timeBlink == _saveTimeBlink )
                    ToFlipFlopWalls = !ToFlipFlopWalls;
                else
                    ToBlinkWalls();

            }
        }
        bool ToFlipFlopWalls
        {
            get => ToFlipFlopWalls = false;
            set
            {
                switch ( value )
                {
                    case false:
                        _wall1.SetActive(!_wall1.activeSelf);
                        _wall2.SetActive(true);
                        _iDWall = 1;
                        return;
                    case true:
                        _wall1.SetActive(true);
                        _wall2.SetActive(!_wall2.activeSelf);
                        _iDWall = 2;
                        return;
                }
            }
        }
        void ToBlinkWalls()
        {
            switch ( _iDWall )
            {
                case 1:
                    _wall1.SetActive(!_wall1.activeSelf);
                    return;
                case 2:
                    _wall2.SetActive(!_wall2.activeSelf);
                    return;
            }
        }
        #endregion
    }
}
