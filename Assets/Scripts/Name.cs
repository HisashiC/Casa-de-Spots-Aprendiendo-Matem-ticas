using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public Text nombre;
    // Start is called before the first frame update
    void Start()
    {
        nombre.text = "Bienvenido(a): " + PlayerPrefs.GetString("Name");
    }
    
}
