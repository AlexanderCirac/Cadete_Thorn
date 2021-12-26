using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Parar_Balas : MonoBehaviour
{

  //esto es para hacer un tope con las balas por si el jugador se hacerca mucho al fondo para que no mate  a las cosas antes de llegar al final


  private void OnTriggerEnter(Collider coll)
  {
    if (coll.CompareTag("Bala_Jugador"))
    {
      Destroy(coll.gameObject);
    }
  }
}
