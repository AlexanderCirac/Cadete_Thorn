using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_RecolocacionLados : MonoBehaviour
{

  //en esta script es para poder recolocar los topes laterales( de los respauwneadores) segun el ancho de la pantalla, para que salga los objetos respawneados a lo largo de todo el ancho

    // Start is called before the first frame update
    void Start()
    {
      CalculoAncho();
    }

    // Update is called once per frame
    void Update()
    {
        Recolocar();
    }


 
  public bool m_izq;
  private bool m_do1;
  
  

  void Recolocar()
  {
    if (!m_do1)
    {
      if (m_izq)
      {
        this.transform.position = new Vector3((m_posCamaraN.x +(m_posCamaraP.x + (m_posCamaraP.x/6) )), this.transform.position.y, this.transform.position.z);
        m_do1 = true;
      }
      else
      {
        this.transform.position = new Vector3((m_posCamaraP.x -(m_posCamaraP.x/5)), this.transform.position.y, this.transform.position.z);
        m_do1 = true;
      }
    }
  }


  //esto es para calcular la resolucion y convertilo en espacio "fisico" del juego. Porque la resolucion puede 480pixeles pero no ocupa en el juego el espacio 480 m.
  private Vector2 m_posCamaraP; // lado derecho
  private Vector2 m_posCamaraN; // lado izquierdo
  void CalculoAncho()
  {
    m_posCamaraP = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    m_posCamaraN = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width, -Screen.height, Camera.main.transform.position.z));
  }
}
