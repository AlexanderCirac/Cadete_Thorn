using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Controlador_Menu_Pausa : MonoBehaviour
{

  //esta scritp es para controlar el menu de pausa del juego

  private bool m_AbrirMenu;

  public GameObject m_interfazJuego;
  public GameObject m_menuPausa;
  public GameObject m_menuOpciones;

  private void Update()
  {
    MenuPausa();
  }

  public void AbrirMenuPausa()
  {

      m_AbrirMenu = true;
    
  }

  public void CerrarMenuPausa()
  {

    m_AbrirMenu = false;

  }

  public void CerrarMenuOpciones()
  {
    m_menuOpciones.SetActive(false);
  }

  public void Salir()
  {
    Application.Quit();
  }

  public void AbrirMenuOpciones()
  {
    m_menuOpciones.SetActive(true);
  }
  void MenuPausa()
  {
    if (m_AbrirMenu)
    {
      m_menuPausa.SetActive(true);
      m_interfazJuego.SetActive(false);
      Time.timeScale = 0;
    }
    else
    {
      m_menuPausa.SetActive(false);
      m_interfazJuego.SetActive(true);
      Time.timeScale = 1;
    }
  }
}
