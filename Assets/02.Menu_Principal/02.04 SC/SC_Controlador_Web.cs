using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Controlador_Web : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
public void Pagina_Web(string URL)
  {
    Application.OpenURL(URL);
  }
}
