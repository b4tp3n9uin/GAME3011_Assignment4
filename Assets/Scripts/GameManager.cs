using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool started = false;
    [SerializeField]
    GameObject openingText;

    [SerializeField]GameObject DifficultyPannel;

    [Header("Game N Grid:")]
    public GameObject[] pipeLevels;
    public GameObject grid;

    [Header("Game Over Pannels-")]
    public GameObject Win;
    public GameObject Lose;

    [Header("TimeText")]
    public TextMeshProUGUI timeText;
    bool timeActive = false;
    float timer;

    [Header("Audio Music-")]
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    [Header("Audio Flush-")]
    public AudioClip ToiletClip;
    public AudioSource ToiletSource;

    [Header("Audio Fart-")]
    public AudioClip FartClip;
    public AudioSource FartSource;


    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "";
        timer = 31;

        for (int i = 0; i < pipeLevels.Length; i++)
        { pipeLevels[i].SetActive(false); }

        openingText.SetActive(true);
        DifficultyPannel.SetActive(false);
        grid.SetActive(false);

        Win.SetActive(false);
        Lose.SetActive(false);
    }

    void Update()
    {
        if (timeActive)
        { SetTimer(); }

        if (Input.GetKeyDown(KeyCode.E) && !started)
        {
            openingText.SetActive(false);
            DifficultyPannel.SetActive(true);
        }
    }

    void PlayGame()
    {
        timeActive = true;
        DifficultyPannel.SetActive(false);
        MusicSource.Play();
        grid.SetActive(true);
    }

    void CloseGame()
    {
        for (int i = 0; i < pipeLevels.Length; i++)
        { pipeLevels[i].SetActive(false); }

        timeActive = false;

        MusicSource.Stop();
        grid.SetActive(false);
        timeText.text = " ";
    }

    public void Quit()
    {
        Win.SetActive(false);
        Lose.SetActive(false);
    }

    //Timer
    void SetTimer()
    {
        if (timeActive && timer > 0)
        {
            timer -= Time.deltaTime * 1;
            
            timeText.text = "Time Left: " + (int)timer;
        }
        else if (timer <= 0)
        {
            timeActive = false;
            LoseGame();
        }
    }

    // Easy
    public void Easy()
    {
        PlayGame();
        pipeLevels[0].SetActive(true);
    }

    // Medium
    public void Medium()
    {
        PlayGame();
        pipeLevels[1].SetActive(true);
    }

    // Hard
    public void Hard()
    {
        PlayGame();
        pipeLevels[2].SetActive(true);
    }

    // Win 
    public void WinGame()
    {
        ToiletSource.Play();
        CloseGame();
        Win.SetActive(true);
    }

    //Lose
    public void LoseGame()
    {
        FartSource.Play();
        CloseGame();
        Lose.SetActive(true);
    }
}
