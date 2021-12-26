using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_Controlador_SonidoYBrillo : MonoBehaviour {


  //esta script es para controlar las opciones del brillo y del sonido. Haciendo que se guarde los datos en unas scritp que no se autodestuira y
  //pasara la informacion al lector de las opciones
  [HideInInspector]
  public SC_DatosJugador SC_D; 

  public Slider m_Slider_Brillo;
  public Slider m_Slider_Musica_Ambiente;
  public Slider m_Slider_Musica_Accion;

  private int m_numero;
  private int m_numero1;
  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    lectorSC_Datos();
   PasarDatos();
  

  }

  void lectorSC_Datos()
  {

    if (SC_D == null)
    {
      SC_D = FindObjectOfType<SC_DatosJugador>();
    }

  }

  public Toggle m_zurdo;
  void PasarDatos()
  {
    //primero tenemos que tener  la script donde se almacenara la informacion
    if (SC_D != null) {
    
     //si hay datos en esa script se lo pasara a la barra de la opcion y si no lo tiene ese dato,w lo facilitara la barra
        if (SC_D.m_Numero_Brillo != 0 && m_numero != 1)
        {
         m_Slider_Brillo.value = SC_D.m_Numero_Brillo;
         m_numero = 1;
        }
          else
          {
            SC_D.m_Numero_Brillo = m_Slider_Brillo.value;
          }
        if (SC_D.m_volumenMusica != 0 && m_numero1 != 1)
        {

          m_Slider_Musica_Ambiente.value = SC_D.m_volumenMusica;
          m_numero1 = 1;
      }
          else
          {
            SC_D.m_volumenMusica = m_Slider_Musica_Ambiente.value;
          }

    //  //para los datos del toggle de zurdo

    //  //if (SC_D.m_Zurdo != SC_D.m_Zurdo && m_numero1 != 1)
    //  if (m_numero1 != 1)
    //  {

    //    m_zurdo.isOn = SC_D.m_Zurdo;
    //    m_numero1 = 1;
    //  }
    //    else
    //    {
    //      SC_D.m_Zurdo = m_zurdo.isOn;
    //    }


    }
  }
  //[HideInInspector]
  //public SC_Lector_Datos_BrilloYsonido SC_LDB;
  //void ControladorZurdo()
  //{
  //  if (SC_LDB)
  //  {

  //  }
  //}
}
