using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Mundo1Quiz : MonoBehaviour
{
    [SerializeField] private LifeScript lifeScript;
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private GameObject gameOverPanel, gameOverLosePanel;

    int primerValor, segundoValor, valorTemporal, Temporal, Respuesta, Alternativa1, Alternativa2, vidasRestantes, acertadas, totalPreguntas, score;
    string operador;
    public Text totalQ, numero1, numero2, signo, tiempo, totalScore, preguntasAcertadas, loseScore, acertadasLose;
    public Button bot1, bot2, bot3;
    public GameObject HighScoreW, HighScoreL;
    public TextMeshProUGUI ans1, ans2, ans3;
    public float currentTime;
    private bool esCorrecta;
    public AudioClip music, correcta, incorrecta, aplausos;
    public AudioSource audioSource;
    public List<Image> stars;
    public Text congratulations;
    int nextSceneLoad, nivelCompletado, highScore, threeStars, starIndex, noErrors, fullLife, sinErrores, tresEstrellas;

    string[] signos = { "+", "-", "*", "÷" };

    private GameStatus gameStatus = GameStatus.NEXT;

    public GameStatus GameStatus { get { return gameStatus; } }

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Nivel Próximo " + nextSceneLoad);
        nivelCompletado = PlayerPrefs.GetInt("nivelCompletado");
        highScore = PlayerPrefs.GetInt("HighScoreNivel1");
        sinErrores = PlayerPrefs.GetInt("NoErrors");
        tresEstrellas = PlayerPrefs.GetInt("ThreeStars");
        starIndex = 1;
        noErrors = 1;
        StartGame();
    }

    void StartGame()
    {
        audioSource.GetComponent<AudioSource>();
        audioSource.PlayOneShot(music, 0.7F);
        esCorrecta = false;
        vidasRestantes = 3;
        totalPreguntas = 11;
        TotalQScript.TotalPreguntas = totalPreguntas;
        HighScoreScript.hsValue = highScore;
        acertadas = 0;
        CorrectScript.Acertadas = acertadas;
        ScoreScript.ScoreValue = 0;
        gameStatus = GameStatus.PLAYING;
        Calcular();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus == GameStatus.PLAYING)
        {
            currentTime -= Time.deltaTime;
            DisplayTime(currentTime);
        }

    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        tiempo.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (currentTime <= 0)
        {
            //Game Over
            if (CorrectScript.Acertadas < 5)
            {
                GameOverLose();
            }
            if(CorrectScript.Acertadas >= 5)
            {GameOver();}
        }
    }

    public void Calcular()
    {
        primerValor = UnityEngine.Random.Range(1, 10);
        segundoValor = UnityEngine.Random.Range(1, 10);
        operador = signos.RandomItem();

        if (primerValor - segundoValor < 0)
        {
            valorTemporal = segundoValor;
            segundoValor = primerValor;
            primerValor = valorTemporal;
        }

        numero1.text = primerValor.ToString();
        numero2.text = segundoValor.ToString();
        signo.text = operador;
        ans1.text = UnityEngine.Random.Range(1, 36).ToString();

        if (operador == "+") { Respuesta = primerValor + segundoValor;}
        if (operador == "-") { Respuesta = primerValor- segundoValor; }
        if (operador == "*") { Respuesta = primerValor* segundoValor; }
        if (operador == "÷") { Respuesta = primerValor/ segundoValor; }

        Temporal = UnityEngine.Random.Range(0, 15);
        while (Temporal == Respuesta)
        {
            Temporal = UnityEngine.Random.Range(0, 15);
        }
        Alternativa1 = Temporal;

        Temporal = UnityEngine.Random.Range(0, 15);
        while ((Temporal == Respuesta) || (Temporal == Alternativa1))
        {
            Temporal = UnityEngine.Random.Range(0, 15);
        }
        Alternativa2 = Temporal;
        
        

        Temporal = UnityEngine.Random.Range(1, 6);
        if (Temporal == 1)
        {
            ans1.text = Respuesta.ToString();
            ans2.text = Alternativa1.ToString();
            ans3.text = Alternativa2.ToString();
        }
        if (Temporal == 2)
        {
            ans1.text = Respuesta.ToString();
            ans2.text = Alternativa2.ToString();
            ans3.text = Alternativa1.ToString();
        }
        if (Temporal == 3)
        {
            ans1.text = Alternativa1.ToString();
            ans2.text = Respuesta.ToString();
            ans3.text = Alternativa2.ToString();
        }
        if (Temporal == 4)
        {
            ans1.text = Alternativa1.ToString();
            ans2.text = Alternativa2.ToString();
            ans3.text = Respuesta.ToString();
        }
        if (Temporal == 5)
        {
            ans1.text = Alternativa2.ToString();
            ans2.text = Respuesta.ToString();
            ans3.text = Alternativa1.ToString();
        }
        if (Temporal == 6)
        {
            ans1.text = Alternativa2.ToString();
            ans2.text = Alternativa1.ToString();
            ans3.text = Respuesta.ToString();
        }
    }

    IEnumerator SiguientePregunta()  // couroutina que espera luego de acertar, para pasar a la siguiente pregunta..
    {
        yield return new WaitForSeconds(1.5F);
        bot1.image.color = Color.white;
        bot1.interactable = true;
        bot2.image.color = Color.white;
        bot2.interactable = true;
        bot3.image.color = Color.white;
        bot3.interactable = true;
        TotalQScript.TotalPreguntas -= 1;
        Calcular();
    }

    public void Alt1_accion()
    {
        if (ans1.text == Respuesta.ToString())
        {
            bot1.image.color = Color.green;
            esCorrecta = true;
            Sonido(esCorrecta);
            ScoreScript.ScoreValue += 50;
            bot1.interactable = false;
            bot2.interactable = false;
            bot3.interactable = false;
            StartCoroutine(SiguientePregunta());
            CorrectScript.Acertadas += 1;
            if (TotalQScript.TotalPreguntas == 0)
            {
                if (CorrectScript.Acertadas >= 5) //Completa las preguntas con mas de la mitad
                {
                    GameOver();
                    if ((PlayerPrefs.GetInt("NoErrors") < 1) && vidasRestantes == 3)
                    {
                        PlayerPrefs.SetInt("NoErrors", noErrors);
                        PlayerPrefs.Save();
                    }
                }
                if (CorrectScript.Acertadas < 5) //No llega a la mitad
                { GameOverLose(); }
            }

        }
        else
        {
            esCorrecta = false;
            Sonido(esCorrecta);
            vidasRestantes--;
            lifeScript.ReducirVidas(vidasRestantes);
            if(vidasRestantes == 0)
            {
                GameOverLose();
            }
            bot1.image.color = Color.red;
            bot1.interactable = false;
            bot2.interactable = false;
            bot3.interactable = false;
            StartCoroutine(SiguientePregunta());
            if (TotalQScript.TotalPreguntas == 0)
            {
                if (CorrectScript.Acertadas >= 5) //Completa las preguntas con mas de la mitad
                {
                    GameOver();
                }
                if (CorrectScript.Acertadas < 5) //No llega a la mitad
                { GameOverLose(); }
            }

            if (ScoreScript.ScoreValue == 0)
            {
                ScoreScript.ScoreValue += 0;
            }
            else
            {
                ScoreScript.ScoreValue -= 10;
            }
        }
    }

    public void Alt2_accion()
    {
        if (ans2.text == Respuesta.ToString())
        {
            esCorrecta = true;
            Sonido(esCorrecta);
            bot1.interactable = false;
            bot2.interactable = false;
            bot3.interactable = false;
            bot2.image.color = Color.green;
            ScoreScript.ScoreValue += 50;
            Debug.Log("Respuesta Correcta!");
            StartCoroutine(SiguientePregunta());
            CorrectScript.Acertadas += 1;
            if (TotalQScript.TotalPreguntas == 0)
            {
                if (CorrectScript.Acertadas >= 5) //Completa las preguntas con mas de la mitad
                {
                    GameOver();
                    if ((PlayerPrefs.GetInt("NoErrors") < 1) && vidasRestantes == 3)
                    {
                        PlayerPrefs.SetInt("NoErrors", noErrors);
                        PlayerPrefs.Save();
                    }
                }
                if (CorrectScript.Acertadas < 5) //No llega a la mitad
                { GameOverLose(); }
            }
        }
        else
        {
            esCorrecta = false;
            Sonido(esCorrecta);
            vidasRestantes--;
            lifeScript.ReducirVidas(vidasRestantes);
            if (vidasRestantes == 0)
            {
                GameOverLose();
            }
            bot2.image.color = Color.red;
            if (ScoreScript.ScoreValue == 0)
            {
                ScoreScript.ScoreValue += 0;
            }
            else
            {
                ScoreScript.ScoreValue -= 10;
            }
            Debug.Log("Intenta de Nuevo :(");
            bot1.interactable = false;
            bot2.interactable = false;
            bot3.interactable = false;
            StartCoroutine(SiguientePregunta());
            if (TotalQScript.TotalPreguntas == 0)
            {
                if (CorrectScript.Acertadas >= 5) //Completa las preguntas con mas de la mitad
                {
                    GameOver();
                }
                if (CorrectScript.Acertadas < 5) //No llega a la mitad
                { GameOverLose(); }
            }
        }
    }

    public void Alt3_accion()
    {
        if (ans3.text == Respuesta.ToString())
        {
            esCorrecta = true;
            Sonido(esCorrecta);
            bot3.image.color = Color.green;
            bot1.interactable = false;
            bot2.interactable = false;
            bot3.interactable = false;
            ScoreScript.ScoreValue += 50;
            Debug.Log("Respuesta Correcta!");
            StartCoroutine(SiguientePregunta());
            CorrectScript.Acertadas += 1;
            if (TotalQScript.TotalPreguntas == 0)
            {
                if (CorrectScript.Acertadas >= 5) //Completa las preguntas con mas de la mitad
                {
                    GameOver();
                    if ((PlayerPrefs.GetInt("NoErrors") < 1) && vidasRestantes == 3)
                    {
                        PlayerPrefs.SetInt("NoErrors", noErrors);
                        PlayerPrefs.Save();
                    }
                }
                if (CorrectScript.Acertadas < 5) //No llega a la mitad
                { GameOverLose(); }
            }
        }
        else
        {
            esCorrecta = false;
            Sonido(esCorrecta);
            vidasRestantes--;
            lifeScript.ReducirVidas(vidasRestantes);

            if (vidasRestantes == 0)
            {
                GameOverLose();
            }
            bot3.image.color = Color.red;
            bot1.interactable = false;
            bot2.interactable = false;
            bot3.interactable = false;
            StartCoroutine(SiguientePregunta());
            if (ScoreScript.ScoreValue == 0)
            {
                ScoreScript.ScoreValue += 0;
            }
            else
            {
                ScoreScript.ScoreValue -= 10;
            }

            Debug.Log("Intenta de Nuevo :(");
            if (TotalQScript.TotalPreguntas == 0)
            {
                if (CorrectScript.Acertadas >= 5) //Completa las preguntas con mas de la mitad
                {
                    GameOver();
                }
                if (CorrectScript.Acertadas < 5) //No llega a la mitad
                { GameOverLose(); }
            }
        }
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(aplausos, 0.7F);
        gameStatus = GameStatus.NEXT;
        if(nivelCompletado < nextSceneLoad)
        {
            if(nivelCompletado < 2)
                PlayerPrefs.SetInt("nivelCompletado", nextSceneLoad);
        }
        if(ScoreScript.ScoreValue > highScore)
        {
            HighScoreW.SetActive(true);
            HighScoreScript.hsValue = ScoreScript.ScoreValue;
            highScore = HighScoreScript.hsValue;
            PlayerPrefs.SetInt("HighScoreNivel1", highScore);
            PlayerPrefs.Save();
        }
        if((PlayerPrefs.GetInt("FullLife") < 1) && vidasRestantes == 3)
        {
            PlayerPrefs.SetInt("FullLife", 1);
            PlayerPrefs.Save();
        }
        //Nivel 1
        if (ScoreScript.ScoreValue <= 150 && ScoreScript.ScoreValue > 20)
        {
            stars[0].color = Color.yellow;

        }
        else if (ScoreScript.ScoreValue < 300 && ScoreScript.ScoreValue > 150)
        {
            stars[0].color = Color.yellow;
            stars[1].color = Color.yellow;
        }
        else if (ScoreScript.ScoreValue >= 300)
        {
            stars[0].color = Color.yellow;
            stars[1].color = Color.yellow;
            stars[2].color = Color.yellow;
            if(PlayerPrefs.GetInt("ThreeStars") < 1)
            {
                PlayerPrefs.SetInt("ThreeStars", starIndex);
                PlayerPrefs.Save();
            }
        }
        gameOverPanel.SetActive(true);
    }

    public void GameOverLose()
    {
        gameStatus = GameStatus.NEXT;
        if (ScoreScript.ScoreValue > highScore)
        {
            HighScoreL.SetActive(true);
            HighScoreScript.hsValue = ScoreScript.ScoreValue;
            highScore = HighScoreScript.hsValue;
            PlayerPrefs.SetInt("HighScoreNivel1", highScore);
            PlayerPrefs.Save();
        }
        //Nivel 1
        if (ScoreScript.ScoreValue <= 150 && ScoreScript.ScoreValue > 20)
        {
            stars[3].color = Color.yellow;

        }
        else if (ScoreScript.ScoreValue <= 300 && ScoreScript.ScoreValue > 150)
        {
            stars[3].color = Color.yellow;
            stars[4].color = Color.yellow;
        }
        else if (ScoreScript.ScoreValue >= 300)
        {
            stars[3].color = Color.yellow;
            stars[4].color = Color.yellow;
            stars[5].color = Color.yellow;
            if (PlayerPrefs.GetInt("ThreeStars") < 1)
            {
                PlayerPrefs.SetInt("ThreeStars", starIndex);
                PlayerPrefs.Save();
            }
        }
        gameOverLosePanel.SetActive(true);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneLoad);
    }

    public void ReintentarButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartGame();
    }
    void Sonido(bool answer)
    {
        audioSource.GetComponent<AudioSource>();
        if(answer == true)
        {
            audioSource.PlayOneShot(correcta, 0.7F);
        }
        else
        {
            audioSource.PlayOneShot(incorrecta, 0.7F);
        }
    }
}

public static class ArrayExtensions
{
    // This is an extension method. RandomItem() will now exist on all arrays.
    public static T RandomItem<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }
}

[SerializeField]
public enum GameStatus
{
    PLAYING,
    NEXT
}