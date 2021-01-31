using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private GameObject quitPanel, deletePanel;
    public GameObject nameMenu;
    public string nombre;
    public GameObject inputField;
    public Text texto;
    private Text name;

    public void StartGame()
    {
        if (!PlayerPrefs.HasKey("Name"))
        {
            nameMenu.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("MenuOpciones");
        }
    }

    public void insertName()
    {
        nombre = inputField.GetComponent<Text>().text;
        texto.text = "Bienvenido(a): " + nombre;
        PlayerPrefs.SetString("Name", nombre);
        PlayerPrefs.Save();
        nameMenu.SetActive(false);
    }

    public void QuitPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void backOption()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void gameBack()
    {
        SceneManager.LoadScene("WorldSelection");
    }

    public void rewardMenu()
    {
        SceneManager.LoadScene("Rewards");
    } 

    public void DeleteData(GameObject panel)
    {
        PlayerPrefs.DeleteKey("FullLife");
        PlayerPrefs.DeleteKey("HighScoreNivel1");
        PlayerPrefs.DeleteKey("HighScoreNivel2");
        PlayerPrefs.DeleteKey("HighScoreNivel3");
        PlayerPrefs.DeleteKey("HighScoreNivel4");
        PlayerPrefs.DeleteKey("nivelCompletado");
        PlayerPrefs.DeleteKey("NoErrors");
        PlayerPrefs.DeleteKey("ThreeStars");
        panel.SetActive(false);
    }

    public void DeletePanelY(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeletePanelN(GameObject panel)
    {
        panel.SetActive(false);
    }
}
