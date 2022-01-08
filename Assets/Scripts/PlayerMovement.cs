using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 destination;
    public float speed = 1f;
    Vector3[] moveunit = new [] { new Vector3(0f,1f,0f), new Vector3(1f,0f,0f), new Vector3(0f,-1f,0f),new Vector3(-1f,0f,0f) };
    //N E S W 
    int player_direction;
    void Start()
    {
        destination = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        //up
        if(Input.GetKeyDown(KeyCode.W)){
            destination += moveunit[0];
            player_direction = 0;
            this.GetComponent<Animator>().SetInteger("Facing",player_direction);
            this.GetComponent<Animator>().SetTrigger("Moving");
        }
        //left
        if(Input.GetKeyDown(KeyCode.A)){
            destination += moveunit[3];
            player_direction = 3;
            this.GetComponent<Animator>().SetInteger("Facing",player_direction);
            this.GetComponent<Animator>().SetTrigger("Moving");
        }
        //down
        if(Input.GetKeyDown(KeyCode.S)){
            destination += moveunit[2];
            player_direction = 2;
            this.GetComponent<Animator>().SetInteger("Facing",player_direction);
            this.GetComponent<Animator>().SetTrigger("Moving");
        }
        //right
        if(Input.GetKeyDown(KeyCode.D)){
            destination += moveunit[1];
            player_direction = 1;
            this.GetComponent<Animator>().SetInteger("Facing",player_direction);
            this.GetComponent<Animator>().SetTrigger("Moving");
        }
        
        transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("works");
        if(other.tag == "block"){
            destination += moveunit[(player_direction+2)%4];
        }
    }
}