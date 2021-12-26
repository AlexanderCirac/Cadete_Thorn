using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class SC_BotonCargar : MonoBehaviour
{
  //idea: esta script es para activar el boton de cargar
 // [HideInInspector]
  public TextAsset m_textAsset;
  private int m_lector = 3;
  public Button m_boton;

  private void Start()
  {

   
  }

  // Update is called once per frame
  void Update()
    {
    CargarFichero();
    }

  void CargarFichero()
  {
    //esto es para cargar el archivo, encontrar el archivo guardado para activar el boton
  
    if (m_textAsset == null) {
      if (m_lector != 0)
      {
        m_textAsset = Resources.Load<TextAsset>( "Gamedate/DatosJugador");
        m_boton.interactable = false;
        m_lector = 0;
      }
    }
    else
    {
      if (m_lector != 1)
      {
        m_boton.interactable = true;
        m_lector = 1;
      }
    }
  }
}
