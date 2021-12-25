using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_VelocidadGeneral : MonoBehaviour
{
  //esta script es para controlar todas las velocidades del los objetos
  [HideInInspector]
  public float m_velocidadObjetos;
  [HideInInspector]
  public float m_velociadTiempo;
  [HideInInspector]
  public float m_velociadDisparo;
  [HideInInspector]
  public float m_TiempoDesaparecerProyectil;
  public GameObject m_ObjetodRespawn;
  //[HideInInspector]
  public float m_velocidadRespawn;

  [HideInInspector]
  public bool m_cambiarVelocidad;
  public float m_temporizador;

  // Start is called before the first frame update
  void Start()
    {
    m_donce = true;
    }

    // Update is called once per frame
    void Update()
    {
        cambiarVelocidad();
    }

  private bool m_donce;
  void cambiarVelocidad()
  {
    if (m_cambiarVelocidad)
    {
      m_temporizador += 1 * Time.deltaTime;

      if (m_temporizador < 8)
      {//la nueva velocidad cuando coga el power up
        if (!m_donce)
        {
          m_ObjetodRespawn.SetActive(true);
          m_TiempoDesaparecerProyectil = 1;
          m_velocidadObjetos = 25;
          m_velocidadRespawn = 6;
          m_donce = true;
        }
        
      }
      else
      {
        m_cambiarVelocidad = false;
      }
    }
    else
    {//normalizar la velocidad cuando termine el powe up
      if (m_donce)
      {
        m_ObjetodRespawn.SetActive(false);
        m_velocidadObjetos = 15;
        m_temporizador = 0;
        m_TiempoDesaparecerProyectil = 2;
        m_velocidadRespawn = 5;
        m_donce = false;
      }
    }
  }
}
