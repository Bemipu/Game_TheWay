using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
public class StartGame : MonoBehaviour
{
    public GameObject block;
    public GameObject danger;
    public GameObject MainCam;
    public GameObject[] LevelCamPos=new GameObject[7];
    public GameObject cmddisplay;
    public GameObject player;
    public GameObject CreateButton;

    //tutorial
    public int tid=-1;
    public GameObject ttext;
    public GameObject[] tpanel = new GameObject[6];
    public GameObject ttpanel;

    // Start is called before the first frame update
    void Start()
    {
        block.transform.Translate(0,0,10f);
        danger.transform.Translate(0,0,10f);
        GameObject.Find("TilemapGrid").GetComponent<TilemapRenderer>().enabled = false; 
        
        Gamelook(0);

        starttutorial(++tid);
    }

    bool freelooking;
    public void Freelook(){
        freelooking = true;

        cmddisplay.SetActive(false);
        /*
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CommandMovement>().enabled = false;
        */
        player.GetComponent<CommandMovement>().free = true;
    }

    public void Gamelook(int levelID){
        freelooking = false;
        MainCam.transform.position = LevelCamPos[levelID].transform.position;
        
        /*
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<CommandMovement>().enabled = true;
        */
        CreateButton.GetComponent<CommandList>().interrupt = true;
        CreateButton.GetComponent<CommandList>().DeleteAll();
        player.GetComponent<CommandMovement>().free = false;
        player.GetComponent<CommandMovement>().setplayerpos(levelID);
        cmddisplay.SetActive(true);

    }

    void starttutorial(int tid){
        if(tid == 0){
            ttext.GetComponent<Text>().text = "教學(0): \n在任意處點擊「左鍵」\n即可進行下一步教學。";
        }else if(tid ==1){
            ttext.GetComponent<Text>().text = "教學(1): \n「左鍵」點擊「此區域按鈕」\n以生成相對應的指令";
            tpanel[tid].SetActive(true);
        }else if(tid ==2){
            ttext.GetComponent<Text>().text = "教學(2): \n「左鍵長按」指令列\n可以拖拉指令位置";
            tpanel[tid-1].SetActive(false);
            tpanel[tid].SetActive(true);
        }else if(tid ==3){
            ttext.GetComponent<Text>().text = "教學(3): \n「左鍵」點擊播放\n可以讓角色回到關卡起始位置並開始執行指令";
            tpanel[tid-1].SetActive(false);
            tpanel[tid].SetActive(true);
        }else if(tid ==4){
            ttext.GetComponent<Text>().text = "教學(4): \n「左鍵」點擊「重置」\n只會讓角色回到關卡起始位置";
            tpanel[tid-1].SetActive(false);
            tpanel[tid].SetActive(true);
        }else if(tid ==5){
            ttext.GetComponent<Text>().text = "教學(5): \n「左鍵」點擊「刪除」\n可以開啟指令刪除模式，開啟後點擊欲刪除指令即可刪除";
            tpanel[tid-1].SetActive(false);
            tpanel[tid].SetActive(true);
        }else if(tid ==6){
            ttext.GetComponent<Text>().text = "教學(6): \n「右鍵」可以開啟該關卡\n可移動範圍網格";
            tpanel[tid-1].SetActive(false);
        }else if(tid ==7){
            ttext.GetComponent<Text>().text = "";
            ttpanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(freelooking){
            Vector3 playerpos = new Vector3(player.transform.position.x,player.transform.position.y,-10f);
            MainCam.transform.position = playerpos;
        }
        
        if(tid!=-1){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                starttutorial(++tid);
                Debug.Log(tid);
            }
        }


        if(Input.GetKey(KeyCode.LeftControl)){
            if(Input.GetKeyDown(KeyCode.Alpha0)){
                player.GetComponent<CommandMovement>().currentlevel = 0;
                Gamelook(0);
            }else if(Input.GetKeyDown(KeyCode.Alpha1)){
                player.GetComponent<CommandMovement>().currentlevel = 1;
                Gamelook(1);
            }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                player.GetComponent<CommandMovement>().currentlevel = 2;
                Gamelook(2);
            }else if(Input.GetKeyDown(KeyCode.Alpha3)){
                player.GetComponent<CommandMovement>().currentlevel = 3;
                Gamelook(3);
            }else if(Input.GetKeyDown(KeyCode.Alpha4)){
                player.GetComponent<CommandMovement>().currentlevel = 4;
                Gamelook(4);
            }else if(Input.GetKeyDown(KeyCode.Alpha5)){
                player.GetComponent<CommandMovement>().currentlevel = 5;
                Gamelook(5);
            }else if(Input.GetKeyDown(KeyCode.Alpha6)){
                player.GetComponent<CommandMovement>().currentlevel = 6;
                Freelook();
            }
        }
    }
}