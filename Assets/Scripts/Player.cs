using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 7f;
    GameObject currentFloor;
    [SerializeField] int healthPoint;
    [SerializeField] GameObject HpBar;
    [SerializeField] Text scoreText;
    int score;
    float scoreTime;
    void Start()
    {
        healthPoint = 10;
        score = 0;
        scoreTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // the player can move left/right using A/D and left/right arrow Key
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        // show score on the screen 
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "NormalFloor")
        {
            // only if the player stands on the upper surface of the floor can it be counted as currentFloor
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("Hit NormalFloor");
                currentFloor = other.gameObject;
                ModifyHealthPoint(1);
                UpdateHpBar();
            }

        }
        else if (other.gameObject.tag == "NailFloor")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("Hit NailFloor");
                currentFloor = other.gameObject;
                ModifyHealthPoint(-2);
                UpdateHpBar();
            }
        }
        else if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Hit Ceiling");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            ModifyHealthPoint(-3);
            UpdateHpBar();

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("you lose");
        }
    }
    // the range of HP is 0-10
    void ModifyHealthPoint(int num)
    {
        healthPoint += num;
        if (healthPoint >= 10)
        {
            healthPoint = 10;
        }
        else if (healthPoint <= 0)
        {
            healthPoint = 0;
        }
    }

    // HP bar is shown or hidden correspond to HP
    void UpdateHpBar()
    {
        for (int i = 0; i < HpBar.transform.childCount; i++)
        {
            if (healthPoint > i)
            {
                HpBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                HpBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    // Show score in UI
    void UpdateScore()
    {
        scoreTime += Time.deltaTime;
        if (scoreTime > 2f)
        {
            score++;
            scoreTime = 0f;
            scoreText.text = "Basement\r\nLevel " + score.ToString();
        }
    }
}
