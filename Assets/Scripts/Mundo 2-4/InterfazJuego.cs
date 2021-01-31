using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InterfazJuego : MonoBehaviour
{
#pragma warning disable 649 
    //Objetos utilizables en el nivel
    [SerializeField] private Mundo2Quiz quizManager;               //Lógica del nivel
    [SerializeField] private Text scoreText, timerText, totalScore, totalScoreLose, acertadas, faltantes, correctQuestions, correctLose, maxScore, msWin, msLose; //Textos de estadísticas
    [SerializeField] private List<Image> lifeImageList;             //Vidas
    [SerializeField] private GameObject gameOverPanel, gameOverLose, gamePanel; //Paneles
    [SerializeField] private Image questionImg;                     //Imagen de la pregunta
    [SerializeField] private Text questionInfoText;                 //Pregunta
    [SerializeField] private List<Button> options;                  //Alternativas
    [SerializeField] public List<Image> starImageList;              //Estrellas
    [SerializeField] public GameObject newHSW, newHSL;              //Puntajes máximos
    [SerializeField] private Text Congratulations;                  //Felicitaciones
#pragma warning restore 649

    private Pregunta question;          
    private bool answered = false;     

    public Text TimerText { get => timerText; }
    public Text ScoreText { get => scoreText; }
    public Text CorrectText { get => acertadas; }
    public Text LoseScore { get => totalScoreLose; }
    public Text TotalScore { get => totalScore; }
    public Text RemainingQues { get => faltantes; }
    public Text altaPunt { get => maxScore; }
    public Text altaPuntV { get => msWin; }
    public Text altaPuntL { get => msLose; }
    public Text CorrectQuestions { get => correctQuestions; }
    public Text CorrectQuestionsLose { get => correctLose; }
    public GameObject GameOverPanel { get => gameOverPanel; }
    public GameObject GameOverLosePanel { get => gameOverLose; }
    public Text congrats { get => Congratulations; }

    // Inicializar panel
    void Start()
    {
        //Instanciar botones
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    private void Update()
    {
        gamePanel.SetActive(true); //Activar panel de las preguntas
    }

    public void SetQuestion(Pregunta question)
    {
        this.question = question; //Elegir pregunta
        switch (question.questionType) //Activar objetos segun tipo de pregunta
        {
            case TipoPregunta.TEXT:
                questionImg.transform.parent.gameObject.SetActive(false);   //Desactivar imagen
                break;
            case TipoPregunta.IMAGE:
                questionImg.transform.parent.gameObject.SetActive(true);    //Activar imagenes
                questionImg.transform.gameObject.SetActive(true);
                questionImg.sprite = question.questionImage;                //Fijar imagen de la pregunta
                break;
        }

        questionInfoText.text = question.questionInfo;                      //Fijar pregunta a resolver

        List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question.options); //Barajear las opciones

        for (int i = 0; i < options.Count; i++)
        {
            //Fijar los botones y textos de las alternativas
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = ansOptions[i];
            options[i].name = ansOptions[i];
            options[i].image.color = Color.white;
        }

        answered = false;

    }

    public void ReduceLife(int remainingLife) //Reducir vidas (las colorea de rojo)
    {
        lifeImageList[remainingLife].color = Color.red;
    }

    void OnClick(Button btn)
    {
        if (quizManager.GameStatus == GameStatus1.PLAYING)
        {
            if (!answered) //Si es incorrecta
            {       
                answered = true;                          //Verdadero
                bool val = quizManager.Answer(btn.name); //Valor de la respuesta seleccionada

                //Si es verdadero
                if (val)    
                {
                    //Colorear de verde
                    btn.image.color = Color.green;
                    StartCoroutine(BlinkImg(btn.image));
                }
                else
                {
                    //Colorear de rojo
                    btn.image.color = Color.red;
                }
            }
        }
    }

    IEnumerator BlinkImg(Image img)
    {
        for (int i = 0; i < 2; i++)
        {
            img.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            img.color = Color.green;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void RestryButton() //Reintentar
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        quizManager.StartGame();
    }
}
