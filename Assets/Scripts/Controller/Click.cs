using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public static bool ABtnClick;
    public static bool BBtnClick;
    public static bool CBtnClick;
    public static bool DBtnClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            if(this.gameObject.transform.position.x<250.63f)
            {
                ABtnClick = true;
                //Debug.Log("AButtonClicked");

            }
            else if(this.gameObject.transform.position.x<517.22f)
            {
                BBtnClick = true;
                //Debug.Log("BButtonClicked");
            }
            else if(this.gameObject.transform.position.x<780.0f)
            {
                CBtnClick = true;
            }
            else if(this.gameObject.transform.position.x<1041.3f)
            {
                DBtnClick = true;
            }
        }
    }
}
