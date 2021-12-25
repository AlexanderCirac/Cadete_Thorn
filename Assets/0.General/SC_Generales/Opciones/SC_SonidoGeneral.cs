using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SonidoGeneral : MonoBehaviour
{
  public SC_DatosJugador SC_DJ;
  //esta scritp es para controlar el sonido de cada cosa para que coge el volumen correcto

    // Start is called before the first frame update
    void Start()
    {
    m_audio = this.gameObject.GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
    if (SC_DJ == null)
    {

    SC_DJ = FindObjectOfType<SC_DatosJugador>();
    }
    ContrololSonido();
    }

  private AudioSource m_audio;


void ContrololSonido()
  {
    if (SC_DJ != null )
    {
      if (SC_DJ.m_volumenMusica == 0)
      {
        m_audio.volume = 0;
      }
      else
      {

        m_audio.volume =  (SC_DJ.m_volumenMusica - (SC_DJ.m_volumenMusica / 4)) ;
        
      }
    }
  }
}
