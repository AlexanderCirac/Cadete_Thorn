using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DesbloquearNivel : MonoBehaviour
{
  //esto lo que ara es sumar el nivel del juego para que cuando vayas al mapa de niveles puedas ir al correspondiente
  [HideInInspector]
  public SC_DatosJugador SC_D;

  public SC_ControlVictoria SC_CV;

  public int m_nivelAcutal;


  void Update()
    {
    BuscarSC_Datos();
    DesbloquearNivel();
    }

  void BuscarSC_Datos()
  {//cargara en una variable publica la script que almacena todos los datos
    if (SC_D == null)
    {
      SC_D = FindObjectOfType<SC_DatosJugador>();
    }
  }

  public void DesbloquearNivel()
  {
    if (SC_CV.m_victoria) {
      if (m_nivelAcutal > SC_D.m_nivel)
      {
        SC_D.m_nivel = SC_D.m_nivel + 1;
      }
    }  
  }
}
