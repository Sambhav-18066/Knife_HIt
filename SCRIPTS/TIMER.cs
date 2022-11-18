using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class TIMER : MonoBehaviour
{
    [SerializeField]
    public GameObject timer;
    public GameObject pauseUI;
    public GameObject rb;
    public GameObject hb;
    
    public int secondsLeft = 30;
    public bool takingAway = false;

   
  
    void Start()
    {
        timer.GetComponent<Text>().text = "00:" + secondsLeft;
       
    }
     void Update()
    {
        if(takingAway == false && secondsLeft >0)
        {
            StartCoroutine(TimerTake());
        }


        if (secondsLeft == 0)
        {

            Time.timeScale = 0f;
            pauseUI.SetActive(true);
            rb.SetActive(true);
            hb.SetActive(true);
         

        }


        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft > 10)
        {
            timer.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            timer.GetComponent<Text>().text = "00:" + secondsLeft;
            takingAway = false;
        }
    }
    
}
