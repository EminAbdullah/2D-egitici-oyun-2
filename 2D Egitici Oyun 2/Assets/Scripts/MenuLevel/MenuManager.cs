using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform head,startButton;
    void Start()
    {

        head.transform.GetComponent<RectTransform>().DOLocalMoveX(0f,3f).SetEase(Ease.OutBack);
        startButton.transform.GetComponent<RectTransform>().DOLocalMoveY(-250f, 3f).SetEase(Ease.OutBack);
    }

 
    public void StartGame()
    {

        SceneManager.LoadScene("GameLevel");
    }
}
