using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] angles = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField]
    bool placed;

    int numOfCorRot;

    GamePlayManager gameplayManager;

    private void Awake()
    {
        gameplayManager = GameObject.Find("InGameManager").GetComponent<GamePlayManager>();
    }

    private void Start()
    {
        numOfCorRot = correctRotation.Length;

        int randonAngle = Random.Range(0, angles.Length);
        transform.eulerAngles = new Vector3(0, 0, angles[randonAngle]);
        
        isPlaced();
    }

    public void RotatePipe()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        isPlaced();
    }

    void isPlaced()
    {
        if (numOfCorRot > 1)
        {
            // 2 or more correct rotations, for the tall pipes.
            if ((transform.eulerAngles.z >= correctRotation[0] - 45 && transform.eulerAngles.z <= correctRotation[0] + 45) ||
            (transform.eulerAngles.z >= correctRotation[1] - 45 && transform.eulerAngles.z <= correctRotation[1] + 45) && !placed)
            {
                placed = true;
                gameplayManager.PipeConnect();
            }
            else if (placed)
            {
                placed = false;
                gameplayManager.PipeDisconnect();
            }
        }
        else
        {
            if ((transform.eulerAngles.z >= correctRotation[0] - 45 && transform.eulerAngles.z <= correctRotation[0] + 45) && !placed)
            {
                placed = true;
                gameplayManager.PipeConnect();
            }
            else if (placed)
            {
                placed = false;
                gameplayManager.PipeDisconnect();
            }
        }
    }
}
