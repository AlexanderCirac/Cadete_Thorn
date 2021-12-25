using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PreguntaSalir : MonoBehaviour
{
  //esta script es para controlar la opcion de salir, haciendo una pregunta previa
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public GameObject m_pregunta;
  public GameObject m_menu;
  public void Pregunta()
  {
    m_pregunta.SetActive(true);
    if (m_menu != null)
    {
      m_menu.SetActive(false);
    }
  }

  public void CerrarPregunta()
  {
    m_pregunta.SetActive(false);
    if (m_menu != null)
    { 
    m_menu.SetActive(true);
    }
  }

  public void Salir()
  {
    Application.Quit();
  }
}
