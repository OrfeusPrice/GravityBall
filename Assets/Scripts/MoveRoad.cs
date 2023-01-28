using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public float speed = 0;
    public GameObject destr;
    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Destroyer")    
        Destroy(gameObject);
    }
}
