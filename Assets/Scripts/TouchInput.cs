using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TouchInput : NetworkBehaviour {

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

        if(myui.isUIOpen == false)
        {
            //Touch raycast.
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        if (hit.collider.tag == "tile")
                        {
                            myui.selectedRegion = hit.transform.gameObject.GetComponent<Region>();
                            myui.OpenUI("region");
                            myui.isUIOpen = true;
                          
                        }
                        if(hit.collider.tag == "tradeNode")
                        {
                            myui.selectedRegion = hit.transform.gameObject.GetComponent<Region>();
                            myui.OpenUI("tradeNode");
                            myui.isUIOpen = true;
                        }
                        if(hit.collider.tag == "army")
                        {
                            myui.selectedRegion = hit.transform.gameObject.GetComponent<Region>();
                            myui.OpenUI("army");
                            myui.isUIOpen = true;
                        }
                    }
                }
            }
        }


	}
}
