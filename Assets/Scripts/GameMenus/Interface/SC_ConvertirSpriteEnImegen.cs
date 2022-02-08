using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace C_Thorn.UI
{
    public class SC_ConvertSpriteToImage: MonoBehaviour
    {
          #region Attributes
          [SerializeField] private Image _imagen;
          [SerializeField] private SpriteRenderer _sprite;
          #endregion

          #region UnityCalls
          // Start is called before the first frame update
          void Update()
          {
              _imagen.sprite = _sprite.sprite;
          }
          #endregion    
    }

}
