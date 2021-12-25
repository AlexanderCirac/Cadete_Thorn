using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ControlarVelocidadSegunResolucion : MonoBehaviour
{

  //esta script es para modificar la velocidad de que tiene los respawns cuando van de un lateral a otro


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CalcularDistancia();
        RetocarVelocidad();
        RetocarRespawn();
    }


  public GameObject m_res1;
  public GameObject m_res2;
  void RetocarVelocidad()
  {
    if (m_posX < 16)
    {
      m_res1.GetComponent<SC_LadoALado>().m_velocidad = 25;
      m_res2.GetComponent<SC_LadoALado>().m_velocidad = 25;
    }if (m_posX > 20 && m_posX < 72)
    {
      m_res1.GetComponent<SC_LadoALado>().m_velocidad = 40;
      m_res2.GetComponent<SC_LadoALado>().m_velocidad = 40;
    }
    if (m_posX > 72)
    {
      m_res1.GetComponent<SC_LadoALado>().m_velocidad = 60;
      m_res2.GetComponent<SC_LadoALado>().m_velocidad = 60;
    }
  }

  public GameObject m_ladoIzq;
  public GameObject m_ladoDer;
  private float m_posX;
  void CalcularDistancia()
  {
    m_posX = ((m_ladoDer.transform.position.x  - m_ladoIzq.transform.position.x)/2);
  }

  //en esta parte tocaremos la velocidad de respawneao de los objetos segun la resolucion
  public SC_VelocidadGeneral SC_VG;
  void RetocarRespawn()
  {
    if (m_posX < 16)
    {
      if (SC_VG.m_cambiarVelocidad)
      {
        SC_VG.m_velocidadRespawn = 6;
      }
      else
      {
        SC_VG.m_velocidadRespawn = 5;
      }
    }
    if (m_posX > 20 && m_posX < 72)
    {
      if (SC_VG.m_cambiarVelocidad)
      {
        SC_VG.m_velocidadRespawn = 10;
      }
      else
      {
        SC_VG.m_velocidadRespawn = 8;
      }
    }
    if (m_posX > 72)
    {
      if (SC_VG.m_cambiarVelocidad)
      {
        SC_VG.m_velocidadRespawn = 13;
      }
      else
      {
        SC_VG.m_velocidadRespawn = 10;
      }
    }
  }
}
