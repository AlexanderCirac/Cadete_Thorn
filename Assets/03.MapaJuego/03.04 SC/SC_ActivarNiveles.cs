using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_ActivarNiveles : MonoBehaviour
{
  //esta script es para desbloquear las misiones siguientes una
  //vez que se ayan pasado el nivel anterior

  [HideInInspector]
  public SC_DatosJugador SC_D;
  public int m_NivelDesbloquear;
  private bool m_DoOnce = false;
  public GameObject[] m_Niveles;



    // Update is called once per frame
    void Update()
    {
      BuscarSC_Datos();
    ControladorNivel();
      ActivarNiveles();
    }

  void BuscarSC_Datos()
  {//cargara en una variable publica la script que almacena todos los datos
    if (SC_D == null)
    {
      SC_D = FindObjectOfType<SC_DatosJugador>();
    }
  }

  void ControladorNivel()
  {
    if (SC_D != null)
    {
      if(SC_D.m_nivel == 0)
      {
        m_NivelDesbloquear = 0;
      }
      else
      {
        m_NivelDesbloquear = SC_D.m_nivel;
      }
    }
    else
    {
      m_NivelDesbloquear = 0;
    }
  }

  void ActivarNiveles()
  {
   
    if (m_DoOnce == false)
    {
      for ( int i= 0; i<= m_NivelDesbloquear; i++ )
      {
        m_Niveles[i].GetComponent<Button>().interactable = true;
      }
      m_DoOnce = true;
    }
  }
}
