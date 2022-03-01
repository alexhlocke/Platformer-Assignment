using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private Rigidbody rb;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100))
            {
                Debug.Log("hit " + hitInfo.transform.name);
                if (hitInfo.transform.CompareTag("Brick"))
                {
                    Destroy(hitInfo.transform.gameObject);
                    FindObjectOfType<ui>().addToScore(50);
                } else if (hitInfo.transform.CompareTag("Question Block"))
                {
                    FindObjectOfType<ui>().gotCoin();
                    FindObjectOfType<ui>().addToScore(50);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<ui>().gotCoin();
            Destroy(collision.gameObject);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<ui>().gotCoin();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Flag"))
        {
            Debug.Log("---Level Complete!---");
        }
        if (other.gameObject.CompareTag("Water"))
        {
            Debug.Log("Minus points for touching water");
            FindObjectOfType<ui>().addToScore(-100);
        }
    }
}
