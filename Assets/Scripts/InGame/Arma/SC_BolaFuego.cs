using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BolaFuego : MonoBehaviour
{
  

  public float m_velocidad;
  public Rigidbody m_rg;
  private float m_tiempo;
  private float m_velocidadTiempo;
  public GameObject m_yo;
  public bool m_cambioDireccion;

  
  // Update is called once per frame
  void Update()
  {
   
      irPalante();
      desaparecer();
     
  }

  void irPalante()
  {
    if(!m_cambioDireccion) {
    m_yo.transform.position = new Vector3(m_yo.transform.position.x , m_yo.transform.position.y, m_yo.transform.position.z + m_velocidad * Time.deltaTime);
    }
    else
    {
    m_yo.transform.position = new Vector3(m_yo.transform.position.x , m_yo.transform.position.y, m_yo.transform.position.z - m_velocidad * Time.deltaTime);
    }
  }

  void desaparecer()
  {
       m_velocidadTiempo = 8.5f;
       m_tiempo += m_velocidadTiempo * Time.deltaTime;

    if (m_tiempo > 10)
    {
      Destroy(m_yo);
    }
  }

  
}
