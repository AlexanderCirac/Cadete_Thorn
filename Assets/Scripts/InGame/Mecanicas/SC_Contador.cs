using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_Contador : MonoBehaviour
{

  //en estas script controlaremos los puntos que vaya consiguiendo el jugador a medida que elimine obstaculos o se coma los elementos

  public Text m_textoContador;  // asignamos donde se vera los contadores
  public int m_maximo;          // Los maximos de puntos que podra obtener el jugador
  //[HideInInspector]
  public int m_contandoPuntos;  // Lo que ira incrementando
  private int m_contandoPuntosAtcuales;  // Es una variable que se utilizara de tope para evitar que la funcion se este ejecutando todo el rato y solo se ejecute
                                         // cuando aya un cambio de los puntos incrementados. Asi evitamos que vaya mas lento el juego
  private void Start()
  {
    m_contandoPuntosAtcuales = -1;
  }

  // Update is called once per frame
  private void Update()
    {
      Contador();
    }

  private void Contador()
  {
    if (m_contandoPuntosAtcuales != m_contandoPuntos)
    {
      if (m_maximo >= m_contandoPuntos) {
        m_textoContador.text = m_contandoPuntos.ToString() + "/" + m_maximo.ToString();
        m_contandoPuntosAtcuales = m_contandoPuntos;
      }
      else
      {
        int m_resultado = m_contandoPuntos - (m_contandoPuntos - m_maximo ) ;
        m_contandoPuntos = m_maximo;
        m_textoContador.text = m_resultado.ToString() + "/" + m_maximo.ToString();
      }
    }
  }
}
