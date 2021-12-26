using UnityEngine;


public class SC_DatosJugador : MonoBehaviour
{
  [HideInInspector]
  public static SC_DatosJugador m_DO;

  [HideInInspector]
  public int m_nivel;
  [HideInInspector]
  public float m_Numero_Brillo;
  [HideInInspector]
  public float m_volumenMusica;
  [HideInInspector]
  public int m_ID_Grafico;
  [HideInInspector]
  public bool m_Zurdo;

  public SC_Scriptable m_OP;

  private bool m_1;
  
  // Update is called once per frame
  void Update()
  {
    cambiar();
    GenerarScritp();
  }

  public void GenerarScritp()
  {

    //--------------------------------------------------------------------------------------------------------
    //set para crea esta script
    if (m_DO == null)
    {
      m_DO = this;
      DontDestroyOnLoad(gameObject);
    }
    //set para crear esta script
    //--------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------
    //set para destruir esta scritp si ya existe
    else if (m_DO != this)
    {
      Destroy(gameObject);
    }
    //set para destruir esta scritp si ya existe
    //--------------------------------------------------------------------------------------------------------
  }

  void cambiar()
  {
    if (!m_1)
    {
      m_nivel = m_OP.m_nivel;

      m_Numero_Brillo = m_OP.m_nivellBrillo;

      m_volumenMusica = m_OP.m_volumenMusica;

      m_ID_Grafico = m_OP.m_ID_Grafico;
      m_1 = true;
    }
  }
}