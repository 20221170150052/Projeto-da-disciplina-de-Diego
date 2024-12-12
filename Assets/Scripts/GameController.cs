using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text ScoreText;

    public GameObject gameOver;
   
    public static GameController instance;
  
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        ScoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive (true);
    }
}
