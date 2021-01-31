using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    [SerializeField] private List<Image> lifeImageList;

    // Start is called before the first frame update

    public void ReducirVidas(int remainingLife)
    {
        lifeImageList[remainingLife].color = Color.red;
    }
}
