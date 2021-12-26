using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_LadoALado : MonoBehaviour
{

  //esta script es para controlar el movimiento de los pinchos

    public float m_velocidad;
    public Transform m_izquierda;
    public Transform m_derecha;
    public bool m_cambio;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      SubirPinchos();
    
    }

    void SubirPinchos()
    {

      if (m_cambio == false)
      {
        if (transform.position.x >= m_izquierda.position.x + 0.2f)
        {
          transform.position = Vector3.MoveTowards(transform.position, new Vector3(m_izquierda.position.x, transform.position.y, transform.position.z), m_velocidad * Time.deltaTime);
        }
        else
        {
          m_cambio = true;
        }
      }
    else
    {
      if (transform.position.x <=  m_derecha.position.x - 0.2f)
      {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(m_derecha.position.x, transform.position.y, transform.position.z), m_velocidad * Time.deltaTime);
      }
      else
      {
        m_cambio = false;
      }
    }
  }


}
