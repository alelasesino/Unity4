using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    //Posicion de destino del jugador
    private Vector3 target;
    public GameObject bullet;
    
    [Range(3f, 5f)]
    public float speed = 2f;

    private const int LEFT_CLICK = 0;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        MovePlayer();
        Attack();
    }

    private void MovePlayer(){
    
        if(Input.GetMouseButtonDown(LEFT_CLICK)){
            
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
            target.z = 0f;

        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        Debug.DrawLine(transform.position, target, Color.blue);

    }

    private void Attack(){
    
        if(Input.GetKeyDown(KeyCode.Space))
            Instantiate(bullet, transform.position, transform.rotation);
        

    }

}
