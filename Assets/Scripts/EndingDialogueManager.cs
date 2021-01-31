using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingDialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject endingPanel1, endingPanel2;
    public Text dialogo;
    public Image img1, img2, img3;
    public Dialogue dialogue;
    public Text name;

    int sent;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        sent = 0;
        StartDialogue(dialogue);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        endingPanel1.SetActive(true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            if (sent == 1) {
                img1.enabled = false;
                img2.enabled = true;
            }
            if(sent == 3)
            {
                img2.enabled = false;
                img3.enabled = true;
            }
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
        sent++;
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogo.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogo.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        endingPanel1.SetActive(false);
        endingPanel2.SetActive(true);
        name.text = "¡Felicitaciones " + PlayerPrefs.GetString("Name") + "! ¡Gracias por jugar mi juego!";
    }

}
