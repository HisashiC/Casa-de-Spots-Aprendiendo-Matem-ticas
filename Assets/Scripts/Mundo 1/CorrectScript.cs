using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectScript : MonoBehaviour
{
    public static int Acertadas = 0;
    Text acertadas;

    // Start is called before the first frame update
    void Start()
    {
        acertadas = GetComponent<Text>();
        acertadas.text = "Acertadas: " + Acertadas;
    }

    // Update is called once per frame
    void Update()
    {
        acertadas.text = "Acertadas: " + Acertadas;
    }
}
