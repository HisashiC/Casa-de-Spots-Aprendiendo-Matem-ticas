using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public static int hsValue = 0;
    Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<Text>();
        highScore.text = "Alta Puntuación: " + PlayerPrefs.GetInt("HighScoreNivel1");
    }

    // Update is called once per frame
    void Update()
    {
        highScore.text = "Alta Puntuación: " + hsValue;
    }
}
