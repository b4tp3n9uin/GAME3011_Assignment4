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

    [Header("Audio-")]
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pipeLevels.Length; i++)
        { pipeLevels[i].SetActive(false); }

        openingText.SetActive(true);
        DifficultyPannel.SetActive(false);
        grid.SetActive(false);
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
        grid.SetActive(true);
    }

    // Easy
    public void Easy()
    {
        PlayGame();
        pipeLevels[0].SetActive(true);
    }

    // Medium


    // Hard
}
