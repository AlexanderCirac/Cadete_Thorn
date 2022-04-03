using UnityEngine.UI;
using UnityEngine;

namespace C_Thorn.UI.Animations
{
      public class SC_ImageAnimationColor : MonoBehaviour
      {
          #region Attributes
          float _colorBase = 0;
          [Header("Control Animation")]
          [SerializeField] float _randomLength = 0;
          [SerializeField] float _speedAnimation = 0.0f;
          #endregion

          #region UnityCalls
          private void Awake()
          {
                //get color A
                _colorBase = GetImage.color.a;
          }
          private void Update()
          {
              ToColorAnimation();
          }
          #endregion

          #region Methods
          private void ToColorAnimation()
          {
                GetImage.color = new Color(0,176,178, (_colorBase - (Mathf.PingPong(Time.time * _speedAnimation, GetRandomLength) - 0.5f * GetRandomLength)));
          }
          private Image GetImage
          {
              get => this.GetComponent<Image>();
          }          
          private float GetRandomLength
          {
              get => UnityEngine.Random.Range(0.5f, _randomLength);
          }
          #endregion
      }

}
