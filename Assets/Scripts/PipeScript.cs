using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] angles = { 0, 90, 180, 270 };

    public float correctRotation;
    [SerializeField]
    bool placed;

    private void Start()
    {
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
        if ((transform.eulerAngles.z >= correctRotation - 45 && 
            transform.eulerAngles.z <= correctRotation + 45) && !placed)
        {
            placed = true;
        }
        else if (placed)
        {
            placed = false;
        }
    }
}
