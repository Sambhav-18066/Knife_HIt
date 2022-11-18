using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class score : MonoBehaviour
{
   // public GameObject knive;
    public Text scoreText;
    public Text scoreTex1;
    public Text HighScore;
    public Text HighScore1;
    public int scoreNumber = 0;

    private void Awake()
    {
      
       
    }

    void Start()
    {
        scoreText.GetComponent<Text>();
        scoreTex1.GetComponent<Text>();
        HighScore.GetComponent<Text>();
        HighScore1.GetComponent<Text>();
        HighScore.text = PlayerPrefs.GetInt("highScore:").ToString();
        scoreNumber = 0;
        scoreText.text = scoreNumber.ToString();

    }
    
    void Update()
    {
        scoreText.text = "SCORE:" + scoreNumber;
        scoreTex1.text = scoreText.text;


        if (scoreNumber > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore:", scoreNumber);
            HighScore.text = scoreNumber.ToString();
        }
        HighScore1.text = "HighScore :"+HighScore.text;
    }
    
}
