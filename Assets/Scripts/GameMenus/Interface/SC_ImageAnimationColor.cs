using UnityEngine.UI;
using UnityEngine;

namespace C_Thorn.UI.Animations
{
    public class SC_ImageAnimationColor : MonoBehaviour
    {
        #region Attributes
        [Header("Control Animation")]
        [SerializeField] float _randomLength = 0;
        [SerializeField] float _speedAnimation = 0.0f;
        #endregion

        #region UnityCalls
        private void Update()=> ToColorAnimation();
        #endregion

        #region Custom Private Methods
        void ToColorAnimation() => GetImage.color = new Color(0,176,178, (GetColorBase - (Mathf.PingPong(Time.time * _speedAnimation, GetRandomLength) - 0.5f * GetRandomLength)));

        Image GetImage
        {
            get => this.GetComponent<Image>();
        }           
        float GetColorBase
        {   
            get => GetImage.color.a;
        }          
        float GetRandomLength
        {
            get => UnityEngine.Random.Range(0.5f, _randomLength);
        }
        #endregion
    }
}
