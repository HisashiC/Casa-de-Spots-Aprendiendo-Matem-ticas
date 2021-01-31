using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalQScript : MonoBehaviour
{
    public static int TotalPreguntas;
    Text total;

    // Start is called before the first frame update
    void Start()
    {
        total= GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        total.text = "Faltantes: " + TotalPreguntas;
    }
}
