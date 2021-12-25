using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Aspa : MonoBehaviour
{

  private SC_VelocidadGeneral SC_VG;
  public SC_MuerteRobot SC_MR;
  public GameObject m_aspa;
  public float m_velocidadAspa;
  public bool m_robot;
  public bool m_robot1;

  
  // Start is called before the first frame update
  void Start()
    {
    CargarScirpt();
    }

    // Update is called once per frame
    void Update()
    {
    // CargarScript();
    if (!m_robot1) {
      IrPalante();

    }
      AspaGiratoria();
    if (m_robot)
    {
      CrearCapaDeteccion();
    }
    }


  void IrPalante()
  {
    if (m_robot) {
    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + -SC_VG.m_velocidadObjetos* Time.deltaTime);
    }
    else
    {
    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + -SC_VG.m_velocidadObjetos * Time.deltaTime);
    }
  }

  void AspaGiratoria()
  {
    m_aspa.transform.RotateAround(this.transform.position, Vector3.up, m_velocidadAspa * Time.deltaTime);
  }

  public GameObject m_detector;
  private bool m_DoOnce;
  void CrearCapaDeteccion()
  {
    if (!m_DoOnce) { 
    Instantiate(m_detector, this.transform.position, this.transform.rotation);
      m_DoOnce = true;
      }
  }
  
   void OnTriggerEnter(Collider coll)
  {
  
    if (coll.CompareTag("Bala_Jugador"))
    {
      if (m_robot == true)
      {
        SC_MR.m_robotMuerto = true;
      }

      Destroy(coll.gameObject);
    }
  }

  void CargarScirpt()
  {
    SC_VG = FindObjectOfType<SC_VelocidadGeneral>();
  }
}
