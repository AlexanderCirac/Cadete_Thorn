using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_menuNivel : MonoBehaviour
{

  //esta script es para poder controlar el boton de menú en el nivel

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public GameObject m_menuPausa;

  public void Abrir()
  {
    m_menuPausa.SetActive(true);
  }

  public void Cerrar()
  {
    m_menuPausa.SetActive(false);
  }  
  public void MenuJuego(int m_nivel)
  {
    Application.LoadLevel(m_nivel);
  }

  public GameObject m_ocpiones;
  public void ActivarOpciones()
  {
    m_ocpiones.SetActive(true);
  } 
  public void DesactivarOpciones()
  {
    m_ocpiones.SetActive(false);
  }
}
