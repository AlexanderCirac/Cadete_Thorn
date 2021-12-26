using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MoverBloque : MonoBehaviour
{

  //esto script es para hacer mover las cosas

  private SC_VelocidadGeneral SC_VG;

  //esto son para objetos que desaparezcan
  public bool m_Perecederos;
  private float m_tiempo;
  private float m_m_velocidadTiempo;

    // Update is called once per frame
  void Update()
    {
        if (SC_VG != null) {
          Mover();
          if (m_Perecederos) {
            desaparecer();
          }
        }
        else
        {
          CargarScirpt();
        }
    }

  void Mover()
  {
    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - (SC_VG.m_velocidadObjetos+0.5f)* Time.deltaTime);
  }

  void CargarScirpt()
  {
    SC_VG = FindObjectOfType<SC_VelocidadGeneral>();
  }

  void desaparecer()
  {
    m_tiempo += SC_VG.m_TiempoDesaparecerProyectil * Time.deltaTime;

    if (m_tiempo > 10)
    {
      Destroy(this.gameObject);
    }
  }


}
