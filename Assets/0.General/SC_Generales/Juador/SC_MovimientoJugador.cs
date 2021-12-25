using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_MovimientoJugador : MonoBehaviour
{

  //en esta scritp es para controlar el movimiento del personaje mediante el movimiento del dedo



  private void Start()
  {
   // m_PosicionActual = m_jugador.transform.position;
  }
  private void Update()
  {
    //ControlPosicion();
  }

  public GameObject m_jugador;
  public Camera m_camara;
  public SC_PermisoMover SC_PM;

  public void moverJugador() // esto ira con un boton UI
  {
    Touch touch = Input.GetTouch(0);
    Vector3 mousePosition = new Vector3(touch.position.x, touch.position.y, 65/*la altura*/);
    //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 65/*la altura*/);
    Vector3 objPosition = m_camara.ScreenToWorldPoint(mousePosition);




    //if (SC_PM.m_si /*&& m_seguirMoviendo*/)
    //{
      if (Input.mousePosition.x < (Screen.width - (Screen.width / 10)) && (Input.mousePosition.x > ((Screen.width - System.Math.Abs(Input.mousePosition.x)) - ((Screen.width) - (Screen.width / 6)))))
      {
        transform.position = new Vector3(objPosition.x, transform.position.y, transform.position.z);
      }
      else
      {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
      }


      if (Input.mousePosition.y < (Screen.height - (Screen.height / 5)) && (Input.mousePosition.y > ((Screen.height - System.Math.Abs(Input.mousePosition.y)) - ((Screen.height) - (Screen.height / 3) - 50))))
      {
        transform.position = new Vector3(transform.position.x, objPosition.y, objPosition.z);
      }
      else
      {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
      }
    //}
 

  }

  //[HideInInspector]
  //public Vector3 m_PosicionActual;
  //[HideInInspector]
  //public Vector3 m_NuevaPosicion;
  //private Vector3 m_distancia;
  //private float m_calculoDistancia;
  //[HideInInspector]
  //public bool m_seguirMoviendo;
  //public float m_distanciaMax;


  //void ControlPosicion()
  //{

  //  // funciona; pero esto es para eviatar que la nave aga traslaciones raras cuando hay dos inputs en la pantalla, porque la nave se queda en medio
  //  // de los dos dedos. Si utilizas los controles del input.mouse encuenta de Input.GetTouch(0);, si utilizas el touch no necesitas esto.
  //  m_NuevaPosicion = m_jugador.transform.position;

  //  m_distancia = new Vector3(m_PosicionActual.x - m_NuevaPosicion.x, m_jugador.transform.position.y, m_PosicionActual.z - m_NuevaPosicion.z);
  //  m_calculoDistancia = Mathf.Abs(m_distancia.sqrMagnitude);

  //  Debug.Log(m_NuevaPosicion);
  //  if (m_calculoDistancia < m_distanciaMax) {

  //    m_seguirMoviendo = true;
  //    m_PosicionActual = m_jugador.transform.position;
      
  //  }
  //  else
  //  {
  //    m_seguirMoviendo = false;
  //    m_jugador.transform.position = new Vector3( m_PosicionActual.x, m_jugador.transform.position.y, m_PosicionActual.z);
  //  }
  //}

}
