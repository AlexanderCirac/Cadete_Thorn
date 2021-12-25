using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Paneles : MonoBehaviour
{
  // en esta script desconectaremos  los paneles del menu en el princio

  public GameObject m_PanelOpciones;
  public GameObject m_PanelCreditos;

    // Start is called before the first frame update
    void Start()
    {
    m_PanelOpciones.SetActive(false);
    m_PanelCreditos.SetActive(false);
    }

  
}
