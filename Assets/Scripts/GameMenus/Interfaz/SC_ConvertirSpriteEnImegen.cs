using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_ConvertirSpriteEnImegen : MonoBehaviour
{
  //esto es para convertir un sprite en imegen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Conversor();
    }

  public Image m_imagen;
  public SpriteRenderer m_sprite;
  void Conversor()
  {
    m_imagen.sprite = m_sprite.sprite;
  }
}
