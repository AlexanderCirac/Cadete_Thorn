using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MenuPrincipal : MonoBehaviour
{
  //en este script controlaremos el menu para activar los paneles.
  public GameObject m_PanelMenu;
  public GameObject m_PaneOpciones;
  public GameObject m_PanelCreditos;
  private int m_IDPanel;


  public void jugar()
  {
    Application.LoadLevel(2);
  }

  public void Opciones()
  {
    if(m_IDPanel != 1)
    {
      m_PanelMenu.SetActive(false);
      m_PaneOpciones.SetActive(true);
      m_PanelCreditos.SetActive(false);
      m_IDPanel = 1;
    }
  }


  public void Creditos()
  {
    if (m_IDPanel != 2)
    {
      m_PanelMenu.SetActive(false);
      m_PaneOpciones.SetActive(false);
      m_PanelCreditos.SetActive(true);
      m_IDPanel = 2;
    }
  }

  public void Menu()
  {
    if (m_IDPanel != 3)
    {
      m_PanelMenu.SetActive(true);
      m_PaneOpciones.SetActive(false);
      m_PanelCreditos.SetActive(false);
      m_IDPanel = 3;
    }
  }

  public void Salir()
  {
    Application.Quit();
  }
  public void atras()
  {
    if (m_IDPanel != 4)
    {
      m_PanelMenu.SetActive(true);
      m_PaneOpciones.SetActive(false);
      m_PanelCreditos.SetActive(false);
      m_IDPanel = 4;
    }
  }
}
