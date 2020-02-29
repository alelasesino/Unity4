using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(8f, 12f)]
    public float speed;

    private Rigidbody2D rb;
    private Vector3 dir;

    void Start() {
    
        rb = GetComponent<Rigidbody2D>();

        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixTarget = new Vector3(target.x, target.y, 0f);
        dir = (fixTarget - transform.position).normalized;
        
    }

    void FixedUpdate() {
    
        rb.MovePosition(transform.position + (dir * speed) * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D collision) {

        if(!collision.CompareTag("Player")) 
            Destroy(gameObject);

        if(collision.CompareTag("Enemy"))
            Destroy(collision.gameObject);
        
    }

    void OnBecameInvisible() {
    
        Destroy(gameObject);

    }

}
