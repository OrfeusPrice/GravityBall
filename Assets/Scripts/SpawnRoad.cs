using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    public GameObject right;
    public GameObject left;

    public GameObject bRight;
    public GameObject bLeft;

    GameObject nRight;
    GameObject nLeft;
    
    int rr = 3;
    int rl = 3;

    void Start()
    {
        bRight.GetComponent<MoveRoad>().speed = -5;
        bLeft.GetComponent<MoveRoad>().speed = -5;

        nRight = Instantiate(right);
        nLeft = Instantiate(left);
        nRight.GetComponent<MoveRoad>().speed = -5;
        nLeft.GetComponent<MoveRoad>().speed = -5;
        InvokeRepeating("Spawn", 0, 0.7f);
    }

    private void Spawn()
    {
        nRight.transform.position = right.transform.position;
        nLeft.transform.position = left.transform.position;

        if (rr < 1.5f) { rr = 4; }
        nRight.transform.localScale = new Vector3(0.2f, (Random.value + 0.1f) * rr, 0);
        rl = 6 - rr;
        if (rl < 1.5f) { rl = 4; }
        nLeft.transform.localScale = new Vector3(0.2f, (Random.value + 0.1f) * rl, 0);
        rr = 6 - rr;


        if (nRight.transform.localScale.y < 1)
            nLeft.transform.localScale = new Vector3(0.2f, 3, 0);
        if (nLeft.transform.localScale.y < 1)
            nRight.transform.localScale = new Vector3(0.2f, 3, 0);

        Instantiate(nRight);
        Instantiate(nLeft);

    }
}
