using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LearnScript : MonoBehaviour
{
    public GameObject buts, botontablas;
    public GameObject panel1, panel2, panel3, panel4, paneltablas, menu, suma, resta, multi, div;
    int primerValor, segundoValor, resultado, cociente, residuo, valorTemporal;
    float resultadoDiv;
    public TextMeshProUGUI sumamenu, restamenu, multimenu, divmenu, Snum1, Snum2, Sres, Rnum1, Rnum2, RRes, Mnum1, Mnum2, MRes, Dnum1, Dnum2, Ddiv, Dcoc, Dres;
    public Text sumatext, restatext, multitext, divtext, pares, impares, frac1, frac2, figuras;
    string coc1, res1;

    public void Arit_accion()
    {
        if(panel1 != null)
        {
            bool isActive = panel1.activeSelf;
            panel1.SetActive(!isActive);
            buts.SetActive(false);
            StartCoroutine(TypeSentenceMenu("¡Sumas! ¡Añade más números!", sumamenu));
            StartCoroutine(TypeSentenceMenu("¡Restas! ¡Sustrae, quita, reduce!", restamenu));
            StartCoroutine(TypeSentenceMenu("¡Multiplicación! ¡Suma varias veces!", multimenu));
            StartCoroutine(TypeSentenceMenu("¡Simplifica con la división!", divmenu));
        }
    }

    public void Digitos_accion()
    {
        if (panel2 != null)
        {
            bool isActive = panel2.activeSelf;
            panel2.SetActive(!isActive);
            buts.SetActive(false);
            StartCoroutine(TypeSentence("Si el número termina en 0, 2, 4, 6 u 8, ¡es par!", pares));
            StartCoroutine(TypeSentence("Si el número termina en 1, 3, 5, 7 o 9, ¡es impar!", impares));
        }
    }
    public void Frac_accion()
    {
        if (panel3 != null)
        {
            bool isActive = panel3.activeSelf;
            panel3.SetActive(!isActive);
            buts.SetActive(false);
            StartCoroutine(TypeSentence("Las fracciones son las partes iguales de un número.", frac1));
            StartCoroutine(TypeSentence("Arriba: Numerador. Abajo Denominador.", frac2));
        }
    }

    public void TablasMulti()
    {
        if (paneltablas != null)
        {
            bool isActive = paneltablas.activeSelf;
            paneltablas.SetActive(!isActive);
            buts.SetActive(false);
        }
    }

    public void Shapes_accion()
    {
        if (panel4 != null)
        {
            bool isActive = panel4.activeSelf;
            panel4.SetActive(!isActive);
            buts.SetActive(false);
            StartCoroutine(TypeSentence("Estas son las figuras básicas que debes saber.", figuras));
        }
    }
    public void Sumas_accion()
    {
        suma.SetActive(true);
        menu.SetActive(false);
        primerValor = UnityEngine.Random.Range(1, 10);
        segundoValor = UnityEngine.Random.Range(1, 10);
        Snum1.text = primerValor.ToString();
        Snum2.text = segundoValor.ToString();

        resultado= primerValor + segundoValor;
        Sres.text = resultado.ToString();

        StartCoroutine(TypeSentence("La suma de dos números, ¡equivale a un número más grande!", sumatext));
    }
    public void Restas_accion()
    {
        primerValor = UnityEngine.Random.Range(1, 10);
        segundoValor = UnityEngine.Random.Range(1, 10);

        if (primerValor - segundoValor < 0)
        {
            valorTemporal = segundoValor;
            segundoValor = primerValor;
            primerValor = valorTemporal;
        }

        Rnum1.text = primerValor.ToString();
        Rnum2.text = segundoValor.ToString();

        resultado = primerValor - segundoValor;
        RRes.text = resultado.ToString();

        resta.SetActive(true);
        menu.SetActive(false);
        StartCoroutine(TypeSentence("¡Restar un número con otro número da un número más pequeño!", restatext));
    }
    public void Multiplicacion_accion()
    {
        primerValor = UnityEngine.Random.Range(1, 10);
        segundoValor = UnityEngine.Random.Range(1, 10);
        Mnum1.text = primerValor.ToString();
        Mnum2.text = segundoValor.ToString();

        resultado = primerValor * segundoValor;
        MRes.text = resultado.ToString();
        multi.SetActive(true);
        menu.SetActive(false);
        StartCoroutine(TypeSentence("¡Multiplicar un número con otro, puede dar un número enoooooorme!", multitext));
    }
    public void Divi_accion()
    {
        primerValor = UnityEngine.Random.Range(1, 10);
        segundoValor = UnityEngine.Random.Range(1, 10);
        if (primerValor < segundoValor)
        {
            valorTemporal = segundoValor;
            segundoValor = primerValor;
            primerValor = valorTemporal;
        }
        Dnum1.text = primerValor.ToString();
        Dnum2.text = segundoValor.ToString();

        resultadoDiv = primerValor / segundoValor;
        Ddiv.text = resultadoDiv.ToString();

        cociente = primerValor / segundoValor;
        residuo = primerValor % segundoValor;

        coc1 = "Cociente: " + cociente.ToString();
        res1= "Residuo: " + residuo.ToString();
        div.SetActive(true);
        menu.SetActive(false);
        StartCoroutine(TypeSentence("¡Simplificas el número a una porción más pequeña! En este juego solo necesitas el cociente.", divtext));
        StartCoroutine(TypeSentenceMenu(coc1, Dcoc));
        StartCoroutine(TypeSentenceMenu(res1, Dres));
    }

    public void PanelBackSuma()
    {
        menu.SetActive(true);
        suma.SetActive(false);
    }
    public void PanelBackResta()
    {
        menu.SetActive(true);
        resta.SetActive(false);
    }
    public void PanelBackMulti()
    {
        menu.SetActive(true);
        multi.SetActive(false);
    }
    public void PanelBackDiv()
    {
        menu.SetActive(true);
        div.SetActive(false);
    }
    public void PanelBackArit()
    {
        buts.SetActive(true);
        panel1.SetActive(false);
    }
    public void PanelBackFrac()
    {
        buts.SetActive(true);
        panel3.SetActive(false);
    }
    public void PanelBackDig()
    {
        buts.SetActive(true);
        panel2.SetActive(false);
    }
    public void PanelBackShap()
    {
        buts.SetActive(true);
        panel4.SetActive(false);
    }
    public void PanelBacktablas()
    {
        buts.SetActive(true);
        paneltablas.SetActive(false);
    }

    public void ButtonBack()
    {
        SceneManager.LoadScene("MenuOpciones");
    }

    IEnumerator TypeSentence(string sentence, Text texto)
    {
        texto.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            texto.text += letter;
            yield return null;
        }
    }

    IEnumerator TypeSentenceMenu(string sentence, TextMeshProUGUI texto)
    {
        texto.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            texto.text += letter;
            yield return null;
        }
    }
}
