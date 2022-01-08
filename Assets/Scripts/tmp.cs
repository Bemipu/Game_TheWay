using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tmp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject cmdr;
    public GameObject Player;
    // Update is called once per frame
    private int cmdi=19;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    //new from here V
    private int[] steps = new int[1024];

    private void check(int i){
        int j=0;
        if(cmdr.GetComponent<CommandPos>().cmdlist[i] >= 4 ){ //4:loop1 5:loop2 6:loop3 7:loop4
            int f=1;
            for(int k=i;;k++){
                if(k==18){//error

                }else{
                    if(cmdr.GetComponent<CommandPos>().cmdlist[k] >= 4){
                        f++;
                    }else if(cmdr.GetComponent<CommandPos>().cmdlist[k] == 3){
                        f--;
                    }
                    if(f == 0){
                        for(int l=i+1;l<k;l++){
                            for(int m=0;m<cmdr.GetComponent<CommandPos>().cmdlist[i]-3;m++){
                                check(l);
                            }
                        }
                        break;
                    }
                }
            }
        } else{
            steps[j++]=cmdr.GetComponent<CommandPos>().cmdlist[i];
            check(i);
        }
    }
    public void play(){
        for(int i=0;i<1024;i++){
            steps[i]=-1;
        }
        check(0);
        
        
        
        cmdi = 0;
        ColorBlock newColorBlock = cmdr.GetComponent<CommandPos>().cmdGO[0].GetComponent<Button>().colors;
        newColorBlock.disabledColor = new Color(0.8f,0.8f,0.8f);
        for(int i=0;i<18;i++){
            cmdr.GetComponent<CommandPos>().cmdGO[i].GetComponent<Button>().colors = newColorBlock;
        }
            
    }




    void Update(){
        if (Time.time > nextFire && cmdi <19)
        {
            ColorBlock newColorBlock;
            if(cmdi !=0){
                newColorBlock = cmdr.GetComponent<CommandPos>().cmdGO[cmdi-1].GetComponent<Button>().colors;
                newColorBlock.disabledColor = new Color(0.6f,0.6f,0.6f);
                cmdr.GetComponent<CommandPos>().cmdGO[cmdi-1].GetComponent<Button>().colors = newColorBlock;
            }

            if(cmdi <18){
                newColorBlock = cmdr.GetComponent<CommandPos>().cmdGO[cmdi].GetComponent<Button>().colors;
                newColorBlock.disabledColor = new Color(0f,1f,0f);
                cmdr.GetComponent<CommandPos>().cmdGO[cmdi].GetComponent<Button>().colors = newColorBlock;

                nextFire = Time.time + fireRate;
                if(cmdr.GetComponent<CommandPos>().cmdlist[cmdi] == 0){
                    Player.GetComponent<CommandMovement>().forward();
                }else if(cmdr.GetComponent<CommandPos>().cmdlist[cmdi] == 1){
                    Player.GetComponent<CommandMovement>().turnright();
                }else if(cmdr.GetComponent<CommandPos>().cmdlist[cmdi] == 2){
                    Player.GetComponent<CommandMovement>().turnleft();
                }else if(cmdr.GetComponent<CommandPos>().cmdlist[cmdi] == 4){
                    
                }


                
            }
            cmdi++;
        }
    }
}
