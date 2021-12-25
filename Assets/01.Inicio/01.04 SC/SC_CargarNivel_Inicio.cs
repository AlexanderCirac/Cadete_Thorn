using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_CargarNivel_Inicio : MonoBehaviour
{
  public GameObject m_conjunto;
  public  float m_tiempo;
  private float  m_temporizador;
  private bool m_estado;


  private void Awake()
  {
    m_conjunto.SetActive(false);
  }
  // Update is called once per frame
  void Update()
    {
      if (m_estado == false)
      {
        Temporizador();
      }
    }

  void Temporizador()
  {
    if (m_temporizador < m_tiempo)
    {
      m_temporizador += Time.deltaTime;

    }
    else
    {
        m_estado = true;
        m_conjunto.SetActive(true);
    }
  }
  public void CargarMenuPrincipal()
  {
    if(m_estado == true)
    {
      Application.LoadLevel(1);
    }
  }
}
