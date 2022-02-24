using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon, falseIcon;
  
    public void startTrueIconOpen()
    {

        StartCoroutine(trueIconOpen());
    }

   IEnumerator trueIconOpen()
    {
        trueIcon.GetComponent<RectTransform>().DOScale(1, 0.5f);
        yield return new WaitForSeconds(0.3f);
        trueIcon.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.OutBack);

    }
    public void startFalseIconOpen()
    {

        StartCoroutine(falseIconOpen());
    }

    IEnumerator falseIconOpen()
    {
        falseIcon.GetComponent<RectTransform>().DOScale(1, 0.5f);
        yield return new WaitForSeconds(0.3f);
        falseIcon.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.OutBack);

    }

}
