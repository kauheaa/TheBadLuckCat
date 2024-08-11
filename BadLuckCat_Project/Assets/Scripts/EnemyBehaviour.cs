using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = -1f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeDirection"))
        {
            Debug.Log("Koiran pitäisi vaihtaa suuntaa");
            moveSpeed *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }
}
