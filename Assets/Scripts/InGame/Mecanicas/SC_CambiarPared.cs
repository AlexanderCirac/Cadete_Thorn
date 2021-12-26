using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CambiarPared : MonoBehaviour
{
  //esto script es para que desaparezcan los objetos la primera es para que sea random y la segunda es para que se vaya intercalando cuando una se apaga
  //la otra se enciena
  
  
  
  
  
  
    // Start is called before the first frame update
    void Start()
    {
      //m_tiempo = 1; /// parte 1
    }

    // Update is called once per frame
    void Update()
    {
    //parte 1
    //TiempoRandom();
    //Activar_Desactivar();

    //parte 2
    tiempocontador();
    Intercambio();
    tiempoRando();
    Animacion();
    }

  ///Parte 1//////////////////////////////////////////////
  //private float m_tiempo;
  //private float m_tiemporandom;
  //public float m_numeroMax;
  //public GameObject m_pared;
  //private bool m_primerTiempo;
  //private bool m_segundoTiempo;
  //void TiempoRandom()
  //{//Elejimos un numero random para el tiempo que estara activada las cosas
  //  if (!m_primerTiempo)
  //  {
  //    m_tiemporandom = Random.Range(3, m_numeroMax); // el maximo que ha de superar el contador del tiempo
  //    m_tiempo = 0; // se inicializa el contador a 0
  //    m_primerTiempo = true; // activamos el contador de tiempo que estara abrir la puerta
  //    m_segundoTiempo = false; // activamos el contado del tiempo que estara cerrada
  //  }
  //}

  //void Activar_Desactivar()
  //{
  //  if (m_tiempo < m_tiemporandom && m_primerTiempo == true && !m_segundoTiempo)
  //  {
  //    m_tiempo += 1 *Time.deltaTime;
  //    m_pared.SetActive(false); // abrir  puerta
  //  }
  //  else
  //  {
  //    m_segundoTiempo = true;
  //    if ( 0.5f < (m_tiempo /3))
  //    {
  //      m_tiempo -=  1 *Time.deltaTime;
  //      m_pared.SetActive(true); // cerrar puerta
  //    }
  //    else
  //    {
  //      m_primerTiempo = false;
  //    }
  //  }


  ///Parte 2///////////////////////////////////
  ///
  //aqui creamos un numero random que difiniara el tiempo que tardara de cambiar de un lado a otro
  public float m_tiempoMax;
  private float m_tiempoRandom;
  private bool m_DoOnce;
    void tiempoRando()
    {
      if (!m_DoOnce)
      {
        m_tiempoRandom = Random.Range(2, m_tiempoMax);
        m_DoOnce = true;
      }
    }

  //aqui es donde indicara que objeto se tiene que activar o desactivar
  private bool m_intercambio;
  private int m_ID;
  public GameObject m_cubo1;
  public GameObject m_cubo2;
  private float m_tiempo;
    void Intercambio()
    {

      if (!m_intercambio && m_ID == 0)
      {
          m_ID = 1;
        m_cubo1.SetActive(true);
        m_cubo2.SetActive(false);
      }     
    if (m_intercambio && m_ID == 1)
      {
          m_ID = 0;
        m_cubo1.SetActive(false);
        m_cubo2.SetActive(true);
      }
    }

//este controlara el contador que inidicara cuando cambiar de lado
    void tiempocontador()
    {

      if (m_ID == 1)
      {
      m_tiempo += 1 * Time.deltaTime;
        if (m_tiempo > m_tiempoMax)
        {
          m_intercambio = true;
        }
      }      
      if (m_ID == 0)
      {
      m_tiempo -= 1 * Time.deltaTime;
        if (m_tiempo < 0)
        {
          m_intercambio = false;
        }
      }
    }

 
  //esto es para que realice una animacion de parpadeo el lado que le toque por via script

    void Animacion()
    {
    if (m_ID == 1)
    {
      if (m_tiempo > ((m_tiempoMax * 70)/100) && m_tiempo < ((m_tiempoMax * 80) / 100))
      {
        m_cubo1.SetActive(false);
      } 
      if (m_tiempo > ((m_tiempoMax * 80)/100) && m_tiempo < ((m_tiempoMax * 90) / 100))
      {
        m_cubo1.SetActive(true);
      }     
     if (m_tiempo > ((m_tiempoMax * 90)/100) && m_tiempo < ((m_tiempoMax * 95) / 100))
      {
        m_cubo1.SetActive(false);
      }
      if (m_tiempo > ((m_tiempoMax * 95) / 100) && m_tiempo < ((m_tiempoMax * 98) / 100))
      {
        m_cubo1.SetActive(true);
      }
    }
    if (m_ID == 0)
    {
      if (m_tiempo < ((m_tiempoMax * 30) / 100) && m_tiempo > ((m_tiempoMax * 20) / 100))
      {
        m_cubo2.SetActive(false);
      }
      if (m_tiempo < ((m_tiempoMax * 20) / 100) && m_tiempo > ((m_tiempoMax * 10) / 100))
      {
        m_cubo2.SetActive(true);
      }
      if (m_tiempo < ((m_tiempoMax * 10) / 100) && m_tiempo > ((m_tiempoMax * 5) / 100))
      {
        m_cubo2.SetActive(false);
      }
      if (m_tiempo < ((m_tiempoMax * 5) / 100) && m_tiempo > ((m_tiempoMax * 3) / 100))
      {
        m_cubo2.SetActive(true);
      }
    }
  }
  }

