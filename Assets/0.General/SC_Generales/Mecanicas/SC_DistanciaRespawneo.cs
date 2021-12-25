using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DistanciaRespawneo : MonoBehaviour
{

  //esta script es para evitar que los respawns cree objetos y se superponga con los objetos del otro respawn


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     calcularDistancia();
    }

  public GameObject m_respawn2; // es el que calculara la distancia
  public GameObject m_respawn1; // es el que se desactivara
  private float m_calculoDistancia;
  public float m_disMax;
  void calcularDistancia()
  {

    //Debug.Log(Mathf.Abs(m_calculoDistancia));
    m_calculoDistancia = this.transform.position.x - m_respawn2.transform.position.x;

    if (Mathf.Abs(m_calculoDistancia) < m_disMax)
    {
      m_respawn1.SetActive(false);
    }
    else
    {
      m_respawn1.SetActive(true);
    }
  }
}
