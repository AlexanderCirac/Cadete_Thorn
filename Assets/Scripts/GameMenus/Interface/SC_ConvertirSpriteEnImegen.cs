using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace C_Thorn.UI
{
    public class SC_ConvertSpriteToImage: MonoBehaviour
    {
          #region Attributes
          [SerializeField] private Image m_imagen;
          [SerializeField] private SpriteRenderer m_sprite;
           private bool _endCorrutine;
          #endregion

          #region UnityCalls
          // Start is called before the first frame update
          void Start()
          {
             StartCoroutine(CorrutineConvert());
          }
          private void OnDestroy()
          {
              _endCorrutine = true;
          }
          #endregion    
    
          #region Methods
          IEnumerator CorrutineConvert()
          {
              while (!_endCorrutine)
              {
                  m_imagen.sprite = m_sprite.sprite;
                  yield return null;
              }
          }          
       
          #endregion
    }

}
