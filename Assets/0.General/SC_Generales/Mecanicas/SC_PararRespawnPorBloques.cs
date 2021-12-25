using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PararRespawnPorBloques : MonoBehaviour
{
  //esta script es para detener los respawns cuando pase los muros y evitar que superponga los objetos

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public GameObject m_1;
  public GameObject m_2;
  public GameObject m_Robots;
  public GameObject m_Cubo;

  private void OnTriggerEnter(Collider coll)
  {
    if (coll.CompareTag("CosoMedio"))
    {
      m_1.SetActive(false);
      m_2.SetActive(false);
      if (m_Robots!= null)
      {
      m_Robots.SetActive(false);
      }
    }
  }

  private void OnTriggerExit(Collider coll)
  {
    if (coll.CompareTag("CosoMedio"))
    {
      m_1.SetActive(true);
      m_2.SetActive(true);
      if (m_Robots != null)
      {
        m_Robots.SetActive(true);
      }
      m_Cubo.GetComponent<Collider>().isTrigger = true;
    }
  }
}
