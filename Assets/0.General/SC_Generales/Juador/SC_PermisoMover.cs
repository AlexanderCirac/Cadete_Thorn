using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PermisoMover : MonoBehaviour
{

  [HideInInspector]
  public bool m_si;

  //public SC_MovimientoJugador SC_MJ;

  public void Moverse()
  {
    m_si = true;
  }
  public void Denegar()
  {
    m_si = false;
  }

  private void Update()
  {
    //Reiniciar();
  }

  //void Reiniciar()
  //{
  //  if (SC_MJ.m_seguirMoviendo)
  //  {
  //    SC_MJ.m_PosicionActual = SC_MJ.m_jugador.transform.position;
  //    SC_MJ.m_NuevaPosicion = SC_MJ.m_jugador.transform.position;
  //    SC_MJ.m_seguirMoviendo = false;
  //  }
  //}
}
