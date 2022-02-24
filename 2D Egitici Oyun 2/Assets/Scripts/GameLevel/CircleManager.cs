using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CircleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] circleArray;
    // Start is called before the first frame update
    void Start()
    {
        closeCircles();
    }

    void closeCircles()
    {

        for (int i = 0; i < circleArray.Length; i++)
        {
            circleArray[i].GetComponent<RectTransform>().localScale = Vector3.zero;
        }

    }

    public void openCircles(int whichCircle)
    {
        circleArray[whichCircle].GetComponent<Image>().color = Color.white;
        circleArray[whichCircle].GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);
        if (whichCircle%5==0)
        {
            closeCircles();
        }

    }

    public void openCirclesRed(int whichCircle)
    {

        circleArray[whichCircle].GetComponent<Image>().color = Color.red;
        circleArray[whichCircle].GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);
        if (whichCircle % 5 == 0)
        {
            closeCircles();
        }

    }
}
