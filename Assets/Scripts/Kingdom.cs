using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Kingdom : NetworkBehaviour {

    public int myID;
    public GameObject myPlayerController;

    public int constructionSpeed;

    public float myGold;

    public List<TroopTypeScript> myTroopTypes = new List<TroopTypeScript>();

    

    public List<Region> myRegions = new List<Region>();


    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
