using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Zurdo : MonoBehaviour
{
  public SC_Lector_Datos_BrilloYsonido SC_DB;
  //esta script es para activar el  lado derecho o izquierdo

  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    ControlZurdo();
    ControladorZurdo();
    }

  public GameObject m_derecha;
  public GameObject m_izquierda;
  public Toggle m_tick;
  public bool m_tick1;


  void ControlZurdo()
  {
    if (m_tick.isOn == true)
    {
      if (m_izquierda != null)
      {

      m_izquierda.SetActive(true);
      m_derecha.SetActive(false);
      }
    }
    else
    {
      if (m_izquierda != null)
      {
        m_izquierda.SetActive(false);
        m_derecha.SetActive(true);
      }
    }
  }

  void ControladorZurdo()
  {
    //if (SC_DB != null)
    //{
    //  m_tick = SC_DB.m_BoolZurdo;
    //}
    //else
    //{
    //  SC_DB = FindObjectOfType<SC_Lector_Datos_BrilloYsonido>();
    //}
  }
}
