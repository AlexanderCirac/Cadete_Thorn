using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Respawneador : MonoBehaviour
{
  //en esta script es para controlar el respaw de los objetos y respawneara objetos de forma aleatoria
  public SC_VelocidadGeneral SC_VG;
  public GameObject[] m_objetos;
  private float m_numeroRandom;
  public bool m_respawn;
  public float m_contador;
  private float m_velocidadContador;

  public bool m_respawnRobots;
  public float m_contadoRobots;

  //para respawn 2
  public bool m_2;
  public float m_delay;

    // Start is called before the first frame update
    void Start()
    {
     m_numeroRandom = m_objetos.Length;
    }

  // Update is called once per frame
  void Update()
    {
    
      Respawneador();
    }

  void Respawneador()
  {
    if (!m_respawn) {

      m_respawn = true;
      Instantiate(m_objetos[Mathf.FloorToInt(Random.Range(0f, m_numeroRandom))], this.transform.position, Quaternion.identity);
      m_contador = 0;
    }
    else
    {
      if (!m_respawnRobots)
      {
        if (m_contador < 7.5f)
        {
          if (!m_2)
          {
          m_contador += SC_VG.m_velocidadRespawn * Time.deltaTime;
          }
          else
          {
            m_contador += (SC_VG.m_velocidadRespawn - m_delay) * Time.deltaTime;
          }
        }
        else
        {
          m_respawn = false;
        }
      }
      else
      {
        if (m_contador < m_contadoRobots)
        {
          if (!m_2)
          {
            m_contador += SC_VG.m_velocidadRespawn * Time.deltaTime;
          }
          else
          {
            m_contador += (SC_VG.m_velocidadRespawn - m_delay) * Time.deltaTime;
          }
        }
        else
        {
          m_respawn = false;
        }
      }
    }
  }
}
