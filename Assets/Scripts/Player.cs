using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 5f;
    GameObject currentFloor;
    [SerializeField] int healthPoint;
    void Start()
    {
        healthPoint = 10;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }

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
            }

        }
        else if (other.gameObject.tag == "NailFloor")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("Hit NailFloor");
                currentFloor = other.gameObject;
                ModifyHealthPoint(-2);
            }
        }
        else if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Hit Ceiling");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            ModifyHealthPoint(-3);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("you lose");
        }
    }

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
}
