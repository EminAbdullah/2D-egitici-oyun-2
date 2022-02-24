using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CountdownManager : MonoBehaviour
{
    [SerializeField]
    private GameObject CountdownObject;

    [SerializeField]
    private Text CountdownText;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

  
    IEnumerator CountdownRoutine()
    {
        yield return new WaitForSeconds(1.7f);
       
        CountdownText.text = "3";
        yield return new WaitForSeconds(1);
        CountdownObject.GetComponent<RectTransform>().DOScale(1, 0.5f);

        yield return new WaitForSeconds(1);
        CountdownObject.GetComponent<RectTransform>().DOScale(0, 0.5f);
        yield return new WaitForSeconds(0.3f);

        CountdownText.text = "2";
        CountdownObject.GetComponent<RectTransform>().DOScale(1, 0.5f);

        yield return new WaitForSeconds(1);
        CountdownObject.GetComponent<RectTransform>().DOScale(0, 0.5f);
        yield return new WaitForSeconds(0.3f);

        CountdownText.text = "1";
        CountdownObject.GetComponent<RectTransform>().DOScale(1, 0.5f);
        yield return new WaitForSeconds(1);
        CountdownObject.GetComponent<RectTransform>().DOScale(0, 1f).SetEase(Ease.OutBack);

        StopAllCoroutines();

        gameManager.startGame();

       }
}
