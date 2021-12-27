using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Nivel_Mapas : MonoBehaviour
{
    //esta script es para cargar el nivel del boton

  public void Nivel(int m_nivel)
  {
    Application.LoadLevel(m_nivel);
  }
}
