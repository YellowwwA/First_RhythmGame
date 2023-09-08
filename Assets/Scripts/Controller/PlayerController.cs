using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    TimingManager theTimingManager;
    Transform a;
    Transform b;
    Transform c;
    Transform d;
    //public Click theClick;

    //public GameObject other = null;

    void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
        a = GameObject.Find("ABtn").gameObject.GetComponent<Transform>();
        a.gameObject.SetActive(false);
        b = GameObject.Find("BBtn").gameObject.GetComponent<Transform>();
        b.gameObject.SetActive(false);
        c = GameObject.Find("CBtn").gameObject.GetComponent<Transform>();
        c.gameObject.SetActive(false);
        d = GameObject.Find("DBtn").gameObject.GetComponent<Transform>();
        d.gameObject.SetActive(false);

        //theClick = GetComponent<<Click>();
    }


    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isStartGame)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Input.mousePosition;

                if(330f <= pos.y && pos.y <= 480f)
                {   
                    //ù��°����������
                    if(22.78f <= pos.x && pos.x <= 250.63f)
                    {
                        a.gameObject.SetActive(true);
                        Debug.Log(Click.ABtnClick);
                        if(Click.ABtnClick == true)
                        {
                            //Debug.Log("checktiming");
                            theTimingManager.CheckTiming(); //����üũ
                        }
                        Click.ABtnClick = false;
                        //Debug.Log("tap11111");

                    }
                    //�ι�°����������
                    if(293.92f <= pos.x && pos.x <= 517.22f)
                    {
                        b.gameObject.SetActive(true);
                        if(Click.BBtnClick == true)
                        {
                            //Debug.Log("checktiming");
                            theTimingManager.CheckTiming(); //����üũ
                        }
                        Click.BBtnClick = false;
                        //Debug.Log("tap22222");

                    }    
                    //����°����������
                    if(556.0f <= pos.x && pos.x <= 780.0f)
                    {
                        c.gameObject.SetActive(true);
                        if(Click.CBtnClick == true)
                        {
                            //Debug.Log("checktiming");
                            theTimingManager.CheckTiming(); //����üũ
                        }
                        Click.CBtnClick = false;
                        //Debug.Log("tap33333");
                    }    
                    //�׹�°����������
                    if(827.0f <= pos.x && pos.x <= 1041.3f)
                    {
                        d.gameObject.SetActive(true);
                        if(Click.DBtnClick == true)
                        {
                            //Debug.Log("checktiming");
                            theTimingManager.CheckTiming(); //����üũ
                        }
                        Click.DBtnClick = false;
                        //Debug.Log("tap44444");
                    }    
 
                }
                Debug.Log(pos);



            }
            else if(Input.GetMouseButtonUp(0))
            {
                        a.gameObject.SetActive(false);
                        b.gameObject.SetActive(false);
                        c.gameObject.SetActive(false);
                        d.gameObject.SetActive(false);
                        //Click.ABtnClick = false;
                        //theClick.BBtnClick = false;
                        //theClick.CBtnClick = false;
                        //theClick.DBtnClick = false;

            }
        }

    }
}
