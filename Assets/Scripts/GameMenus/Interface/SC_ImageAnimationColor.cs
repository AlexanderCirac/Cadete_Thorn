using UnityEngine.UI;
using UnityEngine;

namespace C_Thorn.UI.Animations
{
      public class SC_ImageAnimationColor : MonoBehaviour
      {
          #region Attributes
          private Image _image;
          [SerializeField] private float _colorBase = 0;
          [SerializeField] private float _randomLength = 0;
          private float _length = 0;
          [Header("Float")]
          [SerializeField] private float _speedAnimation = 0.0f;
          #endregion

          #region UnityCalls
          private void Awake()
          {
                //get Image
                _image = this.GetComponent<Image>();
                //get color
                _colorBase = _image.color.a;
          }
          private void Start()
          {
                _length = UnityEngine.Random.Range(0.5f, _randomLength);
          }

          private void Update()
          {
              ToColorAnimation();
          }
          #endregion

          #region Methods
          private void ToColorAnimation()
          {
                _image.color = new Color(0,176,178, (_colorBase - (Mathf.PingPong(Time.time * _speedAnimation, _length) - 0.5f * _length)));
          }
          #endregion
      }

}
