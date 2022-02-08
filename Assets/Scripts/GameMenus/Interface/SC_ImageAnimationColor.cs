using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;

namespace C_Thorn.UI.Animations
{
      public class SC_ImageAnimationColor : MonoBehaviour
      {
          #region Attributes
          private Image _image;
          [Header("Float")]
          [SerializeField] private float _speedAnimation = 0.0f;
          private bool _flipFlopAnimation = false;
          //events
          public event Action OnAnimationColor;
          #endregion

          #region UnityCalls
          // Start is called before the first frame update
          void Start()
          {
              //get Image
              _image = this.GetComponent<Image>();
              //events
              OnAnimationColor += ToColorAnimation;
          }

          private void Update()
          {
                   if(OnAnimationColor != null)
                     OnAnimationColor();      
          }
          private void OnDestroy()
          {
              OnAnimationColor -= ToColorAnimation;
          }
          #endregion

          #region Methods
          private void ToColorAnimation()
          {
  
              if (_flipFlopAnimation == false)
              {
                  if (_image.color.a <= 0.85)
                  {
                    _image.color = new Color(0,176,178, _image.color.a + _speedAnimation*Time.deltaTime);
                  }
                  else
                  {
                    _flipFlopAnimation = true;
                  }
              }
              else
              {
                  if (_image.color.a >= 0.35)
                  {
                    _image.color = new Color(0, 176, 178, _image.color.a - _speedAnimation * Time.deltaTime);
                  }
                  else
                  {
                    _flipFlopAnimation = false;
                  }
              }
          }
          #endregion
      }

}
