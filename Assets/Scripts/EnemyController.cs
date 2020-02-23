using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Range(2.5f, 5f)]
    public float visionRadius;

    [Range(1f, 2f)]
    public float speed;

    public GameObject player;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy(){
    
        Vector3 target = initialPosition;

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < visionRadius) target = player.transform.position;

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.red);

    }

    private void OnDrawGizmos() {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

    }

}
