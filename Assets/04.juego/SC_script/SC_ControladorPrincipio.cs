using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ControladorPrincipio : MonoBehaviour
{
  
  //esta script es para controlar el comeinzo del juego

  private bool m_SegundaFase;
  private bool m_TerceraFase;
  //esto es para cuando muera el jugador
  public SC_MuerteJugador SC_MJ;
  public SC_ControlVictoria SC_CJ;
  public GameObject m_canvas;

  //controlar velocidad
  public GameObject m_obstaculos;

  //para pasar de la primera fase
  public bool m_pasarPrimeraFase;

  // Start is called before the first frame update
  void Start()
    {
    
    PimeraFase();
    }

    // Update is called once per frame
    void Update()
    {
      if (SC_MJ.m_muerto == false && SC_CJ.m_victoria == false) {
        SegundoFase();
        TerceraFase();
        QuartaFase();
      }
      else
      {
        PararTiempo();
      }
    }

  void PimeraFase()
  {
    //primera fase del comienzo
    Time.timeScale = 0;
    this.GetComponent<SC_Controlador_Menu_Pausa>().enabled = false;
    this.GetComponent<SC_TiempoAtras>().enabled = false;
    this.GetComponent<SC_Temporizador>().enabled = false;
    m_obstaculos.SetActive(false);
    if (m_pasarPrimeraFase) { 
      this.GetComponent<SC_Texto_Tutorial>().m_empezar = true;
    }
  }

  void SegundoFase()
  {
    if( this.GetComponent<SC_Texto_Tutorial>().m_empezar == true && !m_SegundaFase)
    {
      Time.timeScale = 1;
      this.GetComponent<SC_TiempoAtras>().enabled = true;
      m_SegundaFase = true;
    }


  }

  void TerceraFase()
  {
    if (this.GetComponent<SC_TiempoAtras>().m_jugar == true && !m_TerceraFase)
    {
      this.GetComponent<SC_Controlador_Menu_Pausa>().enabled = true;
      this.GetComponent<SC_Temporizador>().enabled = true;
      m_TerceraFase = true;
    }
  }

  void QuartaFase()
  {
    if (this.GetComponent<SC_TiempoAtras>().m_cambio == 4)
    {
      m_obstaculos.SetActive(true);
      Time.timeScale = 9;
      this.GetComponent<SC_TiempoAtras>().enabled = false;
    }
  }

  void PararTiempo()
  {
    if (SC_MJ.m_morirDeverdad || SC_CJ.m_victoria)
    {

      this.GetComponent<SC_Controlador_Menu_Pausa>().enabled = false;
      Time.timeScale = 0;
      m_canvas.SetActive(false);
    }
  }
}
