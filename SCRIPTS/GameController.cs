using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UIMANAGER))]


public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    [SerializeField]
    private int knifeCount;

    [Header("Knife Spwaning")]
    [SerializeField]
    private Vector2 knifeSpawnPosition;
    [SerializeField]
    private GameObject knifeObject;

    public GameObject pauseUI;


    public UIMANAGER GameUI { get; private set; }
    public score scoreg;

    private void Awake()
    {
        instance = this;
        GameUI = gameObject.GetComponent<UIMANAGER>();


    }

    private void Start()
    {

        GameUI.SetInitialDisplayKnifeCount(knifeCount);
        SpwanKnife();
    }

    public int GetV()
    {
        return scoreg.scoreNumber++;
    }

    public void OnSuccessfulKniveHit(int v)
    {
        if (knifeCount > 0)
        {
            SpwanKnife();
            scoreg.scoreNumber++;
        }
        else
        {
            StartGameOverSequence(true);
        }
    }



    private void SpwanKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }



    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", (win));
    }



    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            SceneManager.LoadScene("Level2");
            
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                RestartGame();
            }

        }
        else

        {
            pauseUI.SetActive(true);
            GameUI.ShowRestartButton();
        }
    }

    


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
    }



}
