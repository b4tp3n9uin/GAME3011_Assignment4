using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.E) && !started)
        {
            openingText.SetActive(false);
            DifficultyPannel.SetActive(true);
        }
    }

    void PlayGame()
    {
        DifficultyPannel.SetActive(false);
        MusicSource.Play();
        grid.SetActive(true);
    }

    void CloseGame()
    {
        for (int i = 0; i < pipeLevels.Length; i++)
        { pipeLevels[i].SetActive(false); }

        MusicSource.Stop();
        grid.SetActive(false);
    }

    public void Quit()
    {
        Win.SetActive(false);
        Lose.SetActive(false);
    }

    // Easy
    public void Easy()
    {
        PlayGame();
        pipeLevels[0].SetActive(true);
    }

    // Medium


    // Hard


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
