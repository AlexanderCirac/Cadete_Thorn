using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_Animacion_Botones : MonoBehaviour
{

  public Image m_boton;
  public float m_velocidad;
  public bool m_cambiarSentido;

  private float m_tiempo;
  private int m_idRandom;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //random();
    Animacion();
    //m_boton.color = new Color (0, 176, 178, m_boton.GetComponent<Image>().color.a + m_velocidad * Time.deltaTime);
  }

  void Animacion()
  {
  
    if (m_cambiarSentido == false)
    {
      if (m_boton.color.a <= 0.85)
      {
        //m_boton.color = new Vector4(0, 176, 178, m_boton.color.a - m_velocidad *Time.deltaTime);
        m_boton.color = new Color(0,176,178, m_boton.color.a + m_velocidad*Time.deltaTime);
      }
      else
      {
        m_cambiarSentido = true;
      }
    }
    else
    {
      if (m_boton.color.a >= 0.35)
      {
        //m_boton.color = new Vector4(0, 176, 176, m_boton.color.a + m_velocidad * Time.deltaTime);
        m_boton.color = new Color(0, 176, 178, m_boton.color.a - m_velocidad * Time.deltaTime);
      }
      else
      {
        m_cambiarSentido = false;
      }
    }
  }
}
