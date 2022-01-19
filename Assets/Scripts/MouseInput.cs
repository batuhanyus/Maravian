using UnityEngine;
using System.Collections;


public class MouseInput : MonoBehaviour {

    public UI myui;
    public LayerMask uiLayerMask;

    public bool isTouched = false;

    void Start()
    {
        myui = gameObject.GetComponent<UI>();
    }

    // Update is called once per frame
    void Update ()
    {
	    
        if(Input.GetMouseButtonDown(0) == true && myui.isUIOpen == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            

            if (Physics.Raycast(ray,out hitInfo,1000.0f) == true)
            {
                if (hitInfo.collider.tag == "tile")
                {
                    myui.selectedRegion = hitInfo.transform.gameObject.GetComponent<Region>();
                    myui.OpenUI("region");
                    myui.isUIOpen = true;

                }
                if (hitInfo.collider.tag == "tradeNode")
                {
                    myui.selectedRegion = hitInfo.transform.gameObject.GetComponent<Region>();
                    myui.OpenUI("tradeNode");
                    myui.isUIOpen = true;
                }
                if (hitInfo.collider.tag == "army")
                {
                    myui.selectedRegion = hitInfo.transform.gameObject.GetComponent<Region>();
                    myui.OpenUI("army");
                    myui.isUIOpen = true;
                }

                Debug.Log("Hit success!" + " on " + hitInfo.collider.tag.ToString());
                
            }
           
        }

	}

    
}
