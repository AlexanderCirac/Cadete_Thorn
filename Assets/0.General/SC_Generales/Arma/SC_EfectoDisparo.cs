using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EfectoDisparo : MonoBehaviour
{
  public GameObject m_efecto;
  private float m_tiempo;
  private bool m_paso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    cerrarDisparo();
    ControlarDisparo();
    }

  public void DispararEfecto()
  {
    if (m_disparo)
    {
    m_paso = true;
    m_efecto.SetActive(true);
    m_tiempo = 1;
    m_tiempo1 = 0;
      m_disparo = false;
    }
  }

  void cerrarDisparo()
  {
    if (m_paso)
    {
      if (m_tiempo > 0.2f)
      {
        m_tiempo -= 12f * Time.deltaTime;
      }
      else
      {
        m_tiempo = 0;
        m_efecto.SetActive(false);
        m_paso = false;
      }
    }
  }

  private float m_velocidadTiempo;
  private bool m_disparo;
  private float m_tiempo1;
  void ControlarDisparo()
  {
    if (!m_paso && !m_disparo)
    {
      m_velocidadTiempo = 20;
      m_tiempo1 += m_velocidadTiempo * Time.deltaTime;

      if (m_tiempo1 > 9)
      {
        m_disparo = true;
      }
    }
  }
}
