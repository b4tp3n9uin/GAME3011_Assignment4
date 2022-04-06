using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public GameObject pipeLine;
    public GameObject[] pipes;

    [SerializeField]
    int numOfPipes = 0;

    [SerializeField]
    int connectedPipes = 0;

    GameManager gameManager;

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        numOfPipes = pipeLine.transform.childCount;

        pipes = new GameObject[numOfPipes];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = pipeLine.transform.GetChild(i).gameObject;
        }
    }

    public void PipeConnect()
    {
        connectedPipes++;
    }

    public void PipeDisconnect()
    {
        connectedPipes--;
    }

    public void FlushToilet()
    {
        if (connectedPipes == numOfPipes)
        {
            gameManager.WinGame();
        }
        else
        {
            gameManager.LoseGame();
        }
    }
}
