using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMANAGER : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;

    [Header("Knive Count Display")]
    [SerializeField]
    private GameObject panelKnives;

    [SerializeField]
    private GameObject iconKnive;

    [SerializeField]
    private Color usedKniveIconColor;

    public void ShowRestartButton ()
    {
        restartButton.SetActive(true);
    }

    public void SetInitialDisplayKnifeCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconKnive, panelKnives.transform);
    }

    private int kniveIconIndexToChange = 0;

    public void decrementDisplayKniveCount()
    {
        panelKnives.transform.GetChild(kniveIconIndexToChange++)
            .GetComponent<RawImage>().color = usedKniveIconColor;
    }

    public void playgame()
    {
        SceneManager.LoadScene("LEVEL1");
    }
    public void GOHOME()
    {
        SceneManager.LoadScene("UI");
    }

    //Login WIth Social Media
    //
    //
    //
    //* connect to FaceBook

    public void connectToFacebook()
    {
        Debug.Log("ConnectingToFacebook");
    }
    //* connect to PlayGames
    public void connectToPlayGames()
    {
        Debug.Log("ConnectingToPlayGames");
    }

}
