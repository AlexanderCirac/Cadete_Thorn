using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


public class SC_GuardarYCargarJugador : MonoBehaviour
{
  [Header("Nombre Scriptable")]
  public string m_nombrePersistente;
  [Header("Scriptable Object")]
  public SC_Scriptable m_objetoPersistente;
  public SC_DatosJugador m_Datos;


  public bool m_1;
  private bool m_2;
  // Start is called before the first frame update
  void Start()
  {

  }

  private void Update()
  {
    cargarScript();
    if (m_Datos != null)
    {
      cargadoauto();
    }
  }


  void cargadoauto()
  {
    if (!m_1)
    {

      if (File.Exists(Application.persistentDataPath + string.Format(".pso", m_nombrePersistente)))
      {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + string.Format(".pso", m_nombrePersistente), FileMode.Open);
        JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), m_objetoPersistente);
        file.Close();
      }
      else
      {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + string.Format(".pso", m_nombrePersistente));
        var json = JsonUtility.ToJson(m_objetoPersistente);
        bf.Serialize(file, json);
        file.Close();
      }
      m_Datos.m_nivel = m_objetoPersistente.m_nivel;
      m_Datos.m_Numero_Brillo = m_objetoPersistente.m_nivellBrillo;
      m_Datos.m_volumenMusica = m_objetoPersistente.m_volumenMusica;
      m_Datos.m_ID_Grafico = m_objetoPersistente.m_ID_Grafico;
      m_Datos.m_Zurdo = m_objetoPersistente.m_Zurdo;
      m_1 = true;
    }
  }

  public void GuardarOpciones()
  {

    m_objetoPersistente.m_nivel = m_Datos.m_nivel;
    m_objetoPersistente.m_nivellBrillo = m_Datos.m_Numero_Brillo;
    m_objetoPersistente.m_volumenMusica = m_Datos.m_volumenMusica;
    m_objetoPersistente.m_ID_Grafico = m_Datos.m_ID_Grafico;
    m_objetoPersistente.m_Zurdo = m_Datos.m_Zurdo;

    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + string.Format(".pso", m_nombrePersistente));
    var json = JsonUtility.ToJson(m_objetoPersistente);
    bf.Serialize(file, json);
    file.Close();

  }


  public void CargarOpciones()
  {
    if (File.Exists(Application.persistentDataPath + string.Format(".pso", m_nombrePersistente)))
    {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + string.Format(".pso", m_nombrePersistente), FileMode.Open);
      JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), m_objetoPersistente);
      file.Close();
    }
    m_Datos.m_nivel = m_objetoPersistente.m_nivel;
    m_Datos.m_Numero_Brillo = m_objetoPersistente.m_nivellBrillo;
    m_Datos.m_volumenMusica = m_objetoPersistente.m_volumenMusica;
    m_Datos.m_ID_Grafico = m_objetoPersistente.m_ID_Grafico;
    m_Datos.m_Zurdo = m_objetoPersistente.m_Zurdo;

  }

  void cargarScript()
  {
    if (m_Datos == null)
    {
      m_Datos = FindObjectOfType<SC_DatosJugador>();
    }
  }

  public void BorrarDatosNivel()
  {
    m_objetoPersistente.m_nivel = 0;
    m_Datos.m_nivel = 0;
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + string.Format(".pso", m_nombrePersistente));
    var json = JsonUtility.ToJson(m_objetoPersistente);
    bf.Serialize(file, json);
    file.Close();
  }

}

