using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CambiarVelocidad : MonoBehaviour
{

  //esta script es cambiar la velocidad de todos los objetos
  //[HideInInspector]
  public SC_VelocidadGeneral SC_VG;

  [HideInInspector]
  public bool m_cambiarVelocidad;
  private float m_temporizador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (SC_VG != null)
    {
    }
    else
    {
      CargarScirpt();
    }
  }


  private void OnTriggerEnter(Collider coll)
  {
    if (coll.CompareTag("Player"))
    {
      SC_VG.m_cambiarVelocidad = true;
      Destroy(this.gameObject);
    }
  }

  void CargarScirpt()
  {
    SC_VG = FindObjectOfType<SC_VelocidadGeneral>();
  }
}
