using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Range(2.5f, 5f)]
    public float visionRadius;

    [Range(1f, 2f)]
    public float speed;

    [Range(1f,100f)]
    public float damage;

    private GameObject player, healthBar;

    private Vector3 initialPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        initialPosition = transform.position;
    }

    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy(){
    
        Vector3 target = initialPosition;


        RaycastHit2D hit = Physics2D.Raycast(
        
            transform.position,
            player.transform.position - transform.position,
            visionRadius,
            1 << LayerMask.NameToLayer("Default")

        );

        Vector3 f = transform.InverseTransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, f, Color.red);

        if(hit.collider != null){
            Debug.Log(hit.collider.tag);
            if(hit.collider.CompareTag("Player")){
                target = player.transform.position;
            }

        }

        float distance = Vector3.Distance(target, transform.position);
        //if(distance < visionRadius) target = player.transform.position;

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.red);

    }

    private void OnDrawGizmos() {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag("Player"))
            healthBar.SendMessage("TakeDamage", damage);

    }

}
