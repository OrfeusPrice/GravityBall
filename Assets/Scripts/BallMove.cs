using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class BallMove : MonoBehaviour
{
    float speed;
    float temp = -10;
    int score = 0;
    public GameObject deathMenu;
    public TextMeshProUGUI text;

    private void Start()
    {
        Invoke("Move", 0.5f);
        InvokeRepeating("ScoreInc", 4, 2);
    }
    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = temp;
    }
    public void Move()
    {
        temp *= -1;
        speed = temp;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Destroyer")
            Destroy(gameObject);
        deathMenu.SetActive(true);
    }

    public void ScoreInc()
    {
        score += 100;
        text.text = score.ToString();
    }
}
