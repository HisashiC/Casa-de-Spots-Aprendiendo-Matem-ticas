using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Bindings;

public class SelectionMenu : MonoBehaviour
{
    public GameObject panel1, panel2, panel3, panel4;
    public Text highScore1, highScore2, highScore3, highScore4;
    [SerializeField] public Button nivel1, nivel2, nivel3, nivel4;
    int nivelCompletado, high1, high2, high3, high4;

    void Start()
    { 
        high1 = PlayerPrefs.GetInt("HighScoreNivel1");
        high2 = PlayerPrefs.GetInt("HighScoreNivel2");
        high3 = PlayerPrefs.GetInt("HighScoreNivel3");
        high4 = PlayerPrefs.GetInt("HighScoreNivel4");
        nivelCompletado = PlayerPrefs.GetInt("nivelCompletado");
        nivel2.interactable = false;
        nivel3.interactable = false;
        nivel4.interactable = false;
        if (nivelCompletado > 5)
        {
            nivel2.interactable = true;
            nivel3.interactable = true;
            nivel4.interactable = true;
        }
        else
        {
            switch (nivelCompletado)
            {
                case 3:
                    nivel2.interactable = true;
                    break;
                case 4:
                    nivel2.interactable = true;
                    nivel3.interactable = true;
                    break;
                case 5:
                    nivel2.interactable = true;
                    nivel3.interactable = true;
                    nivel4.interactable = true;
                    break;
            }
        }
    }
    public void GameBack()
    {
        SceneManager.LoadScene("MenuOpciones");
    }
    
    public void Nivel1_acc()
    {
        panel1.SetActive(true);
        highScore1.text = "Alta Puntuación: " + high1;
    }

    public void Nivel2_acc()
    {
        panel2.SetActive(true);
        highScore2.text = "Alta Puntuación: " + high2;
    }

    public void Nivel3_acc()
    {
        panel3.SetActive(true);
        highScore3.text = "Alta Puntuación: " + high3;
    }

    public void Nivel4_acc()
    {
        panel4.SetActive(true);
        highScore4.text = "Alta Puntuación: " + high4;
    }

    public void Nivel1_back()
    {
        panel1.SetActive(false);
    }

    public void Nivel2_back()
    {
        panel2.SetActive(false);
    }

    public void Nivel3_back()
    {
        panel3.SetActive(false);
    }

    public void Nivel4_back()
    {
        panel4.SetActive(false);
    }

}
