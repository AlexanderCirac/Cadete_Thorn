using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Disparar : MonoBehaviour
{
  //esta script es para indicar cuando el jugador disparar y controlara la veces que dispara
  public GameObject m_bala;
  public GameObject m_disparador;

  private void Start()
  {
  //  m_sonido.SetActive(false);
  }
  void Update()
  {
    ControlarDisparo();
    SonidoDisparar();
    if(m_m1)
    Invoke("pararsonido", 1f);
  }
  public void Disparar()
  {
    if (m_disparo)
    {
      Instantiate(m_bala, m_disparador.transform.position, Quaternion.identity);
      m_tiempo = 0;
      m_m1 = true;
      m_disparo = false;
    }
    //if (Input.GetKey(KeyCode.E) && m_disparo)
    //{
    //  Instantiate(m_bala, m_disparador.transform.position, Quaternion.identity);
    //  m_tiempo = 0;
    //  m_disparo = false;
    //}
  }

  private float m_tiempo;
  private float m_velocidadTiempo;
  public bool m_disparo;
  void ControlarDisparo()
  {
    if (!m_disparo)
    {
      m_velocidadTiempo = 20;
      m_tiempo += m_velocidadTiempo * Time.deltaTime;
      ;
      if (m_tiempo > 10)
      {
        m_disparo = true;
      }
    }
  }

  public GameObject m_sonido;
  private bool m_m1;
  void SonidoDisparar()
  {
    if (m_sonido != null)
    {

      if (!m_disparo)
      {
        if (m_m1)
        {
        m_sonido.SetActive (true);

        }
      }
      else
      {
        if (!m_m1)
        {
        m_sonido.SetActive (false);
        }
      }
    }
  }

  void pararsonido()
  {
    m_m1 = false;
  }
}
