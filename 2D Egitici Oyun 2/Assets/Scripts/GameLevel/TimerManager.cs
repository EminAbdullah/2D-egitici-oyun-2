using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text TimeText;

    int RemainingTime=90;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    public void StartTimer()
    {
        StartCoroutine(Timer());

    }
    IEnumerator Timer()
    {
        
        for (int i = RemainingTime; i >0; i--)
        {
            
            if (i<10)
            {
                TimeText.text = "0"+i.ToString();
            }
            else
            {
                TimeText.text = i.ToString();
            }
            yield return new WaitForSeconds(1);
        }
        TimeText.text = "";
        gameManager.FinishGame();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
