using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MuerteJugador : MonoBehaviour
{
  //esta script es para indicar cuando el jugador a muerto al chocarse contra cualquier objeto enemigo.
  [HideInInspector]
  public bool m_muerto;
  [HideInInspector]
  public bool m_morirDeverdad;
  [HideInInspector]
  public bool m_MuerteDerrota;
  public GameObject m_PanelMensaje;
  public GameObject m_efectoMuerte;
  public Collider m_ColliderMuerte;
  public GameObject m_nave;
  public GameObject m_canvas;

  private void Update()
  {
    Muerte();
  }
  void Muerte()
  {
    if (m_muerto == true) {
      m_nave.SetActive(false);
      m_canvas.SetActive(false);
      m_ColliderMuerte.enabled = false;
      if (m_efectoMuerte.transform.localScale.y < 2.6)
      {
        m_efectoMuerte.SetActive(true);
        m_efectoMuerte.transform.localScale = new Vector3(m_efectoMuerte.transform.localScale.x+5.5f*Time.deltaTime,
        m_efectoMuerte.transform.localScale.y + 5.5f * Time.deltaTime, m_efectoMuerte.transform.localScale.z + 5.5f * Time.deltaTime);
      }
      else
      {
        m_efectoMuerte.SetActive(false);
      }
      Invoke("mensajeMuerte", 1f);
    }
  }
  public void Salir()
  {
    Application.Quit();
  }
  public void Reinciar(int m_nivel)
  {
    Application.LoadLevel(m_nivel);
  }
  public void MenuPrincipal()
  {
    Application.LoadLevel(1);
  }
  void mensajeMuerte()
  {
    if (m_MuerteDerrota)
    { 
      m_PanelMensaje.SetActive(true);
      m_morirDeverdad = true;
    }
  }
}
