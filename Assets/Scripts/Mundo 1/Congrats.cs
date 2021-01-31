using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Congrats: MonoBehaviour
{
    Text Name;
    // Start is called before the first frame update
    void Start()
    {
        Name = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Name.text = "¡Felicitaciones " + PlayerPrefs.GetString("Name") + "! ¡Has Ganado!";
    }
}
