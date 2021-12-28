using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_JugadorAnimacion : MonoBehaviour
{    
  //esta script es para controlar la animacion del juegador cuando este se mueva de un lado a otro
    // Start is called before the first frame update
    void Start()
    {
    m_movimientosGuardado = this.transform.position.x;
    m_numero = m_nave.transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
    Invoke("comprobanteValorMovimientos", 0.00001f);
    Animacion();
    }

  public GameObject m_nave;
  //esta funcion es la que ara que se reproduzca la animacion
  private float m_z;
  private bool m_parar;

  //opcion 3 

  private float baseRotacion = 0f;
  private float maxzRotation1 = -60; // este sera el valor para clampear un lado derech
  private float maxzRotation2 = 60; // este sera el valor para clampear un lado izquierdo
  float currentRotation = 0.0f;
  Quaternion zRotation;

  private float m_numero;
  void Animacion()
  {
    if (this.transform.position.x > m_movimientosGuardado)
    {
      //para que rote libremente ( opcion 1)
      //  m_nave.transform.RotateAround(m_nave.gameObject.transform.position, Vector3.forward, -50 * Time.deltaTime);
      //esto es para que se ponga en una rotacion fija ( opcione 2)
      //if (!m_parar)
      //{
      //  m_nave.transform.rotation = Quaternion.Euler(new Vector3(m_nave.transform.rotation.x, m_nave.transform.rotation.y, -15));
      //  m_parar = true;
      //}

      //esto es para que rote asta un cierto punto ( opcion 3)

      if (m_nave.transform.rotation.z > -0.3)
      {
        m_nave.transform.RotateAround(m_nave.gameObject.transform.position, Vector3.forward, -500 * Time.deltaTime);
      }
    }
    if (this.transform.position.x < m_movimientosGuardado)
    {
      //opcion 2
      //if (m_parar)
      //{
      //  m_nave.transform.rotation = Quaternion.Euler(new Vector3(m_nave.transform.rotation.x, m_nave.transform.rotation.y, 5));
      //  m_parar = false;
      //}
      //opcion 3
      if (m_nave.transform.rotation.z < 0.3)
      {
        m_nave.transform.RotateAround(m_nave.gameObject.transform.position, Vector3.forward, 500 * Time.deltaTime);
      }
    }
  }


  private float m_movimientosGuardado;
 
  void comprobanteValorMovimientos()
  {
    if (this.transform.position.x != m_movimientosGuardado)
    {
      m_movimientosGuardado = this.transform.position.x;
    }
  }
}
