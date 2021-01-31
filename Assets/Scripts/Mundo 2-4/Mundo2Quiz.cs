using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Mundo2Quiz : MonoBehaviour
{
#pragma warning disable 649
    //Seleccionar interfaces, preguntas y tiempo
    [SerializeField] private InterfazJuego quizGameUI;
    [SerializeField] private List<ArchivosPreguntas> quizDataList;
    [SerializeField] private float timeInSeconds;
#pragma warning restore 649

    private List<Pregunta> questions;
    private Pregunta selectedQuetion = new Pregunta();
    private int gameScore, acertadas, preguntas, lifesRemaining;
    int nextSceneLoad, nivelCompletado;
    private float currentTime;
    private ArchivosPreguntas dataScriptable;
    int nivelActual, maxScore, threeStars, starIndex, noErrors, sinError, tresEstr;

    public AudioClip music, correcta, incorrecta, aplausos;
    public AudioSource audioSource;

    private GameStatus1 gameStatus = GameStatus1.NEXT;

    public GameStatus1 GameStatus { get { return gameStatus; } }

    public List<ArchivosPreguntas> QuizData { get => quizDataList; }

    //Iniciar Escena
    private void Start()
    {
        //Inicializar variables
        sinError = PlayerPrefs.GetInt("NoErrors");
        tresEstr = PlayerPrefs.GetInt("ThreeStars");
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        nivelActual = SceneManager.GetActiveScene().buildIndex;
        //Puntajes máximos
        switch (nivelActual)
        {
            case 3:
                maxScore = PlayerPrefs.GetInt("HighScoreNivel2");
                break;

            case 4:
                maxScore = PlayerPrefs.GetInt("HighScoreNivel3");
                break;

            case 5:
                maxScore = PlayerPrefs.GetInt("HighScoreNivel4");
                break;

        }
        threeStars = PlayerPrefs.GetInt("ThreeStars");
        nivelCompletado = PlayerPrefs.GetInt("nivelCompletado");
        noErrors = 1;
        StartGame();
    }

    //Iniciar juego
    public void StartGame()
    {
        audioSource.GetComponent<AudioSource>();
        audioSource.PlayOneShot(music, 0.7F);
        gameScore = 0;
        acertadas = 0;
        preguntas = 0;
        lifesRemaining = 3;
        currentTime = timeInSeconds;
        questions = new List<Pregunta>(); //Configurar preguntas
        dataScriptable = quizDataList[0];
        questions.AddRange(dataScriptable.questions);
        SelectQuestion(); //Elegir pregunta
        gameStatus = GameStatus1.PLAYING;
    }

    void Sonido(bool answer)
    {
        audioSource.GetComponent<AudioSource>();
        if (answer == true)
        {
            audioSource.PlayOneShot(correcta, 0.7F);
        }
        else
        {
            audioSource.PlayOneShot(incorrecta, 0.7F);
        }
    }

    private void SelectQuestion()
    {
        //Visualizar textos
        quizGameUI.altaPunt.text = "Alta puntuación: " + maxScore;
        quizGameUI.CorrectText.text = "Acertadas: " + acertadas;
        quizGameUI.RemainingQues.text = "Faltantes: " + questions.Count;
        int val = UnityEngine.Random.Range(0, questions.Count); //Valor al azar
        selectedQuetion = questions[val]; //Enviar pregunta al juego 
        quizGameUI.SetQuestion(selectedQuetion);

        questions.RemoveAt(val);

    }

    private void Update() //Actualizar tiempo
    {
        if (gameStatus == GameStatus1.PLAYING)
        {
            currentTime -= Time.deltaTime;
            DisplayTime(currentTime);
        }
    }
    void DisplayTime(float timeToDisplay) //Mostrar tiempo
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        quizGameUI.TimerText.text = time.ToString("mm':'ss");

        if (currentTime <= 0)
        {
            if (acertadas >= 5) { GameOver(); }
            if (acertadas < 5) { GameOverLose(); }
        }
    }
    public bool Answer(string selectedOption)
    {
        bool correct = false; //Fijar valor
        if (selectedQuetion.correctAns == selectedOption) //Si la respuesta es la correcta
        {
            correct = true; //Es correcta
            Sonido(correct);
            acertadas += 1;
            preguntas += 1;
            if (gameScore >= 0)
            {
                gameScore += 50;
            }
            quizGameUI.ScoreText.text = "Puntaje: " + gameScore;
            quizGameUI.CorrectText.text = "Acertadas: " + acertadas;
            quizGameUI.RemainingQues.text = "Faltantes: " + questions.Count;
        }
        else //Incorrecta
        {
            correct = false;
            Sonido(correct);
            lifesRemaining--;
            if (gameScore > 0)
            {
                gameScore -= 10;
            }
            else
            {
                gameScore -= 0;
            }
            quizGameUI.ScoreText.text = "Puntaje: " + gameScore;
            quizGameUI.ReduceLife(lifesRemaining);
            preguntas += 1;

            if (lifesRemaining == 0)
            {
                GameOverLose();
            }
        }

        if (gameStatus == GameStatus1.PLAYING)
        {
            if (questions.Count > 0)
            {
                //Siguiente pregunta
                Invoke("SelectQuestion", 1.5f);
            }
            else
            {
                if (acertadas >= 5) //Si acertó cinco o más
                {
                    GameOver();
                    if (lifesRemaining == 3)
                    {
                        switch (nivelActual) //Guardar variables para premios
                        {
                            case 3:
                                PlayerPrefs.SetInt("NoErrors2", 1);
                                PlayerPrefs.Save();
                                break;
                            case 4:
                                PlayerPrefs.SetInt("NoErrors3", 1);
                                PlayerPrefs.Save();
                                break;
                            case 5:
                                PlayerPrefs.SetInt("NoErrors4", 1);
                                PlayerPrefs.Save();
                                break;
                        }
                    }
                }
                if (acertadas < 5) { GameOverLose(); }
            }
        }
        return correct;
    }

    public void GameOver() //Pasa al siguiente nivel
    {
        audioSource.PlayOneShot(aplausos, 0.7F);
        gameStatus = GameStatus1.NEXT;
        if (nivelCompletado < nextSceneLoad)
        {
            PlayerPrefs.SetInt("nivelCompletado", nextSceneLoad);
        }
        quizGameUI.GameOverPanel.SetActive(true);
        quizGameUI.congrats.text = "¡Felicitaciones " + PlayerPrefs.GetString("Name") + "! ¡Has Ganado!";
        quizGameUI.TotalScore.text = "Puntaje Total: " + gameScore + " puntos";
        quizGameUI.CorrectQuestions.text = "Preguntas acertadas: " + acertadas;
        if ((PlayerPrefs.GetInt("FullLife") < 1) && lifesRemaining == 3)
        {
            PlayerPrefs.SetInt("FullLife", 1);
            PlayerPrefs.Save();
        }
        if (gameScore > maxScore)
        {
            quizGameUI.newHSW.SetActive(true);
            maxScore = gameScore;
            switch (nivelActual) //Guardar variables para premios
            {
                case 3:
                    PlayerPrefs.SetInt("HighScoreNivel2", maxScore);
                    PlayerPrefs.Save();
                    break;

                case 4:
                    PlayerPrefs.SetInt("HighScoreNivel3", maxScore);
                    PlayerPrefs.Save();
                    break;

                case 5:
                    PlayerPrefs.SetInt("HighScoreNivel4", maxScore);
                    PlayerPrefs.Save();
                    break;
            }
        }
        switch (nivelActual) //Guardar variables para altas puntuaciones
        {
            case 3:
                quizGameUI.altaPuntV.text = "Alta Puntuación: " + maxScore;
                break;

            case 4:
                quizGameUI.altaPuntV.text = "Alta Puntuación: " + maxScore;
                break;

            case 5:
                quizGameUI.altaPuntV.text = "Alta Puntuación: " + maxScore;
                break;
        }
        if (gameScore <= 150 && gameScore >= 20)
        {
            quizGameUI.starImageList[3].color = Color.yellow;

        }
        else if (gameScore <= 300 && gameScore > 150)
        {
            quizGameUI.starImageList[3].color = Color.yellow;
            quizGameUI.starImageList[4].color = Color.yellow;
        }
        else if (gameScore > 300)
        {
            quizGameUI.starImageList[3].color = Color.yellow;
            quizGameUI.starImageList[4].color = Color.yellow;
            quizGameUI.starImageList[5].color = Color.yellow;

            switch (nivelActual) //Guardar variables para estrellas
            {
                case 3:
                    PlayerPrefs.SetInt("ThreeStars2", 1);
                    PlayerPrefs.Save();
                    break;
                case 4:
                    PlayerPrefs.SetInt("ThreeStars3", 1);
                    PlayerPrefs.Save();
                    break;
                case 5:
                    PlayerPrefs.SetInt("ThreeStars4", 1);
                    PlayerPrefs.Save();
                    break;
            }
        }
    }
    public void GameOverLose() //Pierde el nivel
    {
        gameStatus = GameStatus1.NEXT;
        quizGameUI.GameOverLosePanel.SetActive(true);
        quizGameUI.LoseScore.text = "Puntaje Total: " + gameScore + " puntos";
        quizGameUI.CorrectQuestionsLose.text = "Preguntas acertadas: " + acertadas;
        if (gameScore > maxScore)
        {
            quizGameUI.newHSL.SetActive(true);
            maxScore = gameScore;
            switch (nivelActual) //Guardar variables para premios
            {
                case 3:
                    PlayerPrefs.SetInt("HighScoreNivel2", maxScore);
                    PlayerPrefs.Save();
                    break;

                case 4:
                    PlayerPrefs.SetInt("HighScoreNivel3", maxScore);
                    PlayerPrefs.Save();
                    break;

                case 5:
                    PlayerPrefs.SetInt("HighScoreNivel4", maxScore);
                    PlayerPrefs.Save();
                    break;
            }
        }
        switch (nivelActual)  //Guardar variables para altas puntuaciones
        {
            case 3:
                quizGameUI.altaPuntL.text = "Alta Puntuación: " + maxScore;
                break;

            case 4:
                quizGameUI.altaPuntL.text = "Alta Puntuación: " + maxScore;
                break;

            case 5:
                quizGameUI.altaPuntL.text = "Alta Puntuación: " + maxScore;
                break;
        }
        if (gameScore <= 150 && gameScore >= 20)
        {
            quizGameUI.starImageList[0].color = Color.yellow;

        }
        else if (gameScore <= 300 && gameScore > 150)
        {
            quizGameUI.starImageList[0].color = Color.yellow;
            quizGameUI.starImageList[1].color = Color.yellow;
        }
        else if (gameScore > 300)
        {
            quizGameUI.starImageList[0].color = Color.yellow;
            quizGameUI.starImageList[1].color = Color.yellow;
            quizGameUI.starImageList[2].color = Color.yellow;
            switch (nivelActual) //Guardar variables para estrellas
            {
                case 3:
                    PlayerPrefs.SetInt("ThreeStars2", 1);
                    PlayerPrefs.Save();
                    break;
                case 4:
                    PlayerPrefs.SetInt("ThreeStars3", 1);
                    PlayerPrefs.Save();
                    break;
                case 5:
                    PlayerPrefs.SetInt("ThreeStars4", 1);
                    PlayerPrefs.Save();
                    break;
            }
        }
    }
    
    public void NextLevel() //Siguiente nivel
    {
        SceneManager.LoadScene(nextSceneLoad);
    }
}

//Preguntas
[System.Serializable]
public class Pregunta
{
    public string questionInfo;         //Texto de la pregunta
    public TipoPregunta questionType;   //Tipo de la pregunta (imagen, texto)
    public Sprite questionImage;        //Imagen de la pregunta
    public List<string> options;        //Alternativas
    public string correctAns;           //Respuesta correcta
}

[System.Serializable]
public enum TipoPregunta
{
    TEXT,
    IMAGE
}

[SerializeField]
public enum GameStatus1
{
    PLAYING,
    NEXT
}