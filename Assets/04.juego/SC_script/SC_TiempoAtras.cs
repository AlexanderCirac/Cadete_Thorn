using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_TiempoAtras : MonoBehaviour
{
  public SC_VelocidadGeneral SC_VG;
  public GameObject m_3;
  public GameObject m_2;
  public GameObject m_1;
  public GameObject m_panelTiempo;
  private float m_velocidad;
  [HideInInspector]
  public bool m_jugar;
  [HideInInspector]
  public int m_cambio;

  private void Start()
  {
    m_velocidad = SC_VG.m_velociadTiempo;
  }

  // Update is called once per frame
  void Update()
    {
    //TiempoAtras();
    Sprites();
    }
  void Sprites()
  {
    if(m_cambio != 4)
    {
      if (m_3.transform.localScale.x > 0.2)
      {
        m_3.transform.localScale = new Vector3(m_3.transform.localScale.x - m_velocidad * Time.deltaTime,
                                                m_3.transform.localScale.y - m_velocidad * Time.deltaTime,
                                                m_3.transform.localScale.z);
      }
      else
      {
        m_3.SetActive(false);
        m_2.SetActive(true);
        m_cambio = 2;
      }

      if (m_cambio == 2)
      {
        if (m_2.transform.localScale.x > 0.2)
        {
          m_2.transform.localScale = new Vector3(m_2.transform.localScale.x - m_velocidad * Time.deltaTime,
                                               m_2.transform.localScale.y - m_velocidad * Time.deltaTime,
                                               m_2.transform.localScale.z);
        }
        else
        {
          m_2.SetActive(false);
          m_1.SetActive(true);
          m_cambio = 3;
        }
      }

      if (m_cambio == 3)
      {
        if (m_1.transform.localScale.x > 0.2)
        {
          m_1.transform.localScale = new Vector3(m_1.transform.localScale.x - m_velocidad * Time.deltaTime,
                                               m_1.transform.localScale.y - m_velocidad * Time.deltaTime,
                                               m_1.transform.localScale.z);
        }
        else
        {
          m_1.SetActive(false);
          m_jugar = true;
          m_panelTiempo.SetActive(false);
          m_cambio = 4;
        }
      }
    }
  }
}
