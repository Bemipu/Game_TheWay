using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandList : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GO;
    public GameObject cmdr;
    public GameObject Player;
    Dropdown m_Dropdown;
    int index;
    int cmdnum;
    public bool interrupt=false;
    void Start()
    {
        //Fetch the Dropdown GameObject
        m_Dropdown = GO.GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
        index = 0;
        cmdnum = 0;

    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
        index = change.value;
        //Debug.Log(change.value);
    }

    /* //forbidden
    public void Create(){
        //Debug.Log(index);
        if(cmdnum <18){

            //GameObject tmp = Instantiate(ForwardPrefab) as GameObject;
            //tmp.transform.SetParent(this.transform.parent);
            
            //tmp.GetComponent<RectTransform>().offsetMax= new Vector2(0,0);
            //tmp.GetComponent<RectTransform>().offsetMin= new Vector2(0,0);
            //tmp.GetComponent<RectTransform>().anchoredPosition=new Vector2(0,Mathf.Floor(-(cmdnum)*(Screen.height/20))); 
            //tmp.GetComponentInChildren<Text>().text=cmdnum.ToString();
            
            int avaliable=-1;
            for(int i=0;i<18;i++){
                if(cmdr.GetComponent<CommandPos>().cmdlist[i]==-1){
                    avaliable=i;
                    break;
                }
            }
            cmdr.GetComponent<CommandPos>().cmdlist[avaliable]=index;
            
            //cmdr.GetComponent<CommandPos>().cmdGO[cmdnum].GetComponentInChildren<Text>().text=cmdnum.ToString()+":"+index.ToString();
            string[] commandname = new string[7]{"Forward","TurnRight","TurnLeft","ForloopEnd","Forloop2","Forloop3","Forloop4"};
            cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponentInChildren<Text>().text=commandname[index];

            cmdnum++;
        }
    }
    */
    string[] commandname = new string[7]{"Forward","TurnRight","TurnLeft","ForloopEnd","Forloop2","Forloop3","Forloop4"};
    public Sprite[] img = new Sprite[7];

    public void CreateForward(){
        index = 0;
        if(cmdnum <18){
            int avaliable=-1;
            for(int i=0;i<18;i++){
                if(cmdr.GetComponent<CommandPos>().cmdlist[i]==-1){
                    avaliable=i;
                    break;
                }
            }
            cmdr.GetComponent<CommandPos>().cmdlist[avaliable]=index;
            //cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponentInChildren<Text>().text=commandname[index];
            cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponent<Image>().sprite=img[index];

            cmdnum++;
        }
    }
    public void CreateTR(){
        index = 1;
        if(cmdnum <18){
            int avaliable=-1;
            for(int i=0;i<18;i++){
                if(cmdr.GetComponent<CommandPos>().cmdlist[i]==-1){
                    avaliable=i;
                    break;
                }
            }
            cmdr.GetComponent<CommandPos>().cmdlist[avaliable]=index;
            //cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponentInChildren<Text>().text=commandname[index];
            cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponent<Image>().sprite=img[index];

            cmdnum++;
        }
    }
    public void CreateTL(){
        index = 2;
        if(cmdnum <18){
            int avaliable=-1;
            for(int i=0;i<18;i++){
                if(cmdr.GetComponent<CommandPos>().cmdlist[i]==-1){
                    avaliable=i;
                    break;
                }
            }
            cmdr.GetComponent<CommandPos>().cmdlist[avaliable]=index;
            //cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponentInChildren<Text>().text=commandname[index];
            cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponent<Image>().sprite=img[index];

            cmdnum++;
        }
    }
    public void CreateFLE(){
        index = 3;
        if(cmdnum <18){
            int avaliable=-1;
            for(int i=0;i<18;i++){
                if(cmdr.GetComponent<CommandPos>().cmdlist[i]==-1){
                    avaliable=i;
                    break;
                }
            }
            cmdr.GetComponent<CommandPos>().cmdlist[avaliable]=index;
            //cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponentInChildren<Text>().text=commandname[index];
            cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponent<Image>().sprite=img[index];

            cmdnum++;
        }
    }
    public void CreateFL2(){
        index = 4;
        if(cmdnum <18){
            int avaliable=-1;
            for(int i=0;i<18;i++){
                if(cmdr.GetComponent<CommandPos>().cmdlist[i]==-1){
                    avaliable=i;
                    break;
                }
            }
            cmdr.GetComponent<CommandPos>().cmdlist[avaliable]=index;
            //cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponentInChildren<Text>().text=commandname[index];
            cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponent<Image>().sprite=img[index];

            cmdnum++;
            CreateFLE();
        }
    }public void CreateFL3(){
        index = 5;
        if(cmdnum <18){
            int avaliable=-1;
            for(int i=0;i<18;i++){
                if(cmdr.GetComponent<CommandPos>().cmdlist[i]==-1){
                    avaliable=i;
                    break;
                }
            }
            cmdr.GetComponent<CommandPos>().cmdlist[avaliable]=index;
            //cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponentInChildren<Text>().text=commandname[index];
            cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponent<Image>().sprite=img[index];

            cmdnum++;
            CreateFLE();
        }
    }public void CreateFL4(){
        index = 6;
        if(cmdnum <18){
            int avaliable=-1;
            for(int i=0;i<18;i++){
                if(cmdr.GetComponent<CommandPos>().cmdlist[i]==-1){
                    avaliable=i;
                    break;
                }
            }
            cmdr.GetComponent<CommandPos>().cmdlist[avaliable]=index;
            //cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponentInChildren<Text>().text=commandname[index];
            cmdr.GetComponent<CommandPos>().cmdGO[avaliable].GetComponent<Image>().sprite=img[index];

            cmdnum++;
            CreateFLE();
        }
    }
    public void DeleteSelect(){
        for(int i=0;i<18;i++){
            cmdr.GetComponent<CommandPos>().cmdGO[i].GetComponent<Button>().interactable=!cmdr.GetComponent<CommandPos>().cmdGO[i].GetComponent<Button>().interactable;
        }
    }

    public Sprite emptyimg;

    public void Delete(Button button){
        int ID = int.Parse(button.name.Split('(')[1].Split(')')[0]);
        if(cmdr.GetComponent<CommandPos>().cmdlist[ID] != -1){
            cmdnum--;
        }
        cmdr.GetComponent<CommandPos>().cmdlist[ID]= -1;
        //cmdr.GetComponent<CommandPos>().cmdGO[ID].GetComponentInChildren<Text>().text= "";
        cmdr.GetComponent<CommandPos>().cmdGO[ID].GetComponent<Image>().sprite=emptyimg;
        
    }
    public void DeleteAll(){
        for(int i=0;i<18;i++){
            cmdr.GetComponent<CommandPos>().cmdlist[i]= -1;
            //cmdr.GetComponent<CommandPos>().cmdGO[i].GetComponentInChildren<Text>().text= "";
            cmdr.GetComponent<CommandPos>().cmdGO[i].GetComponent<Image>().sprite=emptyimg;
        }
        cmdnum=0;
    }
    public void move(int id, int dest){
        //Debug.Log(id+","+dest);
        
        int idmove=cmdr.GetComponent<CommandPos>().cmdlist[id];
        GameObject idGO = cmdr.GetComponent<CommandPos>().cmdGO[id];

        if(id > dest){
            for(int i=id;i>dest;i--){
                
                cmdr.GetComponent<CommandPos>().cmdlist[i]=cmdr.GetComponent<CommandPos>().cmdlist[i-1];
                cmdr.GetComponent<CommandPos>().cmdGO[i]=cmdr.GetComponent<CommandPos>().cmdGO[i-1];
                cmdr.GetComponent<CommandPos>().cmdGO[i].name = "Command (" + (i) +")";


                RectTransform rect = cmdr.GetComponent<CommandPos>().cmdGO[i-1].GetComponent<RectTransform>();
                float caly = Mathf.Floor(-i*(Screen.height/20));
                cmdr.GetComponent<CommandPos>().cmdGO[i-1].GetComponent<RectTransform>().anchoredPosition=new Vector2(0,caly);

            }
            cmdr.GetComponent<CommandPos>().cmdlist[dest]= idmove;
            cmdr.GetComponent<CommandPos>().cmdGO[dest] = idGO;
            cmdr.GetComponent<CommandPos>().cmdGO[dest].name = "Command (" + dest +")";

        }else if(id < dest){
            for(int i=id;i<dest;i++){
                
                cmdr.GetComponent<CommandPos>().cmdlist[i]=cmdr.GetComponent<CommandPos>().cmdlist[i+1];
                cmdr.GetComponent<CommandPos>().cmdGO[i]=cmdr.GetComponent<CommandPos>().cmdGO[i+1];
                cmdr.GetComponent<CommandPos>().cmdGO[i].name = "Command (" + (i) +")";

                RectTransform rect = cmdr.GetComponent<CommandPos>().cmdGO[i+1].GetComponent<RectTransform>();
                float caly = Mathf.Floor(-i*(Screen.height/20));
                cmdr.GetComponent<CommandPos>().cmdGO[i+1].GetComponent<RectTransform>().anchoredPosition=new Vector2(0,caly);
            }
            cmdr.GetComponent<CommandPos>().cmdlist[dest]= idmove;
            cmdr.GetComponent<CommandPos>().cmdGO[dest] = idGO;
            cmdr.GetComponent<CommandPos>().cmdGO[dest].name = "Command (" + dest +")";
        }
        
    }

    public void resetpos(){
        Player.GetComponent<CommandMovement>().setplayerpos(Player.GetComponent<CommandMovement>().currentlevel);
        interrupt=true;
    }

    private int cmdi=19;
    public float fireRate;
    private float nextFire = 0.0f;

    private int[] steps = new int[1024];

    private int checking = 0;
    bool aftercheck = false;
    public GameObject TPanel;
    void check(int i,int end) { // computing steps with loops
        //Debug.Log(i);
        if (cmdr.GetComponent<CommandPos>().cmdlist[i] >= 4) { //4:loop2 5:loop3 6:loop4
            steps[checking++] = i;
            int f = 1;
            for (int k = i+1;k<=18; k++) {
                if (k == 18) {//error
                    GameObject.Find("TutorialText").GetComponent<Text>().text = "error: excepted \"loopend\". \n翻譯：指令無法執行\n因為第 " + (i+1) + " 行缺少相對應的迴圈結尾。";
                    TPanel.SetActive(true);
                    interrupt = true;
                    break;
                } else {
                    if (cmdr.GetComponent<CommandPos>().cmdlist[k] >= 4) {
                        f++;
                    }
                    else if (cmdr.GetComponent<CommandPos>().cmdlist[k] == 3) {
                        f--;
                    }
                    if (f == 0) {
                        for (int m = 0; m < cmdr.GetComponent<CommandPos>().cmdlist[i] - 2; m++) {
                            check(i+1,k+1);    
                        }
                        i = k;
                        break;
                    }
                }
            }
        }
        
        steps[checking++] = i;
        if(i+1<end)check(i+1,end);
        
    }

    public void play(){ // init before doing play when play button clicked
        GameObject.Find("TutorialText").GetComponent<Text>().text = "";
        TPanel.SetActive(false);
        for(int i=0;i<18;i++){
            cmdr.GetComponent<CommandPos>().cmdGO[i].GetComponent<Button>().interactable=false;
        }
        Player.GetComponent<CommandMovement>().setplayerpos(Player.GetComponent<CommandMovement>().currentlevel);

        aftercheck = false;
        for (int i = 0; i < 1024; i++) {
            steps[i] = -1;
        }
        checking = 0;
        check(0,18);
        aftercheck=true;

        cmdi = 0;
        ColorBlock newColorBlock = cmdr.GetComponent<CommandPos>().cmdGO[0].GetComponent<Button>().colors;
        newColorBlock.disabledColor = new Color(0.8f,0.8f,0.8f);
        for(int i=0;i<18;i++){
            cmdr.GetComponent<CommandPos>().cmdGO[i].GetComponent<Button>().colors = newColorBlock;
        }
            
    }
    void Update(){
        if (interrupt){
            for (int i = 0; i < 1024; i++) {
                steps[i] = -1;
            }
            checking = 0;
            ColorBlock newColorBlock = cmdr.GetComponent<CommandPos>().cmdGO[0].GetComponent<Button>().colors;
            newColorBlock.disabledColor = new Color(0.8f,0.8f,0.8f);
            for(int i=0;i<18;i++){
                cmdr.GetComponent<CommandPos>().cmdGO[i].GetComponent<Button>().colors = newColorBlock;
            }
            aftercheck = false;
            interrupt = false;
        } else if (Time.time > nextFire /*&& cmdi < checking+1*/ && aftercheck){
            ColorBlock newColorBlock;
            if(steps[cmdi] !=0){
                newColorBlock = cmdr.GetComponent<CommandPos>().cmdGO[steps[cmdi-1]].GetComponent<Button>().colors;
                newColorBlock.disabledColor = new Color(0.6f,0.6f,0.6f);
                cmdr.GetComponent<CommandPos>().cmdGO[steps[cmdi-1]].GetComponent<Button>().colors = newColorBlock;
            }

            if(cmdi < checking){
                newColorBlock = cmdr.GetComponent<CommandPos>().cmdGO[steps[cmdi]].GetComponent<Button>().colors;
                newColorBlock.disabledColor = new Color(0f,1f,0f);
                cmdr.GetComponent<CommandPos>().cmdGO[steps[cmdi]].GetComponent<Button>().colors = newColorBlock;

                nextFire = Time.time + fireRate;
                if(cmdr.GetComponent<CommandPos>().cmdlist[steps[cmdi]] == 0){
                    Player.GetComponent<CommandMovement>().forward();
                }else if(cmdr.GetComponent<CommandPos>().cmdlist[steps[cmdi]] == 1){
                    //Player.transform.Rotate(0f,0f,90f);
                    Player.GetComponent<CommandMovement>().turnright();
                }else if(cmdr.GetComponent<CommandPos>().cmdlist[steps[cmdi]] == 2){
                    //Player.transform.Rotate(0f,0f,-90f);
                    Player.GetComponent<CommandMovement>().turnleft();
                }
                
            }else{
                aftercheck = false;
            }
            cmdi++;
        }
    }
}
