using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPos : MonoBehaviour
{
    public GameObject[] cmdGO = new GameObject[18];
    public int[] cmdlist = new int[18];

    public Sprite emptyimg;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<18;i++){
            float caly = Mathf.Floor(-i*(Screen.height/20));
            cmdGO[i].GetComponent<RectTransform>().anchoredPosition=new Vector2(0,caly);
        }
        for(int i=0;i<18;i++){
            cmdlist[i]=-1;
        }
        ColorBlock newColorBlock = cmdGO[0].GetComponent<Button>().colors;
        newColorBlock.disabledColor = new Color(0.8f,0.8f,0.8f);
        for(int i=0;i<18;i++){
            cmdGO[i].GetComponent<Button>().colors = newColorBlock;
            cmdGO[i].GetComponent<Image>().sprite=emptyimg;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
