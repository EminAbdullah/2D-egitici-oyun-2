using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject TopPanel,pausePanel,Image,Image2,resultPanel;

    [SerializeField]
    private GameObject optionImage1, optionImage2;

    [SerializeField]
    private Text Option1Text, Option2Text,scoreText,totalCorrect,totalWrong,score;

    TimerManager timerManager;
    CircleManager circleManager;
    TrueFalseManager trueFalseManager;

    int gameSayac, whichGame;

    int option1, option2;
    int bigValue;
    int buttonValue;

    int totalScore, scoreIncrease,Correct,Wrong;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip startSound,correctSound,wrongSound,endSound;

    private void Awake()
    {
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();
        circleManager = Object.FindObjectOfType<CircleManager>();
        timerManager = Object.FindObjectOfType<TimerManager>();

        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        totalCorrect.text ="0";
        totalWrong.text = "0";
        gameSayac = 0;
        whichGame = 0;
        gameSceneUpdate();
        Option1Text.text = "";
        Option2Text.text = "";
        scoreText.text ="0";
    }

 
    void gameSceneUpdate()
    {
        
        TopPanel.GetComponent<CanvasGroup>().DOFade(1, 2f);
        Image.GetComponent<CanvasGroup>().DOFade(1, 2f); 
        //TopPanel.GetComponent<RectTransform>().DOScale(1,1f);
        //Image.GetComponent<RectTransform>().DOScale(1, 2f); 
        optionImage1.GetComponent<RectTransform>().DOLocalMoveX(0, 2f).SetEase(Ease.InCirc);
        optionImage2.GetComponent<RectTransform>().DOLocalMoveX(0, 2f).SetEase(Ease.InCirc);

    }

    public void startGame()
    {
        audioSource.PlayOneShot(startSound);
        //Image.GetComponent<RectTransform>().DOScale(0, 0.5f);
        //Image2.GetComponent<RectTransform>().DOScale(1, 1f);
        Image.GetComponent<CanvasGroup>().DOFade(0,0.5f);
        Image2.GetComponent<CanvasGroup>().DOFade(1, 1f);
        WhichGame();
        timerManager.StartTimer();

    }
    void WhichGame()
    {
        if (gameSayac<5)
        {
            whichGame = 1;
            scoreIncrease = 25;
        }
        else if (gameSayac>=5 && gameSayac<10)
        {
            whichGame = 2;
            scoreIncrease = 50;
        }
        else if (gameSayac >= 10 && gameSayac < 15)
        {
            whichGame = 3;
            scoreIncrease = 50;
        }
        else if (gameSayac >= 15 && gameSayac < 20)
        {
            whichGame = 4;
            scoreIncrease = 75;
        }
        else if (gameSayac >= 20 && gameSayac < 25)
        {
            whichGame = 5;
            scoreIncrease = 75;
        }
        else
        {
            whichGame = Random.Range(1, 6);
            scoreIncrease = 100;
        }
        switch (whichGame)
        {
            case 1:
                firstFunction();
                break;
            case 2:
                secondFunction();
                break;
            case 3:
                thirdFunction();
                break;
            case 4:
                fourthFunction();
                break;
            case 5:
                fifthFunction();
                break;
            default:
                break;
        }

    }

    void firstFunction()
    {
        int randomValue = Random.Range(0, 50);

        if (randomValue<=25)
        {
            option1 = Random.Range(2, 50);
            option2 = option1 + Random.Range(1, 20);
        }
        else
        {
            option2 = Random.Range(2, 50);
            option1 = option2 + Random.Range(1, 20);
        }
        if (option1>option2)
        {
            bigValue = option1;
        }
        else if (option2 > option1)
        {
            bigValue = option2;
        }
        else
        {
            firstFunction();
            return;
        }

        Option1Text.text = option1.ToString();
        Option2Text.text = option2.ToString();
       
    }


    private void secondFunction()
    {
        int firstNumber = Random.Range(1, 20);
        int secondNumber = Random.Range(1, 20);

        int thirdNumber = Random.Range(1, 20);
        int fourthNumber = Random.Range(1, 20);

        option1 = firstNumber + secondNumber;
        option2 = thirdNumber + fourthNumber;


        if (option1>option2)
        {
            bigValue = option1;
        }
        else if (option2 > option1)
        {
            bigValue = option2;
        }
        else if (option1==option2)
        {
             secondFunction();
            return;
        }

        Option1Text.text = firstNumber.ToString() +"+"+ secondNumber.ToString() ;
        Option2Text.text = thirdNumber.ToString() + "+" + fourthNumber.ToString();
    }

    private void thirdFunction()
    {
        int firstNumber = Random.Range(20, 50);
        int secondNumber = Random.Range(1, 20);

        int thirdNumber = Random.Range(20, 50);
        int fourthNumber = Random.Range(1, 20);

        option1 = firstNumber - secondNumber;
        option2 = thirdNumber - fourthNumber;


        if (option1 > option2)
        {
            bigValue = option1;
        }
        else if (option2 > option1)
        {
            bigValue = option2;
        }
        else if (option1 == option2)
        {
            thirdFunction();
            return;
        }

        Option1Text.text = firstNumber.ToString() + "-" + secondNumber.ToString();
        Option2Text.text = thirdNumber.ToString() + "-" + fourthNumber.ToString();
    }

    private void fourthFunction()
    {

        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 10);

        int thirdNumber = Random.Range(1, 10);
        int fourthNumber = Random.Range(1, 10);

        option1 = firstNumber * secondNumber;
        option2 = thirdNumber * fourthNumber;


        if (option1 > option2)
        {
           bigValue = option1;
        }
        else if (option2 > option1)
        {
          bigValue = option2;
        }
        else if (option1 == option2)
        {
           fourthFunction();
           return;
        }

        Option1Text.text = firstNumber.ToString() + "x" + secondNumber.ToString();
        Option2Text.text = thirdNumber.ToString() + "x" + fourthNumber.ToString();
        
    }


    private void fifthFunction()
    {
        int firstNumber = Random.Range(1, 10);
        option1 = Random.Range(1, 10);
        int secondNumber = option1 * firstNumber;

        int thirdNumber = Random.Range(1, 10);
        option2 = Random.Range(1, 10);
        int fourthNumber = option2 * thirdNumber;

        if (option1 > option2)
        {
            bigValue = option1;
        }
        else if (option2 > option1)
        {
            bigValue = option2;
        }
        else if (option1 == option2)
        {
            fifthFunction();
            return;
        }

        Option1Text.text = secondNumber.ToString() + "/" + firstNumber.ToString();
        Option2Text.text = fourthNumber.ToString() + "/" + thirdNumber.ToString();
    }

    public void buttonValueSet(string buttonName)
    {

        if (buttonName=="OptionImage1")
        {
            buttonValue = option1;
         
        }
        else if (buttonName == "OptionImage2")
        {
            buttonValue = option2;

        }

        if (buttonValue == bigValue)
        {
            trueFalseManager.startTrueIconOpen();
            circleManager.openCircles(gameSayac%5);
            gameSayac++;
            totalScore += scoreIncrease;
            scoreText.text = totalScore.ToString();
            Correct+=1;

            audioSource.PlayOneShot(correctSound);
            WhichGame();
        }
        else
        {
            trueFalseManager.startFalseIconOpen();
            circleManager.openCirclesRed(gameSayac % 5);
            gameSayac++;
            totalScore -= 50;
            if (totalScore<0)
            {
                totalScore = 0;
            }
            scoreText.text = totalScore.ToString();
            Wrong+= 1;
            audioSource.PlayOneShot(wrongSound);
            WhichGame();
        }
       
    }

    public void pausePanelOpen()
    {
        pausePanel.SetActive(true);

    }

    public void FinishGame()
    {
        audioSource.PlayOneShot(endSound);
        totalWrong.text = Wrong.ToString();
        totalCorrect.text = Correct.ToString();
        resultPanel.SetActive(true);

        StartCoroutine("PrintScore");
    }


    IEnumerator PrintScore()
    {
        int increaseScore;
        int printScore = 0;
        increaseScore = totalScore / 20;
        for (int i = 0; i <=21; i++)
        {
            yield return new WaitForSeconds(0.05f);
            printScore += increaseScore;
            if (printScore >= totalScore)
            {
                printScore = totalScore;
                
            }
           
            score.text = printScore.ToString();
        }

    }
}
