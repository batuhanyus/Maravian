using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

public class BuildingLevelUpper : NetworkBehaviour {

    Region myRegion;


	// Use this for initialization
	void Start ()
    {

        myRegion = gameObject.GetComponent<Region>();

    }
	
	

    [Server]
    public void BuildingLevelUp(string type)
    {
        if (type == "farm")
        {
            myRegion.farmLevel += 1;
            myRegion.farmMaxWorkers = myRegion.farmLevel * 100;
        }
        if (type == "pasture")
        {
            myRegion.pastureLevel += 1;
            myRegion.pastureWoolMaxWorkers = myRegion.pastureLevel * 100;
            myRegion.pastureLeatherMaxWorkers = myRegion.pastureLevel * 100;
            myRegion.pastureHorseMaxWorkers = myRegion.pastureLevel * 100;
        }
        if (type == "vineyard")
        {
            myRegion.vineyardLevel += 1;
            myRegion.vineyardMaxWorkers = myRegion.vineyardLevel * 100;
        }
        if (type == "lumberyard")
        {
            myRegion.lumberyardLevel += 1;
            myRegion.lumberyardMaxWorkers = myRegion.lumberyardLevel * 100;
        }
        if (type == "quarry")
        {
            myRegion.quarryLevel += 1;
            myRegion.quarryMaxWorkers = myRegion.quarryLevel * 100;
        }
        if (type == "mine")
        {
            myRegion.mineLevel += 1;
            myRegion.mineIronOreMaxWorkers = myRegion.mineLevel * 100;
            myRegion.mineSilverOreMaxWorkers = myRegion.mineLevel * 100;
            myRegion.mineGoldOreMaxWorkers = myRegion.mineLevel * 100;
        }
        if (type == "tailor")
        {
            myRegion.tailorLevel += 1;
            myRegion.tailorMaxWorkers = myRegion.tailorLevel * 100;
        }
        if (type == "metal works")
        {
            myRegion.metalWorksLevel += 1;
            myRegion.metalWorksIronBarMaxWorkers = myRegion.metalWorksLevel * 100;
            myRegion.metalWorksSteelMaxWorkers = myRegion.metalWorksLevel * 100;
        }
        if (type == "jewelry")
        {
            myRegion.jewelryLevel += 1;
            myRegion.jewelryMaxWorkers = myRegion.jewelryLevel * 100;
        }
        if (type == "blacksmith")
        {
            myRegion.blackSmithLevel += 1;            
        }
        if (type == "fletcher")
        {
            myRegion.fletcherLevel += 1;
        }
        if (type == "weaponSmith")
        {
            myRegion.weaponSmithLevel += 1;
        }
        if (type == "armorSmith")
        {
            myRegion.armorSmithLevel += 1;
        }
        if (type == "siegeWorks")
        {
            myRegion.siegeWorksLevel += 1;
        }

        
        //Clean Up.

        //Refresh pools.
        myRegion.woodAccumulationPool = 0;
        myRegion.stoneAccumulationPool = 0;

        //Remove entry from list.
        myRegion.constructionList.RemoveAt(0);
    }

    

    
}
