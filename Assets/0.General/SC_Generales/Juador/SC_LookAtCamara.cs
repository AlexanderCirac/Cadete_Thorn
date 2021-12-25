using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_LookAtCamara : MonoBehaviour
{

  //esto es para que siempre este mirando al a cama


      public GameObject m_camara;
      public GameObject m_sprite;
      private int m_intentos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    buscarCamara();
    Mirar();
    }

  //esto es para buscar la camara del nivel 3 sin no hay no ara nada
  void buscarCamara()
  {
    if (m_camara == null && m_intentos < 3)
    {
      m_camara = GameObject.FindGameObjectWithTag("CamaraJugador");
      m_intentos++;
    }
  }

  void Mirar()
  {
    
    if (m_camara!= null)
    {
      m_sprite.transform.LookAt(m_camara.transform);
    }
  }

  private bool m_do1;
  void resetearSprites()
  {
    if (!m_do1)
    {
      m_sprite.transform.Rotate (new Vector3(0,0,0));
       m_do1 = true;
    }
  }
}
