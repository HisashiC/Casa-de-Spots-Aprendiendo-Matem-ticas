using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{
    public GameObject[] stars;
    int stars1, stars2, stars3, stars4;
    int tristar;

    // Start is called before the first frame update
    void Start()
    {
        //Altas puntuaciones
        stars1 = PlayerPrefs.GetInt("HighScoreNivel1");
        stars2 = PlayerPrefs.GetInt("HighScoreNivel2");
        stars3 = PlayerPrefs.GetInt("HighScoreNivel3");
        stars4 = PlayerPrefs.GetInt("HighScoreNivel4");

        //Tres estrellas en todos los niveles
        tristar = PlayerPrefs.GetInt("ThreeStars");

        //Nivel 1
        if (stars1 <= 10 && stars1 >= 15)
        {
            stars[0].SetActive(true);
            
        }else if (stars1 < 75 && stars1 > 10)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if(stars1 >= 75)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }

        //Nivel 2
        if (stars2 <= 150 && stars2 >= 20)
        {
            stars[3].SetActive(true);

        }
        else if (stars2 <= 300 && stars2 > 150)
        {
            stars[3].SetActive(true);
            stars[4].SetActive(true);
        }
        else if (stars2 > 300)
        {
            stars[3].SetActive(true);
            stars[4].SetActive(true);
            stars[5].SetActive(true);
        }

        //Nivel 3
        if (stars3 <= 150 && stars3 >= 20)
        {
            stars[6].SetActive(true);

        }
        else if (stars3 <= 300 && stars3 > 150)
        {
            stars[6].SetActive(true);
            stars[7].SetActive(true);
        }
        else if (stars3 > 300)
        {
            stars[6].SetActive(true);
            stars[7].SetActive(true);
            stars[8].SetActive(true);
        }

        //Nivel 3
        if (stars4 <= 150 && stars4 >= 20)
        {
            stars[9].SetActive(true);

        }
        else if (stars4 <= 300 && stars4 > 150)
        {
            stars[9].SetActive(true);
            stars[10].SetActive(true);
        }
        else if (stars4 > 300)
        {
            stars[9].SetActive(true);
            stars[10].SetActive(true);
            stars[11].SetActive(true);
        }
    }
}
