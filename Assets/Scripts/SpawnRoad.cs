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

    float rr = 3;
    float rl = 3;

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

        if (rr < 1.5f) { rr = 2.5f; }
        nRight.transform.localScale = new Vector3(0.3f, (Random.value + 0.05f) * rr, 0);
        //nRight.GetComponent<SpriteRenderer>().color = Color.red;
        rl = 6 - rr;
        if (rl < 1.5f) { rl = 2.5f; }
        nLeft.transform.localScale = new Vector3(0.3f, (Random.value + 0.05f) * rl, 0);
        //nLeft.GetComponent<SpriteRenderer>().color = Color.red;
        rr = 6 - rr;


        if (nLeft.transform.localScale.y <= 1.5f)
        {
            nLeft.transform.localScale = new Vector3(0.3f, 2f, 0);
            //nLeft.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (nRight.transform.localScale.y <= 1.5f)
        {
            nRight.transform.localScale = new Vector3(0.3f, 2f, 0);
            //nRight.GetComponent<SpriteRenderer>().color = Color.green;
        }

        Instantiate(nRight);
        Instantiate(nLeft);

    }
}
