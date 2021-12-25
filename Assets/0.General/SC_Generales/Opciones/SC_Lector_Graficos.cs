using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Lector_Graficos : MonoBehaviour
{

  //esta script leera el archivo de datos y segun la informacion que de
  //pondra una opcion de grafico o otro

  [HideInInspector]
  public SC_DatosJugador SC_D;

  private int m_Actual_ID_Grafico;
    // Update is called once per frame
    void Update()
    {
      LectorScript();
      LectorGrafico();
    }

  void LectorScript()
  {

    if (SC_D == null)
    {

      SC_D = FindObjectOfType<SC_DatosJugador>();
    }
  }

  void LectorGrafico()
  {
    if (SC_D.m_ID_Grafico == 0 && m_Actual_ID_Grafico != 1)
    {
      QualitySettings.SetQualityLevel(0);
      m_Actual_ID_Grafico = 1;
      Debug.Log("2");
    }
    if (SC_D.m_ID_Grafico == 2 && m_Actual_ID_Grafico !=2)
    {
      QualitySettings.SetQualityLevel(2);
      m_Actual_ID_Grafico = 2;
      Debug.Log("1");
    }
  }
}
