using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SC_Control_Sonido : MonoBehaviour
{
  //esta escript es para controlar el sonido cuando este, este a 0 de volumen se pare del reproducir musica


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    ControlandoSonido();
    }


  public GameObject m_sonido;

  void ControlandoSonido()
  {
    if (m_sonido.GetComponent<AudioSource>().volume == 0)
    {
      m_sonido.GetComponent<AudioSource>().mute = true;
    }
    else
    {
      m_sonido.GetComponent<AudioSource>().mute = false;
    }
  }
}
