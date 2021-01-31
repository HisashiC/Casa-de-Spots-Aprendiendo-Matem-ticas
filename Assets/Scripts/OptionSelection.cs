using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionSelection : MonoBehaviour
{

    public void PlayGame()
    {
        switch (this.gameObject.name)
        {
            case "Jugar":
                SceneManager.LoadScene("WorldSelection");
                break;
            case "Aprender":
                SceneManager.LoadScene("Learn");
                break;
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
