using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 lastMousePosition;
    public GameObject BTPrefab ;
    public GameObject tmp;
    public GameObject CB;

    int ID;

    void Start(){
        CB = GameObject.Find("CreateButton");
    }

    /// <summary>
    /// This method will be called on the start of the mouse drag
    /// </summary>
    /// <param name="eventData">mouse pointer event data</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin Drag");
        lastMousePosition = eventData.position;
        tmp = Instantiate(BTPrefab) as GameObject;
        tmp.transform.SetParent(this.transform.parent);

        tmp.GetComponent<RectTransform>().offsetMax= new Vector2(0,0);
        tmp.GetComponent<RectTransform>().offsetMin= new Vector2(0,0);
        tmp.GetComponent<RectTransform>().anchoredPosition=this.GetComponent<RectTransform>().anchoredPosition;
        //tmp.GetComponentInChildren<Text>().text=this.GetComponentInChildren<Text>().text;
        tmp.GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;

        ID = int.Parse(this.name.Split('(')[1].Split(')')[0]);
    }

    /// <summary>
    /// This method will be called during the mouse drag
    /// </summary>
    /// <param name="eventData">mouse pointer event data</param>

    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        //Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = tmp.GetComponent<RectTransform>();
        //Vector3 newPosition = rect.position +  new Vector3(0, diff.y, transform.position.z);
        Vector3 oldPos = rect.position;

        //new
        float caly = Mathf.Floor(-(Screen.height-eventData.position.y)/(Screen.height/20)+1)*(Screen.height/20);
        //rect.position = new Vector3(newPosition.x,Mathf.Floor(eventData.position.y/(Screen.height/20))*(Screen.height/20),newPosition.z);
        rect.anchoredPosition=new Vector2(0,caly+(Screen.height/20)/2);
        //Debug.Log(-(caly/(Screen.height/20))); // List Index 0~17+

        if(caly > 0 || caly < -Screen.height + 3*(Screen.height/20)){
            rect.position = oldPos;
        }

        /*
        if(!IsRectTransformInsideSreen(rect))
        {
            rect.position = oldPos;
        }
        */
        lastMousePosition = currentMousePosition;
    }

    /// <summary>
    /// This method will be called at the end of mouse drag
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        
        RectTransform rect = GetComponent<RectTransform>();
        float caly = Mathf.Floor(-(Screen.height-lastMousePosition.y)/(Screen.height/20)+1)*(Screen.height/20);
        if(-caly>=(Screen.height/20)*18){
            caly=-(Screen.height/20)*17;
        }
        rect.anchoredPosition=new Vector2(0,caly);
        //Debug.Log(this.GetComponent<Transform>());
        Destroy(tmp);


        CB.GetComponent<CommandList>().move(ID, -((int)caly/(Screen.height/20)));
        //Debug.Log("ID:"+ID+","+-((int)caly/(Screen.height/20)));
    }

    /// <summary>
    /// This methods will check is the rect transform is inside the screen or not
    /// </summary>
    /// <param name="rectTransform">Rect Trasform</param>
    /// <returns></returns>
    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(0,0,Screen.width, Screen.height);
        foreach(Vector3 corner in corners)
        {
            if(rect.Contains(corner))
            {
                visibleCorners++;
            }
        }
        if(visibleCorners == 4)
        {
            isInside = true;
        }
        return isInside;
    }
}
