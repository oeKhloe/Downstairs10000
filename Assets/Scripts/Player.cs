using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 5f;
    GameObject currentFloor;
    void Start()
    {
        Debug.Log(123);

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
            Debug.Log("Hit NormalFloor");
            currentFloor = other.gameObject;
        }
        else if (other.gameObject.tag == "NailFloor")
        {
            Debug.Log("Hit NailFloor");
            currentFloor = other.gameObject;
        }
        else if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Hit Ceiling");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("you lose");
        }
    }
}
