using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_QuitarVida : MonoBehaviour
{
  //esta scritp al chocar contra el jugador le restara un punto de vida

  public SC_Vida SC_V;
  public int m_quitarVida;

  private void OnTriggerEnter(Collider col)
  {
   
    if (col.CompareTag("Player"))
    {
      if(SC_V.m_vida > 0)
      SC_V.m_vida = SC_V.m_vida - m_quitarVida;
    }
  }
}
