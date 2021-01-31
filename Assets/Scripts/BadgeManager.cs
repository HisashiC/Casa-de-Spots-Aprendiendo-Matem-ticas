using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BadgeManager : MonoBehaviour
{
    [SerializeField] private List<BadgeScriptable> achievementList;
    [SerializeField] public List<Button> badgesButton;
    [SerializeField] public List<Image> achievementImg;
    [SerializeField] public GameObject[] lockIcon, unlockIcon;

    private List<Badge> badges;
    private BadgeScriptable badgeScriptable;
    List<Image> badgeImage;
    int score, stars, levelComplete, fullLifes, noErrors, threeStars;
    public Color azul = new Vector4(53F, 214F, 231F, 255F);



    // Start is called before the first frame update
    void Start()
    {
        //Crear todos los botones
        for (int i = 0; i < badgesButton.Count; i++)
        {
            Button localBtn = badgesButton[i];
        }
        
        badges = new List<Badge>();
        badgeScriptable = achievementList[0];
        badges.AddRange(badgeScriptable.achievements);

        //Asignar a todos los botones
        for (int i = 0; i < badgesButton.Count; i++)
        {
            achievementImg[i].GetComponentInChildren<Image>().sprite = badges[i].medalla;
            badgesButton[i].GetComponentInChildren<Text>().text = badges[i].title;   //set the name of button
            badgesButton[i].GetComponentInChildren<TextMeshProUGUI>().text = badges[i].descripcion;
        }
    }
    void Update()
    {
        levelComplete = PlayerPrefs.GetInt("nivelCompletado");
        //Logros del 2 al 6
        switch(levelComplete)
        {
            case 3:
                for (int i = 1; i < 2; i++)
                {
                    badgesButton[i].image.color = azul;
                    badgesButton[i].interactable = true;
                    lockIcon[i].SetActive(false);
                    unlockIcon[i].SetActive(true);
                }
                break;
            case 4:
                for (int i = 1; i < 3; i++)
                {
                    badgesButton[i].image.color = azul;
                    badgesButton[i].interactable = true;
                    lockIcon[i].SetActive(false);
                    unlockIcon[i].SetActive(true);
                }
                break;
            case 5:
                for (int i = 1; i < 4; i++)
                {
                    badgesButton[i].image.color = azul;
                    badgesButton[i].interactable = true;
                    lockIcon[i].SetActive(false);
                    unlockIcon[i].SetActive(true);
                }
                break;
            case 6:
                for (int i = 1; i < 6; i++)
                {
                    badgesButton[i].image.color = azul;
                    badgesButton[i].interactable = true;
                    lockIcon[i].SetActive(false);
                    unlockIcon[i].SetActive(true);
                }
                break;
        }
        //Logro 1
        if (levelComplete > 2)
        {
            badgesButton[0].image.color = azul;
            badgesButton[0].interactable = true;
            lockIcon[0].SetActive(false);
            unlockIcon[0].SetActive(true);
        }
        //Logro 8
        if(PlayerPrefs.GetInt("ThreeStars") == 1)
        {
            badgesButton[7].image.color = azul;
            badgesButton[7].interactable = true;
            lockIcon[7].SetActive(false);
            unlockIcon[7].SetActive(true);
        }
        //Logro 10
        if ((PlayerPrefs.GetInt("ThreeStars2") == 1) && (PlayerPrefs.GetInt("ThreeStars3") == 1) && (PlayerPrefs.GetInt("ThreeStars4") == 1))
        {
            badgesButton[9].image.color = azul;
            badgesButton[9].interactable = true;
            lockIcon[9].SetActive(false);
            unlockIcon[9].SetActive(true);
        }
        //Logro 7
        fullLifes = PlayerPrefs.GetInt("FullLife");
        if (fullLifes == 1)
        {
            badgesButton[6].image.color = azul;
            badgesButton[6].interactable = true;
            lockIcon[6].SetActive(false);
            unlockIcon[6].SetActive(true);
        }
        if ((PlayerPrefs.GetInt("NoErrors") == 1) && (PlayerPrefs.GetInt("NoErrors2") == 1) && (PlayerPrefs.GetInt("NoErrors3") == 1) && (PlayerPrefs.GetInt("NoErrors4") == 1))
        {
            badgesButton[8].image.color = azul;
            badgesButton[8].interactable = true;
            lockIcon[8].SetActive(false);
            unlockIcon[8].SetActive(true);
        }
        
    }

}
[System.Serializable]
public class Badge
{
    public string title;
    public Sprite medalla;
    public string descripcion;
}
