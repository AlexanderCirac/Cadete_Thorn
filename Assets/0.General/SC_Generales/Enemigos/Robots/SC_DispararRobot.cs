using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DispararRobot : MonoBehaviour
{
  public GameObject m_disparador;
  public GameObject m_prefab;
  private bool m_respawn;
  public bool m_permisoDisparar;
  public float m_contador;
  public float m_velocidadRespawn;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      if (m_permisoDisparar)
      {
        Disparar();
      }

    MoverseConRobot();
    }

  
  void Disparar()
  {
    
    if (!m_respawn)
    {

      m_respawn = true;
      Instantiate(m_prefab, m_disparador.transform.position, m_disparador.transform.rotation);
     
      m_contador = 0;
    }
    else
    {
      if (m_contador < 5)
      {
        m_contador += m_velocidadRespawn * Time.deltaTime;
      }
      else
      {
        m_respawn = false;
      }
    }
  }



  private void OnTriggerEnter(Collider coll)
  {
    if (coll.CompareTag("Player"))
    {
      m_permisoDisparar = true;
    }
    if (coll.CompareTag("Enemigo"))
    {
      m_robot = coll.gameObject;
      
    }
  }

  private void OnTriggerExit(Collider coll)
  {
    if (coll.CompareTag("Player"))
    {
      m_permisoDisparar = false;
    }
  }

  //[HideInInspector]
  public GameObject m_robot;
 void MoverseConRobot()
  {
    if (m_robot != null)
    {
      this.GetComponent<SphereCollider>().radius = 5555;
      transform.position = m_robot.transform.position;
      //transform.Rotate (new Vector3 (this.transform.rotation.x , -m_robot.transform.GetChild(1).transform.rotation.y ,this.transform.rotation.z));
      m_robot.GetComponent<SC_MuerteRobot>().SC_DR = this;
      m_disparador = m_robot.transform.GetChild(1).transform.GetChild(1).gameObject;

    }
    else
    {
      this.GetComponent<SphereCollider>().radius = 555;
    }
  }
}
