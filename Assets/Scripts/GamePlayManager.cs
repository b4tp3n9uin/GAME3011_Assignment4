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

    

    // Start is called before the first frame update
    void Start()
    {
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


        if (connectedPipes == numOfPipes)
        {
            Debug.Log("You Win!");
        }
    }

    public void PipeDisconnect()
    {
        connectedPipes--;
    }
}
