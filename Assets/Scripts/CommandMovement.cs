using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class CommandMovement : MonoBehaviour
{
    private int player_direction=3; // N E S W 
    private Vector3[] moveunit = new [] { new Vector3(0f,1f,0f), new Vector3(1f,0f,0f), new Vector3(0f,-1f,0f),new Vector3(-1f,0f,0f) };
    private Vector3 destination;
    public float speed = 1f;
    public GameObject StartGame;
    public bool free =false;
    //level stuff
    public Vector2[] tppos = new Vector2[7];
    public Vector2[] beginpos = new Vector2[7];
    // there is a levelmax below !!!!!!!!!
    public int currentlevel;
    void Start()
    {
        destination = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
    
        if(free){
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
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            GameObject grid = GameObject.Find("TilemapGrid"); 
            grid.GetComponent<TilemapRenderer>().enabled = !grid.GetComponent<TilemapRenderer>().enabled;
        }
        /*
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            forward();
            //Debug.Log("Uparrow");
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            turnright();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            turnleft();
        }
        */
    }

    public void forward(){
        destination += moveunit[player_direction];
        this.GetComponent<Animator>().SetInteger("Facing",player_direction);
        this.GetComponent<Animator>().SetTrigger("Moving");
    }

    public void turnright(){
        player_direction=(player_direction+1)%4;
        this.GetComponent<Animator>().SetInteger("Facing",player_direction);
    }

    public void turnleft(){
        player_direction=(player_direction+3)%4; //equal -1
        this.GetComponent<Animator>().SetInteger("Facing",player_direction);
    }

    public void setplayerpos(int id){
        Vector3 tpos = new Vector3(beginpos[id].x,beginpos[id].y,-1.5f);
        this.transform.position = tpos;
        destination = this.transform.position;

        player_direction = leveldefaultfacing[id];
        this.GetComponent<Animator>().SetInteger("Facing",leveldefaultfacing[id]);
        /*
        if(!free){
            player_direction = 3;
            this.GetComponent<Animator>().SetInteger("Facing",3);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("works");
        if(other.tag == "block"){
            destination += moveunit[(player_direction+2)%4];
        }else if(other.tag == "danger"){
            //show something
            GameObject.Find("PanelAboutDeath").GetComponent<Image>().enabled=true;

            StartCoroutine(BDelay());

            setplayerpos(currentlevel);
            if(!free)GameObject.Find("CreateButton").GetComponent<CommandList>().interrupt = true;
        }else if(other.tag == "levelportal"){
            Debug.Log("PlayerHitTP");
            for(int i=0;i<levelmax;i++){
                if(this.transform.position.x<tppos[i].x+1f && this.transform.position.x  > tppos[i].x-1f &&
                   this.transform.position.y<tppos[i].y+1f && this.transform.position.y  > tppos[i].y-1f){
                    hittp(i);
                }
            }
            
        }
        
    }

    IEnumerator BDelay()
    {
        yield return new WaitForSeconds(0.5f);
        
        GameObject.Find("PanelAboutDeath").GetComponent<Image>().enabled=false;
    }

    int levelmax = 7;

    int[] leveldefaultfacing = new int[] {3,3,1,0,0,3,3};
    // there are two vector above!!!!!!!!!!
    void hittp(int id){
        GameObject grid = GameObject.Find("TilemapGrid"); 
        grid.GetComponent<TilemapRenderer>().enabled = false;
        if(id == 0){
            //StartGame.GetComponent<StartGame>().Freelook();
        }else if(id == 6){
            StartGame.GetComponent<StartGame>().Freelook();
            setplayerpos(id);
            currentlevel = id;
        }else{
            StartGame.GetComponent<StartGame>().Gamelook(id);
            setplayerpos(id);
            currentlevel = id;  
        }
    }

}
