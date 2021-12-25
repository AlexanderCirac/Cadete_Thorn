using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Controlador_Graficos : MonoBehaviour
{
  //[HideInInspector]
  public SC_DatosJugador SC_D;

 
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     LectorScript();
    }

  void LectorScript()
  {

    if (SC_D == null)
    {

      SC_D = FindObjectOfType<SC_DatosJugador>();
    }
  }

  public void bajo()
  {
    SC_D.m_ID_Grafico = 0;
  }

  public void Normal()
  {
    SC_D.m_ID_Grafico = 2;
  }

  
}
