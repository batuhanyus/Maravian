using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SyncRegion : NetworkBehaviour {

    [SyncVar]
    NetworkInstanceId myKingdomID;

    SyncListInt syncListProductions = new SyncListInt();
    SyncListInt syncListUsages = new SyncListInt();
    SyncListInt syncListWorkers = new SyncListInt();
    SyncListInt syncListMaxWorkers = new SyncListInt();
    SyncListInt syncListBuildingLevels = new SyncListInt();


    //SYNC GUIDE.(FIX!)
    //There are two types of sync:
    //-Periodic Sync:This data updates periodically no matter what.
    //Daily Syncs(5 Mins)
    //-
    //Weekly Syncs(35 Mins)
    //-
    //Monthly Syncs(150 Mins (2 Hr 30 Mins))
    //-
    //Yearly Syncs(1800 Mins (30 Hr))
    //-

    //-Dynamic Sync:This data updates dynamically.

    void Start ()
    {

        InvokeRepeating("GlobalSync", 0f, 2f);
	
	}
	
	

    [Server]
    void GlobalSync()
    {
        //Prepare data.
        PrepareBasicData();
        PrepareProductions();
        PrepareUsages();
        PrepareWorkers();
        PrepareMaxWorkers();
        PrepareBuildingLevels();

        
    }

    [Server]
    void PrepareBasicData()
    {
        if(gameObject.GetComponent<Region>().myKingdom != null)
        {
            //Prepare it.

            myKingdomID = gameObject.GetComponent<Region>().myKingdom.netId;

            //Apply it.

            RpcApplyBasicData();
        }       
       
    }

    [ClientRpc]
    void RpcApplyBasicData()
    {
        //Apply kingdom.
        gameObject.GetComponent<Region>().myKingdom = ClientScene.FindLocalObject(myKingdomID).GetComponent<Kingdom>();
        
    }

    [Server]
    void PrepareProductions()
    {
        //Prepare data.

        syncListProductions.Clear();
        
        syncListProductions.Add(gameObject.GetComponent<Region>().foodProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().woolProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().woodProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().stoneProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().ironOreProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().wineProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().clothProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().leatherProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().steelProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().silverOreProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().silverWareProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().ironBarProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().horseProduction);
        syncListProductions.Add(gameObject.GetComponent<Region>().goldOreProduction);

        //Apply data.
        RpcApplyProductions();

    }

    [ClientRpc]
    void RpcApplyProductions()
    {
        gameObject.GetComponent<Region>().foodProduction = syncListProductions[0];
        gameObject.GetComponent<Region>().woolProduction = syncListProductions[1];
        gameObject.GetComponent<Region>().woodProduction = syncListProductions[2];
        gameObject.GetComponent<Region>().stoneProduction = syncListProductions[3];
        gameObject.GetComponent<Region>().ironOreProduction = syncListProductions[4];
        gameObject.GetComponent<Region>().wineProduction = syncListProductions[5];
        gameObject.GetComponent<Region>().clothProduction = syncListProductions[6];
        gameObject.GetComponent<Region>().leatherProduction = syncListProductions[7];
        gameObject.GetComponent<Region>().steelProduction = syncListProductions[8];
        gameObject.GetComponent<Region>().silverOreProduction = syncListProductions[9];
        gameObject.GetComponent<Region>().silverWareProduction = syncListProductions[10];
        gameObject.GetComponent<Region>().ironBarProduction = syncListProductions[11];
        gameObject.GetComponent<Region>().horseProduction = syncListProductions[12];
        gameObject.GetComponent<Region>().goldOreProduction = syncListProductions[13];
    }

    [Server]
    void PrepareUsages()
    {

        syncListUsages.Clear();

        //Prepare data.

        syncListUsages.Add(gameObject.GetComponent<Region>().foodUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().woolUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().woodUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().stoneUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().ironOreUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().wineUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().clothUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().leatherUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().steelUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().silverOreUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().silverWareUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().ironBarUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().horseUsage);
        syncListUsages.Add(gameObject.GetComponent<Region>().goldOreUsage);

        //Apply data.
        RpcApplyUsages();
    }

    [ClientRpc]
    void RpcApplyUsages()
    {
        gameObject.GetComponent<Region>().foodUsage = syncListUsages[0];
        gameObject.GetComponent<Region>().woolUsage = syncListUsages[1];
        gameObject.GetComponent<Region>().woodUsage = syncListUsages[2];
        gameObject.GetComponent<Region>().stoneUsage = syncListUsages[3];
        gameObject.GetComponent<Region>().ironOreUsage = syncListUsages[4];
        gameObject.GetComponent<Region>().wineUsage = syncListUsages[5];
        gameObject.GetComponent<Region>().clothUsage = syncListUsages[6];
        gameObject.GetComponent<Region>().leatherUsage = syncListUsages[7];
        gameObject.GetComponent<Region>().steelUsage = syncListUsages[8];
        gameObject.GetComponent<Region>().silverOreUsage = syncListUsages[9];
        gameObject.GetComponent<Region>().silverWareUsage = syncListUsages[10];
        gameObject.GetComponent<Region>().ironBarUsage = syncListUsages[11];
        gameObject.GetComponent<Region>().horseUsage = syncListUsages[12];
        gameObject.GetComponent<Region>().goldOreUsage = syncListUsages[13];
    }

    [Server]
    void PrepareWorkers()
    {

        syncListWorkers.Clear();

        //Prepare it.

        syncListWorkers.Add(gameObject.GetComponent<Region>().farmWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().pastureWoolWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().pastureLeatherWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().pastureHorseWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().lumberyardWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().quarryWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().mineIronOreWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().mineSilverOreWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().mineGoldOreWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().vineyardWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().tailorWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().metalWorksIronBarWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().metalWorksSteelWorkers);
        syncListWorkers.Add(gameObject.GetComponent<Region>().jewelryWorkers);

        //Apply it.
        RpcApplyWorkers();
    }

    [ClientRpc]
    void RpcApplyWorkers()
    {
        gameObject.GetComponent<Region>().farmWorkers = syncListWorkers[0];
        gameObject.GetComponent<Region>().pastureWoolWorkers = syncListWorkers[1];
        gameObject.GetComponent<Region>().pastureLeatherWorkers = syncListWorkers[2];
        gameObject.GetComponent<Region>().pastureHorseWorkers = syncListWorkers[3];
        gameObject.GetComponent<Region>().lumberyardWorkers = syncListWorkers[4];
        gameObject.GetComponent<Region>().quarryWorkers = syncListWorkers[5];
        gameObject.GetComponent<Region>().mineIronOreWorkers = syncListWorkers[6];
        gameObject.GetComponent<Region>().mineSilverOreWorkers = syncListWorkers[7];
        gameObject.GetComponent<Region>().mineGoldOreWorkers = syncListWorkers[8];
        gameObject.GetComponent<Region>().vineyardWorkers = syncListWorkers[9];
        gameObject.GetComponent<Region>().tailorWorkers = syncListWorkers[10];
        gameObject.GetComponent<Region>().metalWorksIronBarWorkers = syncListWorkers[11];
        gameObject.GetComponent<Region>().metalWorksSteelWorkers = syncListWorkers[12];
        gameObject.GetComponent<Region>().jewelryWorkers = syncListWorkers[13];
    }

    [Server]
    void PrepareMaxWorkers()
    {

        syncListMaxWorkers.Clear();

        //Prepare it.

        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().farmMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().pastureWoolMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().pastureLeatherMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().pastureHorseMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().lumberyardMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().quarryMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().mineIronOreMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().mineSilverOreMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().mineGoldOreMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().vineyardMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().tailorMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().metalWorksIronBarMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().metalWorksSteelMaxWorkers);
        syncListMaxWorkers.Add(gameObject.GetComponent<Region>().jewelryMaxWorkers);

        //Apply it.
        RpcApplyMaxWorkers();
    }

    [ClientRpc]
    void RpcApplyMaxWorkers()
    {
        gameObject.GetComponent<Region>().farmMaxWorkers = syncListMaxWorkers[0];
        gameObject.GetComponent<Region>().pastureWoolMaxWorkers = syncListMaxWorkers[1];
        gameObject.GetComponent<Region>().pastureLeatherMaxWorkers = syncListMaxWorkers[2];
        gameObject.GetComponent<Region>().pastureHorseMaxWorkers = syncListMaxWorkers[3];
        gameObject.GetComponent<Region>().lumberyardMaxWorkers = syncListMaxWorkers[4];
        gameObject.GetComponent<Region>().quarryMaxWorkers = syncListMaxWorkers[5];
        gameObject.GetComponent<Region>().mineIronOreMaxWorkers = syncListMaxWorkers[6];
        gameObject.GetComponent<Region>().mineSilverOreMaxWorkers = syncListMaxWorkers[7];
        gameObject.GetComponent<Region>().mineGoldOreMaxWorkers = syncListMaxWorkers[8];
        gameObject.GetComponent<Region>().vineyardMaxWorkers = syncListMaxWorkers[9];
        gameObject.GetComponent<Region>().tailorMaxWorkers = syncListMaxWorkers[10];
        gameObject.GetComponent<Region>().metalWorksIronBarMaxWorkers = syncListMaxWorkers[11];
        gameObject.GetComponent<Region>().metalWorksSteelMaxWorkers = syncListMaxWorkers[12];
        gameObject.GetComponent<Region>().jewelryMaxWorkers = syncListMaxWorkers[13];
    }
   
    [Server]
    void PrepareBuildingLevels()
    {

        syncListBuildingLevels.Clear();

        //Prepare it.

        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().farmLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().pastureLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().lumberyardLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().quarryLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().mineLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().vineyardLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().tailorLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().metalWorksLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().jewelryLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().blackSmithLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().fletcherLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().weaponSmithLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().armorSmithLevel);
        syncListBuildingLevels.Add(gameObject.GetComponent<Region>().siegeWorksLevel);

        //Apply it.
        RpcApplyBuildingLevels();
    }

    [ClientRpc]
    void RpcApplyBuildingLevels()
    {
        gameObject.GetComponent<Region>().farmLevel = syncListBuildingLevels[0];
        gameObject.GetComponent<Region>().pastureLevel = syncListBuildingLevels[1];
        gameObject.GetComponent<Region>().lumberyardLevel = syncListBuildingLevels[2];
        gameObject.GetComponent<Region>().quarryLevel = syncListBuildingLevels[3];
        gameObject.GetComponent<Region>().mineLevel = syncListBuildingLevels[4];
        gameObject.GetComponent<Region>().vineyardLevel = syncListBuildingLevels[5];
        gameObject.GetComponent<Region>().tailorLevel = syncListBuildingLevels[6];
        gameObject.GetComponent<Region>().metalWorksLevel = syncListBuildingLevels[7];
        gameObject.GetComponent<Region>().jewelryLevel = syncListBuildingLevels[8];
        gameObject.GetComponent<Region>().blackSmithLevel = syncListBuildingLevels[9];
        gameObject.GetComponent<Region>().fletcherLevel = syncListBuildingLevels[10];
        gameObject.GetComponent<Region>().weaponSmithLevel = syncListBuildingLevels[11];
        gameObject.GetComponent<Region>().armorSmithLevel = syncListBuildingLevels[12];
        gameObject.GetComponent<Region>().siegeWorksLevel = syncListBuildingLevels[13];
    }
    
    
}
