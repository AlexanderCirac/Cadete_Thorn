using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;

namespace C_Thorn.UI.Animations
{
      public class SC_ImageAnimationColor : MonoBehaviour
      {
          #region Attributes
          private Image _imageAnimation;
          [Header("Float")]
          [SerializeField] private float _speedAnimation = 0.0f;
          private bool _activateChange = false;
          private bool _activateCorrutine = false;
          //events
          public event Action OnAnimationColor;
          #endregion

          #region UnityCalls
          // Start is called before the first frame update
          void Start()
          {
              //get Image
              _imageAnimation = this.GetComponent<Image>();
              //events
              OnAnimationColor += ImageAnimation;
              //Initialize
              StartCoroutine(nameof(CorrutineAnimation));
          }

          private void OnDestroy()
          {
              OnAnimationColor += ImageAnimation;
              _activateCorrutine = true;
          }
          #endregion

          #region Methods
          IEnumerator CorrutineAnimation()
          {
               while(!_activateCorrutine)
               {
                   if(OnAnimationColor != null)
                     OnAnimationColor();
                  yield return null;
               }   
                  
          }
          void ImageAnimation()
          {
  
              if (_activateChange == false)
              {
                  if (_imageAnimation.color.a <= 0.85)
                  {
                    _imageAnimation.color = new Color(0,176,178, _imageAnimation.color.a + _speedAnimation*Time.deltaTime);
                  }
                  else
                  {
                    _activateChange = true;
                  }
              }
              else
              {
                  if (_imageAnimation.color.a >= 0.35)
                  {
                    _imageAnimation.color = new Color(0, 176, 178, _imageAnimation.color.a - _speedAnimation * Time.deltaTime);
                  }
                  else
                  {
                    _activateChange = false;
                  }
              }
          }
          #endregion
      }

}
