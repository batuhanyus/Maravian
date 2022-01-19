using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;


//This class wil run game-mechanic wise logic.

public class Region : NetworkBehaviour {


    //Syncs.
    SyncListInt syncListInt = new SyncListInt();
    SyncListFloat syncListFloat = new SyncListFloat();


    public TradeNodeScript myTradeNode;
	public CommonGround commonGround;
    public Kingdom myKingdom;
    public Map map;
    
    

    [SyncVar]
    public bool isSettled;
    [SyncVar]
    public string regionName;
    [SyncVar]
    public int population;

	public int livestock;
	public float myGold;
    public float myHappiness;

    public int maxManpower;
    public int currentManpower;

    [SyncVar]
    public float foodFertility = 1;
    [SyncVar]
    public float woodFertility;
    [SyncVar]
    public float stoneFertility;
    [SyncVar]
    public float ironOreFertility;
    [SyncVar]
    public float silverOreFertility;
    [SyncVar]
    public float goldOreFertility;
    [SyncVar]
    public float wineFertility;



	// Resource productions.
	public int foodProduction;
	public int woolProduction;
	public int woodProduction;
	public int stoneProduction;
	public int ironOreProduction;
	public int wineProduction;
	public int clothProduction;
	public int leatherProduction;
	public int steelProduction;
	public int silverOreProduction;
	public int silverWareProduction;
	public int ironBarProduction;
	public int horseProduction;
	public int goldOreProduction;

    //Resource Last Day Usages.
    public int foodUsage;
    public int woolUsage;
    public int woodUsage;
    public int stoneUsage;
    public int ironOreUsage;
    public int wineUsage;
    public int clothUsage;
    public int leatherUsage;
    public int steelUsage;
    public int silverOreUsage;
    public int silverWareUsage;
    public int ironBarUsage;
    public int horseUsage;
    public int goldOreUsage;

    //Building levels.
    public int farmLevel;
	public int pastureLevel;
	public int lumberyardLevel;
	public int quarryLevel;
	public int mineLevel;
	public int vineyardLevel;
	public int tailorLevel;
	public int metalWorksLevel;
	public int jewelryLevel;
    public int blackSmithLevel;
    public int fletcherLevel;
    public int weaponSmithLevel;
    public int armorSmithLevel;
    public int siegeWorksLevel;

    //Sector workforces.
    public int farmWorkers;
	public int pastureWoolWorkers;
    public int pastureLeatherWorkers;
    public int pastureHorseWorkers;
    public int lumberyardWorkers;
	public int quarryWorkers;
	public int mineIronOreWorkers;
    public int mineSilverOreWorkers;
    public int mineGoldOreWorkers;
    public int vineyardWorkers;
	public int tailorWorkers;
	public int metalWorksIronBarWorkers;
    public int metalWorksSteelWorkers;
    public int jewelryWorkers;

    //Sector maximum workforces.
    public int farmMaxWorkers;
    public int pastureWoolMaxWorkers;
    public int pastureLeatherMaxWorkers;
    public int pastureHorseMaxWorkers;
    public int lumberyardMaxWorkers;
    public int quarryMaxWorkers;
    public int mineIronOreMaxWorkers;
    public int mineSilverOreMaxWorkers;
    public int mineGoldOreMaxWorkers;
    public int vineyardMaxWorkers;
    public int tailorMaxWorkers;
    public int metalWorksIronBarMaxWorkers;
    public int metalWorksSteelMaxWorkers;
    public int jewelryMaxWorkers;

    //Local stocks.
    public int foodLocalStock;
	public int woolLocalStock;
	public int woodLocalStock;
	public int stoneLocalStock;
	public int ironOreLocalStock;
	public int wineLocalStock;
	public int clothLocalStock;
	public int leatherLocalStock;
	public int steelLocalStock;
	public int silverOreLocalStock;
	public int silverWareLocalStock;
	public int ironBarLocalStock;
	public int horseLocalStock;
	public int goldOreLocalStock;

	//Happiness contributors.This is float values that should be ragarded likes %'s.
	float foodHappiness;
	float woodHappiness;
	float wineHappiness;
	float clothHappiness;
	float silverWareHappiness;

    //Arms Industry
    public List<string> blackSmithOrderType = new List<string>();
    public List<int> blacksmithOrderAmount = new List<int>();
    public List<string> fletcherOrderType = new List<string>();
    public List<int> fletcherOrderAmount = new List<int>();
    public List<string> weaponSmithOrderType = new List<string>();
    public List<int> weaponSmithOrderAmount = new List<int>();
    public List<string> armorSmithOrderType = new List<string>();
    public List<int> armorSmithOrderAmount = new List<int>();
    public List<string> siegeWorksOrderType = new List<string>();
    public List<int> siegeWorksOrderAmount = new List<int>();

    //Army Training List
    public List<TroopTypeScript> barracksTrainingType = new List<TroopTypeScript>();
    public List<int> barracksTrainingAmount = new List<int>();
    public List<TroopTypeScript> archeryRangeTrainingType = new List<TroopTypeScript>();
    public List<int> archeryRangeTrainingAmount = new List<int>();
    public List<TroopTypeScript> cavalryYardTrainingType = new List<TroopTypeScript>();
    public List<int> cavalryYardTrainingAmount = new List<int>();

    //Army Training Capacities.
    public int barracksCapacity;
    public int archeryRangeCapacity;
    public int cavalryYardCapacity;

    //Arms Industry ICs.
    int blackSmithIC;
    int fletcherIC;
    int weaponSmithIC;
    int armorSmithIC;
    int siegeWorksIC;

    //Weapon Stocks.
    int spearStock;
    int swordStock;
    int axeStock;
    int maceStock;
    int bowStock;
    int crossbowStock;
    int pikeStock;
    int lanceStock;
    int woodenShieldStock;
    int ironShieldStock;
    int steelShieldStock;
    int leatherHelmStock;
    int ironHelmStock;
    int steelHelmStock;
    int leatherArmorStock;
    int ironArmorStock;
    int steelArmorStock;
    int horseStock;


    //Troop Numbers.
    List<TroopTypeScript> troopTypes = new List<TroopTypeScript>();
    List<int> troopNumbers = new List<int>();

    //Construction.
    public List<string> constructionList = new List<string>();
    public int woodAccumulationPool;
    public int stoneAccumulationPool;
    public int woodNeededForConstruction;
    public int stoneNeededForConstruction;
    public bool currentlyConstructing;
    public bool constructionPaused;

    


    void Awake()
    {
        //Find Common Ground.
        commonGround = GameObject.Find("CommonGround").GetComponent<CommonGround>();
        //Find Map
        map = GameObject.Find("TheServer").GetComponent<Map>();

    }

    void Start()
    {
        FindMyTradeNode();
        
        if(isServer == true)
        {
            //Start cycles.
            InvokeRepeating("Cycle", 1f, 2f);
        }
        else
        {
            return;
        }
        
    }

    //Cycle.
    void Cycle()
    {

        if (isSettled == true)
        {
            StartProduction();
            Consumption();
            ArmsIndustry();
            Construction();
        }
        


    }

   
    //***************Find Trade Node.
    public void FindMyTradeNode()
    {

        TradeNodeScript[] nodes = FindObjectsOfType(typeof(TradeNodeScript)) as TradeNodeScript[];



        List<TradeNodeScript> tnodes = new List<TradeNodeScript>();
        List<float> distances = new List<float>();
        Tile myTile = gameObject.GetComponent<Tile>();

        //Distanceları ölç.
        foreach(TradeNodeScript item in nodes)
        {
            TradeNodeScript nodeScript = item.GetComponent<TradeNodeScript>();

            float farkX = Mathf.Abs(nodeScript.myPosX - myTile.myPosX);
            float farkY = Mathf.Abs(nodeScript.myPosY - myTile.myPosY);

            float distance = Mathf.Sqrt(farkX * farkX + farkY * farkY);

            tnodes.Add(nodeScript);
            distances.Add(distance);

           
        }

        //En yakını bul.

        float minn = distances.Min();
        int minnIndex = distances.IndexOf(minn);
        TradeNodeScript closest = tnodes[minnIndex];

        //Set et.

        myTradeNode = closest;

    }

	//***************************Production.
	//Sectors that need raw materials always have to be after raw material production!

	void StartProduction ()
	{

		//Farm.(Food.)
		foodProduction = Mathf.FloorToInt (farmWorkers*foodFertility);
        

		//Pasture.(Food,Wool,Leather,Horse.) NEEDS REWORK FOR LIVESTOCK!!
		//Thoughts:Pasture's output shouldn't affected by worker amount.Main factor must be livestock.
		foodProduction = foodProduction + Mathf.FloorToInt (livestock / 2 * foodFertility);
        myTradeNode.UpdateFoodSupply(true, foodProduction);
        woolProduction = Mathf.FloorToInt (livestock * foodFertility);
        myTradeNode.UpdateWoolSupply(true, woolProduction);
        leatherProduction = Mathf.FloorToInt (livestock * foodFertility);
        myTradeNode.UpdateLeatherSupply(true, leatherProduction);
        horseProduction = Mathf.FloorToInt (livestock * foodFertility);
        myTradeNode.UpdateHorseSupply(true, horseProduction);


        //Lumberyard.(Wood.)
        woodProduction = Mathf.FloorToInt (lumberyardWorkers * woodFertility);
        myTradeNode.UpdateWoodSupply(true, woodProduction);

        //Quarry.(Stone.)
        stoneProduction = Mathf.FloorToInt (quarryWorkers * stoneFertility);
        myTradeNode.UpdateStoneSupply(true, stoneProduction);

        //Mine.(Iron Ore,Silver Ore,Gold Ore.)
        ironOreProduction = Mathf.FloorToInt (mineIronOreWorkers / 2 * ironOreFertility);
        myTradeNode.UpdateIronOreSupply(true, ironOreProduction);
        silverOreProduction = Mathf.FloorToInt (mineSilverOreWorkers / 2 * silverOreFertility);
        myTradeNode.UpdateSilverOreSupply(true, silverOreProduction);
        goldOreProduction = Mathf.FloorToInt (mineGoldOreWorkers / 2 * goldOreFertility);

        //Vineyard.(Wine.)
        wineProduction = Mathf.FloorToInt (vineyardWorkers * wineFertility);
        myTradeNode.UpdateWineSupply(true, wineProduction);

        //Tailor.(Cloth.)
        int clothProductionCapacity = Mathf.FloorToInt(tailorWorkers);
        int woolNeededForProduction = clothProductionCapacity * 1;
            if(woolProduction >= woolNeededForProduction)
            {
                clothProduction = clothProductionCapacity;
                woolLocalStock = woolProduction - woolNeededForProduction;
                clothLocalStock = clothProduction;
                myTradeNode.UpdateClothSupply(true, clothProduction);

        }
            else
            {
                int neededWool = woolNeededForProduction - woolProduction;
                int boughtAmount = BuyStuff(neededWool, myTradeNode.woolPrice, myTradeNode.woolStock);
                myTradeNode.UpdateWoolSupply(false, boughtAmount);
                myTradeNode.UpdateWoolStock(false, boughtAmount);
                clothProduction = (woolProduction + boughtAmount) / 1;
                woolLocalStock = 0;
                clothLocalStock = clothProduction;
                myTradeNode.UpdateClothSupply(true, clothProduction);
        }

        //Metal Works.(Iron Bar,Steel.)
        //IronBar.
        int ironBarProductionCapacity = Mathf.FloorToInt(metalWorksIronBarWorkers);
        int ironOreNeededForProduction = ironBarProductionCapacity * 1;
        if (ironOreProduction >= ironOreNeededForProduction)
        {
            ironBarProduction = ironBarProductionCapacity;
            ironOreLocalStock = ironOreProduction - ironOreNeededForProduction;
            ironBarLocalStock = ironBarProduction;
            myTradeNode.UpdateIronBarSupply(true, ironBarProduction);
        }
        else
        {
            int neededironOre = ironOreNeededForProduction - ironOreProduction;
            int boughtAmount = BuyStuff(neededironOre, myTradeNode.ironOrePrice, myTradeNode.ironOreStock);
            myTradeNode.UpdateIronOreSupply(false, boughtAmount);
            myTradeNode.UpdateIronOreStock(false, boughtAmount);
            ironBarProduction = (ironOreProduction + boughtAmount) / 1;
            ironOreLocalStock = 0;
            ironBarLocalStock = ironBarProduction;
            myTradeNode.UpdateIronBarSupply(true, ironBarProduction);
        }

        //Steel.
        int steelProductionCapacity = Mathf.FloorToInt(metalWorksSteelWorkers);
        int ironBarNeededForProduction = steelProductionCapacity * 1;
        if (ironBarProduction >= ironBarNeededForProduction)
        {
            steelProduction = steelProductionCapacity;
            ironBarLocalStock = ironBarProduction - ironBarNeededForProduction;
            steelLocalStock = steelProduction;
            myTradeNode.UpdateSteelSupply(true, steelProduction);
        }
        else
        {
            int neededironBar = ironBarNeededForProduction - ironBarProduction;
            int boughtAmount = BuyStuff(neededironBar, myTradeNode.ironBarPrice, myTradeNode.ironBarStock);
            myTradeNode.UpdateIronBarSupply(false, boughtAmount);
            myTradeNode.UpdateIronBarStock(false, boughtAmount);
            steelProduction = (ironBarProduction + boughtAmount) / 1;
            ironBarLocalStock = 0;
            steelLocalStock = steelProduction;
            myTradeNode.UpdateSteelSupply(true, steelProduction);
        }
        

        //Jewelry.(Silverware.)
        int silverWareProductionCapacity = Mathf.FloorToInt(jewelryWorkers);
        int silverOreNeededForProduction = silverWareProductionCapacity * 1;
        if (silverOreProduction >= silverOreNeededForProduction)
        {
            silverWareProduction = silverWareProductionCapacity;
            silverOreLocalStock = silverOreProduction - silverOreNeededForProduction;
            silverWareLocalStock = silverWareProduction;
            myTradeNode.UpdateSilverWareSupply(true, silverWareProduction);
        }
        else
        {
            int neededsilverOre = silverOreNeededForProduction - silverOreProduction;
            int boughtAmount = BuyStuff(neededsilverOre, myTradeNode.silverOrePrice, myTradeNode.silverOreStock);
            myTradeNode.UpdateSilverOreSupply(false, boughtAmount);
            myTradeNode.UpdateSilverOreStock(false, boughtAmount);
            silverWareProduction = (silverOreProduction + boughtAmount) / 1;
            silverOreLocalStock = 0;
            silverWareLocalStock = silverWareProduction;
            myTradeNode.UpdateSilverWareSupply(true, silverWareProduction);
        }





    }

	//**********************Consumption.Also includes associated happiness calculations.
	void Consumption ()
	{

		//Food.
		int foodConsumption = population * 1;

		if (foodProduction >= foodConsumption)
		{
			foodLocalStock = foodProduction - foodConsumption;
			foodHappiness = 100f;
			myTradeNode.UpdateFoodSupply (false, foodConsumption);
			
		}
			else
		{
			int foodToBuy = foodConsumption - foodProduction;
			int boughtAmount = BuyStuff (foodToBuy , myTradeNode.foodPrice, myTradeNode.foodStock);
			foodHappiness = boughtAmount / foodConsumption * 100;
			myTradeNode.UpdateFoodSupply (false, foodToBuy);
			myTradeNode.UpdateFoodStock (false, boughtAmount);
			foodLocalStock = 0;


		}

		//Wood.Oc,Şu,Ma,Ka,Ar ayları.
		int woodConsumption = population * 1;

		if(commonGround.month < 4 || commonGround.month > 10)
		{
			if (woodProduction >= woodConsumption)
			{
				woodLocalStock = woodProduction - woodConsumption;
				woodHappiness = 100f;
				myTradeNode.UpdateWoodSupply (false, woodConsumption);
				

			}
			else
			{
				int woodToBuy = woodConsumption - woodProduction;
				int boughtAmount = BuyStuff (woodToBuy, myTradeNode.woodPrice , myTradeNode.woodStock);
				woodHappiness = boughtAmount / woodConsumption * 100;
				myTradeNode.UpdateWoodSupply (false, woodToBuy);
				myTradeNode.UpdateWoodStock (false, boughtAmount);
				woodLocalStock = 0;

			}


		//Wine.**NEEDS MONTH FıXıNG!
		int wineConsumption = population * 1;

		if (wineProduction >= wineConsumption)
		{
			wineLocalStock = wineProduction - wineConsumption;
			wineHappiness = 100f;
			myTradeNode.UpdateWineSupply (false, wineConsumption);
			


		}
		else
		{
			int wineToBuy = wineConsumption - wineProduction;
			int boughtAmount = BuyStuff (wineToBuy, myTradeNode.winePrice,  myTradeNode.wineStock);
			wineHappiness = boughtAmount / wineConsumption * 100;
			myTradeNode.UpdateWineSupply (false, wineToBuy);
			myTradeNode.UpdateWineStock (false, boughtAmount);
			wineLocalStock = 0;

		}

			//cloth.**NEEDS MONTH FıXıNG!
			int clothConsumption = population * 1;

			if (clothProduction >= clothConsumption)
			{
				clothLocalStock = clothProduction - clothConsumption;
				clothHappiness = 100f;
				myTradeNode.UpdateClothSupply (false, clothConsumption);
				

			}
			else
			{
				int clothToBuy = clothConsumption - clothProduction;
				int boughtAmount = BuyStuff (clothToBuy, myTradeNode.clothPrice ,  myTradeNode.clothStock);
				clothHappiness = boughtAmount / clothConsumption * 100;
				myTradeNode.UpdateClothSupply (false, clothToBuy);
				myTradeNode.UpdateClothStock (false, boughtAmount);
				clothLocalStock = 0;

			}


			//silverWare.**NEEDS MONTH FıXıNG!
			int silverWareConsumption = population * 1;

			if (silverWareProduction >= silverWareConsumption)
			{
				silverWareLocalStock = silverWareProduction - silverWareConsumption;
				silverWareHappiness = 100f;
				myTradeNode.UpdateSilverWareSupply (false, silverWareConsumption);
				

			}
			else
			{
				int silverWareToBuy = silverWareConsumption - silverWareProduction;
				int boughtAmount = BuyStuff (silverWareToBuy, myTradeNode.silverWarePrice ,  myTradeNode.silverWareStock);
				silverWareHappiness = boughtAmount / silverWareConsumption * 100;
				myTradeNode.UpdateSilverWareSupply (false, silverWareToBuy);
				myTradeNode.UpdateSilverWareStock (false, boughtAmount);
				silverWareLocalStock = 0;

			}

		}

	}


    //****************************Happiness NEEDS FIX.

    void HappinessCalculations()
    {

        float totalHappiness = 0f;

        //***Elzem tüketim.Olmayışı üzer,oluşu sevindirmez.
        //Food
        totalHappiness -= 100 - foodHappiness;
        //Wood
        totalHappiness -= 100 - woodHappiness;

        //***Normal tüketim.Olmayışı üzer,oluşu sevindirir.
        //Wine
        if(wineHappiness >= 50f)
        {
            totalHappiness += wineHappiness * 5;
        }
        else
        {
            totalHappiness -= wineHappiness * 5;
        }
        //Cloth
        if(clothHappiness >= 50f)
        {
            totalHappiness += clothHappiness * 5;
        }
        else
        {
            totalHappiness -= clothHappiness * 5;
        }

        //***Lüks tüketim.Olmayışı üzmez,oluşu sevindirir.
        //SilverWare
        totalHappiness += silverWareHappiness * 5;

        //Conclusion.

        myHappiness = totalHappiness / 25;
    }


    //****************************Arms Industry.

    void ArmsIndustry()
    {

        //First,calculate ICs.

        blackSmithIC = blackSmithLevel * 10;
        fletcherIC = fletcherLevel * 10;
        weaponSmithIC = weaponSmithLevel * 10;
        armorSmithIC = armorSmithLevel * 10;
        siegeWorksIC = siegeWorksLevel * 10;

        //Then run the wheel.
        if(blackSmithOrderType.Count > 0)
        {
            BlackSmithProduction(blackSmithIC);
        }
        if (fletcherOrderType.Count > 0)
        {
            FletcherProduction(weaponSmithIC);
        }
        if (weaponSmithOrderType.Count > 0)
        {
            WeaponSmithProduction(armorSmithIC);
        }
        if (armorSmithOrderType.Count > 0)
        {
            ArmorSmithProduction(siegeWorksIC);
        }
        if (siegeWorksOrderType.Count > 0)
        {
            SiegeWorksProduction(siegeWorksIC);
        }
        
        
        

    }

    void BlackSmithProduction(int ic)
    {
        //First find order and amount.
        string orderType = blackSmithOrderType[0];
        int orderAmount = blacksmithOrderAmount[0];

        //Find possible amounts.
        int[] littleArray = OrderAmountFromIC(orderType, ic);
        int[] mainArray = OrderAmountFromGoldAndRawMaterialStocks(orderType);

        int fromIC = littleArray[0];
        int icCost = littleArray[1];

        int fromGoldAnRMCheck = mainArray[0];
        int woodCost = mainArray[1];
        int leatherCost = mainArray[2];
        int ironBarCost = mainArray[3];
        int steelCost = mainArray[4];

        //Check how many are producable.
        int[] checkArray = new int[3];
        checkArray[0] = fromIC;
        checkArray[1] = fromGoldAnRMCheck;
        checkArray[2] = orderAmount;

        int amountToProduce = checkArray.Min();

        //Buy materials.

        //Wood.
        BuyStuffState(woodCost * amountToProduce, myTradeNode.woodPrice, myTradeNode.woodStock);
        myTradeNode.UpdateWoodSupply(false, woodCost * amountToProduce);
        myTradeNode.UpdateWoodStock(false, woodCost * amountToProduce);

        //Leather.
        BuyStuffState(leatherCost * amountToProduce, myTradeNode.leatherPrice, myTradeNode.leatherStock);
        myTradeNode.UpdateLeatherSupply(false, leatherCost * amountToProduce);
        myTradeNode.UpdateLeatherStock(false, leatherCost * amountToProduce);

        //Iron Bar.
        BuyStuffState(ironBarCost * amountToProduce, myTradeNode.ironBarPrice, myTradeNode.ironBarStock);
        myTradeNode.UpdateIronBarSupply(false, ironBarCost * amountToProduce);
        myTradeNode.UpdateIronBarStock(false, ironBarCost * amountToProduce);

        //Steel.
        BuyStuffState(steelCost * amountToProduce, myTradeNode.steelPrice, myTradeNode.steelStock);
        myTradeNode.UpdateSteelSupply(false, steelCost * amountToProduce);
        myTradeNode.UpdateSteelStock(false, steelCost * amountToProduce);

        //Update Weapon Stocks.

        UpdateWeaponStocks(true, orderType, amountToProduce);

        //Update Remaining IC.

        blackSmithIC -= icCost * amountToProduce;

        //Update Order.

        UpdateOrder(false, "BlackSmith", amountToProduce, "none");

        //If IC remains recall this.(I need a test run for this recalling style.)

        if (blackSmithIC >= 0)
        {
            BlackSmithProduction(blackSmithIC);
        }
        
    }

    void FletcherProduction(int ic)
    {
        //First find order and amount.
        string orderType = fletcherOrderType[0];
        int orderAmount = fletcherOrderAmount[0];

        //Find possible amounts.
        int[] littleArray = OrderAmountFromIC(orderType, ic);
        int[] mainArray = OrderAmountFromGoldAndRawMaterialStocks(orderType);

        int fromIC = littleArray[0];
        int icCost = littleArray[1];

        int fromGoldAnRMCheck = mainArray[0];
        int woodCost = mainArray[1];
        int leatherCost = mainArray[2];
        int ironBarCost = mainArray[3];
        int steelCost = mainArray[4];

        //Check how many are producable.
        int[] checkArray = new int[3];
        checkArray[0] = fromIC;
        checkArray[1] = fromGoldAnRMCheck;
        checkArray[2] = orderAmount;

        int amountToProduce = checkArray.Min();

        //Buy materials.

        //Wood.
        BuyStuffState(woodCost * amountToProduce, myTradeNode.woodPrice, myTradeNode.woodStock);
        myTradeNode.UpdateWoodSupply(false, woodCost * amountToProduce);
        myTradeNode.UpdateWoodStock(false, woodCost * amountToProduce);

        //Leather.
        BuyStuffState(leatherCost * amountToProduce, myTradeNode.leatherPrice, myTradeNode.leatherStock);
        myTradeNode.UpdateLeatherSupply(false, leatherCost * amountToProduce);
        myTradeNode.UpdateLeatherStock(false, leatherCost * amountToProduce);

        //Iron Bar.
        BuyStuffState(ironBarCost * amountToProduce, myTradeNode.ironBarPrice, myTradeNode.ironBarStock);
        myTradeNode.UpdateIronBarSupply(false, ironBarCost * amountToProduce);
        myTradeNode.UpdateIronBarStock(false, ironBarCost * amountToProduce);

        //Steel.
        BuyStuffState(steelCost * amountToProduce, myTradeNode.steelPrice, myTradeNode.steelStock);
        myTradeNode.UpdateSteelSupply(false, steelCost * amountToProduce);
        myTradeNode.UpdateSteelStock(false, steelCost * amountToProduce);

        //Update Weapon Stocks.

        UpdateWeaponStocks(true, orderType, amountToProduce);

        //Update Remaining IC.

        fletcherIC -= icCost * amountToProduce;

        //Update Order.

        UpdateOrder(false, "Fletcher", amountToProduce, "none");

        //If IC remains recall this.(I need a test run for this recalling style.)

        if (fletcherIC > 0) 
        {
            FletcherProduction(fletcherIC);
        }
    }

    void WeaponSmithProduction(int ic)
    {
        //First find order and amount.
        string orderType = weaponSmithOrderType[0];
        int orderAmount = weaponSmithOrderAmount[0];

        //Find possible amounts.
        int[] littleArray = OrderAmountFromIC(orderType, ic);
        int[] mainArray = OrderAmountFromGoldAndRawMaterialStocks(orderType);

        int fromIC = littleArray[0];
        int icCost = littleArray[1];

        int fromGoldAnRMCheck = mainArray[0];
        int woodCost = mainArray[1];
        int leatherCost = mainArray[2];
        int ironBarCost = mainArray[3];
        int steelCost = mainArray[4];

        //Check how many are producable.
        int[] checkArray = new int[3];
        checkArray[0] = fromIC;
        checkArray[1] = fromGoldAnRMCheck;
        checkArray[2] = orderAmount;

        int amountToProduce = checkArray.Min();

        //Buy materials.

        //Wood.
        BuyStuffState(woodCost * amountToProduce, myTradeNode.woodPrice, myTradeNode.woodStock);
        myTradeNode.UpdateWoodSupply(false, woodCost * amountToProduce);
        myTradeNode.UpdateWoodStock(false, woodCost * amountToProduce);

        //Leather.
        BuyStuffState(leatherCost * amountToProduce, myTradeNode.leatherPrice, myTradeNode.leatherStock);
        myTradeNode.UpdateLeatherSupply(false, leatherCost * amountToProduce);
        myTradeNode.UpdateLeatherStock(false, leatherCost * amountToProduce);

        //Iron Bar.
        BuyStuffState(ironBarCost * amountToProduce, myTradeNode.ironBarPrice, myTradeNode.ironBarStock);
        myTradeNode.UpdateIronBarSupply(false, ironBarCost * amountToProduce);
        myTradeNode.UpdateIronBarStock(false, ironBarCost * amountToProduce);

        //Steel.
        BuyStuffState(steelCost * amountToProduce, myTradeNode.steelPrice, myTradeNode.steelStock);
        myTradeNode.UpdateSteelSupply(false, steelCost * amountToProduce);
        myTradeNode.UpdateSteelStock(false, steelCost * amountToProduce);

        //Update Weapon Stocks.

        UpdateWeaponStocks(true, orderType, amountToProduce);

        //Update Remaining IC.

        weaponSmithIC -= icCost * amountToProduce;

        //Update Order.

        UpdateOrder(false, "WeaponSmith", amountToProduce, "none");

        //If IC remains recall this.(I need a test run for this recalling style.)

        if (weaponSmithIC > 0) 
        {
            WeaponSmithProduction(weaponSmithIC);
        }
    }

    void ArmorSmithProduction(int ic)
    {
        //First find order and amount.
        string orderType = armorSmithOrderType[0];
        int orderAmount = armorSmithOrderAmount[0];

        //Find possible amounts.
        int[] littleArray = OrderAmountFromIC(orderType, ic);
        int[] mainArray = OrderAmountFromGoldAndRawMaterialStocks(orderType);

        int fromIC = littleArray[0];
        int icCost = littleArray[1];

        int fromGoldAnRMCheck = mainArray[0];
        int woodCost = mainArray[1];
        int leatherCost = mainArray[2];
        int ironBarCost = mainArray[3];
        int steelCost = mainArray[4];

        //Check how many are producable.
        int[] checkArray = new int[3];
        checkArray[0] = fromIC;
        checkArray[1] = fromGoldAnRMCheck;
        checkArray[2] = orderAmount;

        int amountToProduce = checkArray.Min();

        //Buy materials.

        //Wood.
        BuyStuffState(woodCost * amountToProduce, myTradeNode.woodPrice, myTradeNode.woodStock);
        myTradeNode.UpdateWoodSupply(false, woodCost * amountToProduce);
        myTradeNode.UpdateWoodStock(false, woodCost * amountToProduce);

        //Leather.
        BuyStuffState(leatherCost * amountToProduce, myTradeNode.leatherPrice, myTradeNode.leatherStock);
        myTradeNode.UpdateLeatherSupply(false, leatherCost * amountToProduce);
        myTradeNode.UpdateLeatherStock(false, leatherCost * amountToProduce);

        //Iron Bar.
        BuyStuffState(ironBarCost * amountToProduce, myTradeNode.ironBarPrice, myTradeNode.ironBarStock);
        myTradeNode.UpdateIronBarSupply(false, ironBarCost * amountToProduce);
        myTradeNode.UpdateIronBarStock(false, ironBarCost * amountToProduce);

        //Steel.
        BuyStuffState(steelCost * amountToProduce, myTradeNode.steelPrice, myTradeNode.steelStock);
        myTradeNode.UpdateSteelSupply(false, steelCost * amountToProduce);
        myTradeNode.UpdateSteelStock(false, steelCost * amountToProduce);

        //Update Weapon Stocks.

        UpdateWeaponStocks(true, orderType, amountToProduce);

        //Update Remaining IC.

        armorSmithIC -= icCost * amountToProduce;

        //Update Order.

        UpdateOrder(false, "ArmorSmith", amountToProduce, "none");

        //If IC remains recall this.(I need a test run for this recalling style.)

        if (armorSmithIC > 0) 
        {
            ArmorSmithProduction(armorSmithIC);
        }
    }

    void SiegeWorksProduction(int ic)
    {
        //First find order and amount.
        string orderType = siegeWorksOrderType[0];
        int orderAmount = siegeWorksOrderAmount[0];

        //Find possible amounts.
        int[] littleArray = OrderAmountFromIC(orderType, ic);
        int[] mainArray = OrderAmountFromGoldAndRawMaterialStocks(orderType);

        int fromIC = littleArray[0];
        int icCost = littleArray[1];

        int fromGoldAnRMCheck = mainArray[0];
        int woodCost = mainArray[1];
        int leatherCost = mainArray[2];
        int ironBarCost = mainArray[3];
        int steelCost = mainArray[4];

        //Check how many are producable.
        int[] checkArray = new int[3];
        checkArray[0] = fromIC;
        checkArray[1] = fromGoldAnRMCheck;
        checkArray[2] = orderAmount;

        int amountToProduce = checkArray.Min();

        //Buy materials.

        //Wood.
        BuyStuffState(woodCost * amountToProduce, myTradeNode.woodPrice, myTradeNode.woodStock);
        myTradeNode.UpdateWoodSupply(false, woodCost * amountToProduce);
        myTradeNode.UpdateWoodStock(false, woodCost * amountToProduce);

        //Leather.
        BuyStuffState(leatherCost * amountToProduce, myTradeNode.leatherPrice, myTradeNode.leatherStock);
        myTradeNode.UpdateLeatherSupply(false, leatherCost * amountToProduce);
        myTradeNode.UpdateLeatherStock(false, leatherCost * amountToProduce);

        //Iron Bar.
        BuyStuffState(ironBarCost * amountToProduce, myTradeNode.ironBarPrice, myTradeNode.ironBarStock);
        myTradeNode.UpdateIronBarSupply(false, ironBarCost * amountToProduce);
        myTradeNode.UpdateIronBarStock(false, ironBarCost * amountToProduce);

        //Steel.
        BuyStuffState(steelCost * amountToProduce, myTradeNode.steelPrice, myTradeNode.steelStock);
        myTradeNode.UpdateSteelSupply(false, steelCost * amountToProduce);
        myTradeNode.UpdateSteelStock(false, steelCost * amountToProduce);

        //Update Weapon Stocks.

        UpdateWeaponStocks(true, orderType, amountToProduce);

        //Update Remaining IC.

        siegeWorksIC -= icCost * amountToProduce;

        //Update Order.

        UpdateOrder(false, "SiegeWorks", amountToProduce, "none");

        //If IC remains recall this.(I need a test run for this recalling style.)

        if (siegeWorksIC > 0) 
        {
            BlackSmithProduction(siegeWorksIC);
        }
    }




    //****************************Building.

    public void AddToConstructionList(string buildingListType)
    {
        constructionList.Add(buildingListType);
    }     
        

    void PauseConstruction()
    {
        if(constructionPaused == false)
        {            
            constructionPaused = true;
        }
        else
        {
            constructionPaused = false;
        }
    }

    void RemoveConstruction(int listIndex) //To avoid confusion it takes exact place on the list.
    {

    }

    void Construction()
	{

        
        bool woodPhaseCompleted;
        bool stonePhaseCompleted;

        

        //First find if there is something to be built.
        if(constructionList.Count > 0)
        {
            int[] array = BuildingCostDecider(constructionList[0]);
            array[0] = woodNeededForConstruction;
            array[1] = stoneNeededForConstruction;

            currentlyConstructing = true;
        }
        


		if(currentlyConstructing == true && constructionPaused == false)
        {
            //Accumulate wood.
            int woodAmount = myKingdom.constructionSpeed;

            if ((woodNeededForConstruction - woodAccumulationPool) >= woodAmount)
            {
                if (woodLocalStock >= woodAmount)
                {
                    woodAccumulationPool = woodAccumulationPool + woodAmount;
                    woodLocalStock = woodLocalStock - woodAmount;
                }
                else
                {
                    int woodToBuy = woodAmount - woodLocalStock;
                    int boughtAmount = BuyStuffState(woodToBuy, myTradeNode.woodPrice, myTradeNode.woodStock);
                    myTradeNode.UpdateWoodSupply(false, boughtAmount);
                    myTradeNode.UpdateWoodStock(false, boughtAmount);
                    woodAccumulationPool = woodLocalStock + boughtAmount;
                    woodLocalStock = 0;
                }
            }
            else
            {

                int woodAmountSmall = woodNeededForConstruction - woodAccumulationPool;

                if (woodLocalStock >= woodAmountSmall)
                {
                    woodAccumulationPool = woodAccumulationPool + woodAmountSmall;
                    woodLocalStock = woodLocalStock - woodAmountSmall;
                }
                else
                {
                    int woodToBuy = woodAmountSmall - woodLocalStock;
                    int boughtAmount = BuyStuffState(woodToBuy, myTradeNode.woodPrice, myTradeNode.woodStock);
                    myTradeNode.UpdateWoodSupply(false, boughtAmount);
                    myTradeNode.UpdateWoodStock(false, boughtAmount);
                    woodAccumulationPool = woodLocalStock + boughtAmount;
                    woodLocalStock = 0;
                }

            }
         
 
            //Accumulate stone.
            int stoneAmount = myKingdom.constructionSpeed;

            if ((stoneNeededForConstruction - stoneAccumulationPool) >= stoneAmount)
            {
                if (stoneLocalStock >= stoneAmount)
                {
                    stoneAccumulationPool = stoneAccumulationPool + stoneAmount;
                    stoneLocalStock = stoneLocalStock - stoneAmount;
                }
                else
                {
                    int stoneToBuy = stoneAmount - stoneLocalStock;
                    int boughtAmount = BuyStuffState(stoneToBuy, myTradeNode.stonePrice, myTradeNode.stoneStock);
                    myTradeNode.UpdateStoneSupply(false, boughtAmount);
                    myTradeNode.UpdateStoneStock(false, boughtAmount);
                    stoneAccumulationPool = stoneLocalStock + boughtAmount;
                    stoneLocalStock = 0;
                }
            }
            else
            {

                int stoneAmountSmall = stoneNeededForConstruction - stoneAccumulationPool;

                if (stoneLocalStock >= stoneAmountSmall)
                {
                    stoneAccumulationPool = stoneAccumulationPool + stoneAmountSmall;
                    stoneLocalStock = stoneLocalStock - stoneAmountSmall;
                }
                else
                {
                    int stoneToBuy = stoneAmountSmall - stoneLocalStock;
                    int boughtAmount = BuyStuffState(stoneToBuy, myTradeNode.stonePrice, myTradeNode.stoneStock);
                    myTradeNode.UpdateStoneSupply(false, boughtAmount);
                    myTradeNode.UpdateStoneStock(false, boughtAmount);
                    stoneAccumulationPool = stoneLocalStock + boughtAmount;
                    stoneLocalStock = 0;
                }

            }

           
        }


        //Finalize construction.


        if (woodAccumulationPool >= woodNeededForConstruction)
        {
            woodPhaseCompleted = true;
        }
        else
        {
            woodPhaseCompleted = false;
        }

        if (stoneAccumulationPool >= stoneNeededForConstruction)
        {
            stonePhaseCompleted = true;
        }
        else
        {
            stonePhaseCompleted = false;
        }

        if (woodPhaseCompleted == true && stonePhaseCompleted == true)
        {
            //Run the logic.                       
            if(constructionList.Count < 0)
            {
                gameObject.GetComponent<BuildingLevelUpper>().BuildingLevelUp(constructionList[0]);
            }
            
        }

    }


    //**************************Army Training
    //No siege training cause why we need them?They are equipments.
    //(Seems like no one needs engineers to use catapults :))

        void ArmyTraining()
    {
        //Calculate training capacities.

        //Then run the wheel.
    }

    void BarracksTraining(int trainCapacity)
    {
        //Find what to train.

        TroopTypeScript troopTypeToTrain = barracksTrainingType[0];
        int troopAmountToTrain = barracksTrainingAmount[0];
        
        //Check trainable amount.(Capacity,manpower,equipment.)

        int[] array = TrainAmountFromWeapons(troopTypeToTrain.equipment);
        
        int[] checkArray = new int[7];

        checkArray[0] = array[0]; //Weapon
        checkArray[1] = array[1]; //Shield
        checkArray[2] = array[2]; //Helm
        checkArray[3] = array[3]; //Armor
        checkArray[4] = array[4]; //Horse
        checkArray[5] = currentManpower; //Manpower
        checkArray[6] = trainCapacity; //Capacity

        int amountToTrain = checkArray.Min();


        //Use weapons and manpower.(Just update stocks.)

        UpdateWeaponStocks(false, troopTypeToTrain.equipment[0], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[1], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[2], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[3], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[4], amountToTrain);

        currentManpower -= amountToTrain;

        //Update remaining capacity.

        barracksCapacity -= amountToTrain;

        //Update troop numbers.(I think we need a coroutine here to mimic training time.)

        float trainingTime = 1f;

        StartCoroutine(UpdateTroopNumbers(troopTypeToTrain, trainingTime, troopAmountToTrain));

        //Add this to UI list.So user can see ongoing trainings.

        //Re-run this if there is capacity.

        if(barracksCapacity>0)
        {
            BarracksTraining(barracksCapacity);
        }
    }

    void ArcheryRangeTraining(int trainCapacity)
    {
        //Find what to train.

        TroopTypeScript troopTypeToTrain = archeryRangeTrainingType[0];
        int troopAmountToTrain = archeryRangeTrainingAmount[0];

        //Check trainable amount.(Capacity,manpower,equipment.)

        int[] array = TrainAmountFromWeapons(troopTypeToTrain.equipment);

        int[] checkArray = new int[7];

        checkArray[0] = array[0]; //Weapon
        checkArray[1] = array[1]; //Shield
        checkArray[2] = array[2]; //Helm
        checkArray[3] = array[3]; //Armor
        checkArray[4] = array[4]; //Horse
        checkArray[5] = currentManpower; //Manpower
        checkArray[6] = trainCapacity; //Capacity

        int amountToTrain = checkArray.Min();


        //Use weapons and manpower.(Just update stocks.)

        UpdateWeaponStocks(false, troopTypeToTrain.equipment[0], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[1], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[2], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[3], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[4], amountToTrain);

        currentManpower -= amountToTrain;

        //Update remaining capacity.

        archeryRangeCapacity -= amountToTrain;

        //Update troop numbers.(I think we need a coroutine here to mimic training time.)

        float trainingTime = 1f;

        StartCoroutine(UpdateTroopNumbers(troopTypeToTrain, trainingTime, troopAmountToTrain));

        //Add this to UI list.So user can see ongoing trainings.

        //Re-run this if there is capacity.

        if (archeryRangeCapacity > 0)
        {
            ArcheryRangeTraining(archeryRangeCapacity);
        }
    }

    void CavalryYardTraining(int trainCapacity)
    {
        //Find what to train.

        TroopTypeScript troopTypeToTrain = cavalryYardTrainingType[0];
        int troopAmountToTrain = cavalryYardTrainingAmount[0];

        //Check trainable amount.(Capacity,manpower,equipment.)

        int[] array = TrainAmountFromWeapons(troopTypeToTrain.equipment);

        int[] checkArray = new int[7];

        checkArray[0] = array[0]; //Weapon
        checkArray[1] = array[1]; //Shield
        checkArray[2] = array[2]; //Helm
        checkArray[3] = array[3]; //Armor
        checkArray[4] = array[4]; //Horse
        checkArray[5] = currentManpower; //Manpower
        checkArray[6] = trainCapacity; //Capacity

        int amountToTrain = checkArray.Min();


        //Use weapons and manpower.(Just update stocks.)

        UpdateWeaponStocks(false, troopTypeToTrain.equipment[0], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[1], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[2], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[3], amountToTrain);
        UpdateWeaponStocks(false, troopTypeToTrain.equipment[4], amountToTrain);

        currentManpower -= amountToTrain;

        //Update remaining capacity.

        cavalryYardCapacity -= amountToTrain;

        //Update troop numbers.(I think we need a coroutine here to mimic training time.)

        float trainingTime = 1f;

        StartCoroutine(UpdateTroopNumbers(troopTypeToTrain, trainingTime, troopAmountToTrain));

        //Add this to UI list.So user can see ongoing trainings.

        //Re-run this if there is capacity.

        if (cavalryYardCapacity > 0)
        {
            CavalryYardTraining(cavalryYardCapacity);
        }
    }

    

    // *********** SUB METHODES START HERE!!*************


	//******************************Buy stuff.

        //Buy Stuff (private sector.)
	int BuyStuff(int amount , float price , int stock)
	{
		int amountFromGoldCheck = Mathf.FloorToInt (myGold / price);
		int amountFromStockCheck = stock;
		int[] checkArray = new int[3];

		checkArray[0] = amountFromGoldCheck;
		checkArray [1] = amountFromStockCheck;
		checkArray [2] = amount;

		int boughtAmount = checkArray.Min ();

		myGold = myGold - (boughtAmount * price);

        if(boughtAmount < 0)
        {
            boughtAmount = 0;
        }

		return boughtAmount;

	}

    //Buy Stuff (state sector.)
    int BuyStuffState(int amount, float price, int stock)
    {
        int amountFromGoldCheck = Mathf.FloorToInt(myKingdom.myGold / price);
        int amountFromStockCheck = stock;
        int[] checkArray = new int[3];

        checkArray[0] = amountFromGoldCheck;
        checkArray[1] = amountFromStockCheck;
        checkArray[2] = amount;

        int boughtAmount = checkArray.Min();

        myKingdom.myGold = myKingdom.myGold - (boughtAmount * price);

        return boughtAmount;

    }



    //******************************Sell Stuff.

    void SellStuff(int amount, float price)
	{
		float goldToReceive = amount * price;
		myGold = myGold + goldToReceive;
	}



    int[] OrderAmountFromIC(string type, int icCapacity)
    {
        int icCost = 0;

        if(type == "Spear")
        {
            icCost = 1;
        }
        if (type == "Sword")
        {
            icCost = 1;
        }
        if (type == "Axe")
        {
            icCost = 1;
        }
        if (type == "Mace")
        {
            icCost = 1;
        }
        if (type == "Bow")
        {
            icCost = 1;
        }
        if (type == "Crossbow")
        {
            icCost = 1;
        }
        if (type == "Pike")
        {
            icCost = 1;
        }
        if (type == "Lance")
        {
            icCost = 1;
        }
        if (type == "Mace")
        {
            icCost = 1;
        }
        if (type == "WoodenShield")
        {
            icCost = 1;
        }
        if (type == "IronShield")
        {
            icCost = 1;
        }
        if (type == "SteelShield")
        {
            icCost = 1;
        }
        if (type == "LeatherHelm")
        {
            icCost = 1;
        }
        if (type == "IronHelm")
        {
            icCost = 1;
        }
        if (type == "SteelHelm")
        {
            icCost = 1;
        }
        if (type == "LeatherArmor")
        {
            icCost = 1;
        }
        if (type == "IronArmor")
        {
            icCost = 1;
        }
        if (type == "SteelArmor")
        {
            icCost = 1;
        }

        int finalAmount = icCapacity / icCost;

        int[] finalAmounts = new int[2];
        finalAmounts[0] = finalAmount;
        finalAmounts[1] = icCost;

        return finalAmounts;
    }

    int[] OrderAmountFromGoldAndRawMaterialStocks(string type)
    {

        int woodCost = 0;
        int leatherCost = 0;
        int ironBarCost = 0;
        int steelCost = 0;

        if (type == "Spear")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "Sword")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "Axe")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "Mace")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "Bow")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "Crossbow")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "Pike")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "Lance")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "Mace")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "WoodenShield")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "IronShield")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "SteelShield")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "LeatherHelm")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "IronHelm")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "SteelHelm")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "LeatherArmor")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "IronArmor")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }
        if (type == "SteelArmor")
        {
            woodCost = 1;
            leatherCost = 1;
            ironBarCost = 1;
            steelCost = 1;
        }

        int wood = (woodLocalStock + myTradeNode.woodStock) / woodCost;
        int leather = (leatherLocalStock + myTradeNode.leatherStock) / leatherCost;
        int ironBar = (ironBarLocalStock + myTradeNode.ironBarStock) / ironBarCost;
        int steel = (steelLocalStock + myTradeNode.steelStock) / steelCost;

        //Eğer hamlardan birine ihtiyaç yoksa,buga girmemek için aşağıdaki uygulanıyor.
        if (woodCost == 0)
        {
            wood = 100000;
        }
        if (leatherCost == 0)
        {
            leather = 100000;
        }
        if (ironBarCost == 0)
        {
            ironBar = 100000;
        }
        if (steelCost == 0)
        {
            steel = 100000;
        }


        int[] checkArray = new int[4];
        checkArray[0] = wood;
        checkArray[1] = leather;
        checkArray[2] = ironBar;
        checkArray[3] = steel;

        int amountFromStocks = checkArray.Min();

        //Now Gold check.

        //Bir tane silah için gerekli gold.
        float woody = woodCost * myTradeNode.woodPrice;
        float leathery = leatherCost * myTradeNode.leatherPrice;
        float irony = ironBarCost * myTradeNode.ironBarPrice;
        float steely = steelCost * myTradeNode.steelPrice;

        float totalCost = woody + leathery + irony + steely;

        int amountFromGold = Mathf.FloorToInt(myKingdom.myGold / totalCost);

        int[] array = new int[2];
        array[0] = amountFromStocks;
        array[1] = amountFromGold;

        int finalAmount = array.Min();


        //Bu methode bir daha yazmamak için,array dönütü var.
        //Array Yapısı:
        //FinalAmount
        //Wood bir adet için.
        //Leather bir adet için.
        //IronBar bir adet için.
        //Steel bir adet için.

        int[] finalAmounts = new int[5];
        finalAmounts[0] = finalAmount;
        finalAmounts[1] = woodCost;
        finalAmounts[2] = leatherCost;
        finalAmounts[3] = ironBarCost;
        finalAmounts[4] = steelCost;

        return finalAmounts;
    }

    void UpdateWeaponStocks(bool isIncrease, string type, int amount)
    {
        if(type == "Spear")
        {
            if(isIncrease == true)
            {
                spearStock += amount;
            }
            else
            {
                spearStock -= amount;
            }
        }
        if (type == "Sword")
        {
            if (isIncrease == true)
            {
                swordStock += amount;
            }
            else
            {
                swordStock -= amount;
            }
        }
        if (type == "Axe")
        {
            if (isIncrease == true)
            {
                axeStock += amount;
            }
            else
            {
                axeStock -= amount;
            }
        }
        if (type == "Mace")
        {
            if (isIncrease == true)
            {
                maceStock += amount;
            }
            else
            {
                maceStock -= amount;
            }
        }
        if (type == "Bow")
        {
            if (isIncrease == true)
            {
                bowStock += amount;
            }
            else
            {
                bowStock -= amount;
            }
        }
        if (type == "Crossbow")
        {
            if (isIncrease == true)
            {
                crossbowStock += amount;
            }
            else
            {
                crossbowStock -= amount;
            }
        }
        if (type == "Pike")
        {
            if (isIncrease == true)
            {
                pikeStock += amount;
            }
            else
            {
                pikeStock -= amount;
            }
        }
        if (type == "Lance")
        {
            if (isIncrease == true)
            {
                lanceStock += amount;
            }
            else
            {
                lanceStock -= amount;
            }
        }
        if (type == "WoodenShield")
        {
            if (isIncrease == true)
            {
                woodenShieldStock += amount;
            }
            else
            {
                woodenShieldStock -= amount;
            }
        }
        if (type == "IronShield")
        {
            if (isIncrease == true)
            {
                ironShieldStock += amount;
            }
            else
            {
                ironShieldStock -= amount;
            }
        }
        if (type == "SteelShield")
        {
            if (isIncrease == true)
            {
                steelShieldStock += amount;
            }
            else
            {
                steelShieldStock -= amount;
            }
        }
        if (type == "LeatherHelm")
        {
            if (isIncrease == true)
            {
                leatherHelmStock += amount;
            }
            else
            {
                leatherHelmStock -= amount;
            }
        }
        if (type == "IronHelm")
        {
            if (isIncrease == true)
            {
                ironHelmStock += amount;
            }
            else
            {
                ironHelmStock -= amount;
            }
        }
        if (type == "SteelHelm")
        {
            if (isIncrease == true)
            {
                steelHelmStock += amount;
            }
            else
            {
                steelHelmStock -= amount;
            }
        }
        if (type == "LeatherArmor")
        {
            if (isIncrease == true)
            {
                leatherArmorStock += amount;
            }
            else
            {
                leatherArmorStock -= amount;
            }
        }
        if (type == "IronArmor")
        {
            if (isIncrease == true)
            {
                ironArmorStock += amount;
            }
            else
            {
                ironArmorStock -= amount;
            }
        }
        if (type == "SteelArmor")
        {
            if (isIncrease == true)
            {
                steelArmorStock += amount;
            }
            else
            {
                steelArmorStock -= amount;
            }
        }


    }

    void UpdateOrder(bool isIncrease, string workPlace, int amount, string orderType)
    {
        if(isIncrease == false)
        {
            if(workPlace == "BlackSmith")
            {
                if(blacksmithOrderAmount[0] - amount == 0)
                {
                    //Delete order.As we produced all of it.
                    blackSmithOrderType.RemoveAt(0);
                    blacksmithOrderAmount.RemoveAt(0);
                }
                else
                {
                    blacksmithOrderAmount[0] -= amount;
                }
            }
            if (workPlace == "Fletcher")
            {
                if (fletcherOrderAmount[0] - amount == 0)
                {
                    //Delete order.As we produced all of it.
                    fletcherOrderType.RemoveAt(0);
                    fletcherOrderAmount.RemoveAt(0);
                }
                else
                {
                    fletcherOrderAmount[0] -= amount;
                }
            }
            if (workPlace == "WeaponSmith")
            {
                if (weaponSmithOrderAmount[0] - amount == 0)
                {
                    //Delete order.As we produced all of it.
                    weaponSmithOrderType.RemoveAt(0);
                    weaponSmithOrderAmount.RemoveAt(0);
                }
                else
                {
                    weaponSmithOrderAmount[0] -= amount;
                }
            }
            if (workPlace == "ArmorSmith")
            {
                if (armorSmithOrderAmount[0] - amount == 0)
                {
                    //Delete order.As we produced all of it.
                    armorSmithOrderType.RemoveAt(0);
                    armorSmithOrderAmount.RemoveAt(0);
                }
                else
                {
                    armorSmithOrderAmount[0] -= amount;
                }
            }
            if (workPlace == "SiegeWorks")
            {
                if (blacksmithOrderAmount[0] - amount == 0)
                {
                    //Delete order.As we produced all of it.
                    siegeWorksOrderType.RemoveAt(0);
                    siegeWorksOrderAmount.RemoveAt(0);
                }
                else
                {
                    siegeWorksOrderAmount[0] -= amount;
                }
            }
        }
        else
        {
            if (workPlace == "BlackSmith")
            {
                blackSmithOrderType.Add(orderType);
                blacksmithOrderAmount.Add(amount);
            }
            if (workPlace == "Fletcher")
            {
                fletcherOrderType.Add(orderType);
                fletcherOrderAmount.Add(amount);
            }
            if (workPlace == "WeaponSmith")
            {
                weaponSmithOrderType.Add(orderType);
                weaponSmithOrderAmount.Add(amount);
            }
            if (workPlace == "ArmorSmith")
            {
                armorSmithOrderType.Add(orderType);
                armorSmithOrderAmount.Add(amount);
            }
            if (workPlace == "SiegeWorks")
            {
                siegeWorksOrderType.Add(orderType);
                siegeWorksOrderAmount.Add(amount);
            }
        }
    }

    int[] TrainAmountFromWeapons(List<string> equipmentList)
    {
        int numberFromWeapon = 0;
        int numberFromShield = 0;
        int numberFromHelm = 0;
        int numberFromArmor = 0;
        int numberFromHorse = 0;

        //First weapons.
        if (equipmentList[0] == "None")
        {
            numberFromWeapon = 100000;
        }
        if (equipmentList[0] == "Spear")
        {
            numberFromWeapon = spearStock;
        }
        if (equipmentList[0] == "Sword")
        {
            numberFromWeapon = swordStock;
        }
        if (equipmentList[0] == "Axe")
        {
            numberFromWeapon = axeStock;
        }
        if (equipmentList[0] == "Mace")
        {
            numberFromWeapon = maceStock;
        }
        if (equipmentList[0] == "Bow")
        {
            numberFromWeapon = bowStock;
        }
        if (equipmentList[0] == "Crossbow")
        {
            numberFromWeapon = crossbowStock;
        }
        if (equipmentList[0] == "Pike")
        {
            numberFromWeapon = pikeStock;
        }
        if (equipmentList[0] == "Lance")
        {
            numberFromWeapon = lanceStock;
        }

        //Now Shields.
        if (equipmentList[1] == "None")
        {
            numberFromShield = 100000;
        }
        if (equipmentList[1] == "WoodenShield")
        {
            numberFromShield = woodenShieldStock;
        }
        if (equipmentList[1] == "IronShield")
        {
            numberFromShield = ironShieldStock;
        }
        if (equipmentList[1] == "SteelShield")
        {
            numberFromShield = steelShieldStock;
        }

        //Now Helms.
        if (equipmentList[1] == "None")
        {
            numberFromHelm = 100000;
        }
        if (equipmentList[1] == "LeatherHelm")
        {
            numberFromShield = leatherHelmStock;
        }
        if (equipmentList[1] == "IronHelm")
        {
            numberFromShield = ironHelmStock;
        }
        if (equipmentList[1] == "SteelHelm")
        {
            numberFromShield = steelHelmStock;
        }

        //Now Armor.
        if (equipmentList[1] == "None")
        {
            numberFromArmor = 100000;
        }
        if (equipmentList[1] == "LeatherArmor")
        {
            numberFromArmor = leatherArmorStock;
        }
        if (equipmentList[1] == "IronArmor")
        {
            numberFromArmor = ironArmorStock;
        }
        if (equipmentList[1] == "SteelArmor")
        {
            numberFromArmor = steelArmorStock;
        }

        //Now Horse.
        if (equipmentList[1] == "None")
        {
            numberFromHorse = 100000;
        }
        if (equipmentList[1] == "Horse")
        {
            numberFromHorse = horseStock;
        }


        int[] array = new int[5];
        array[0] = numberFromWeapon;
        array[1] = numberFromShield;
        array[2] = numberFromHelm;
        array[3] = numberFromArmor;
        array[4] = numberFromHorse;

        return array;
    }

    void UpdateTrainingLists()
    {

    }

    IEnumerator UpdateTroopNumbers(TroopTypeScript troopType,float trainingTime, int amount)
    {
        yield return new WaitForSeconds(trainingTime);

        troopNumbers[troopTypes.IndexOf(troopType)] += amount;
    }

    public int[] BuildingCostDecider(string buildingType)
    {
        int woodCost = 0;
        int stoneCost = 0;
        float woodMultiplier;
        float stoneMultiplier;

        if (buildingType == "Farm")
        {
            woodMultiplier = 0.1f + farmLevel/10;
            stoneMultiplier = 0.05f + farmLevel/10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(farmLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(farmLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "Pasture")
        {
            woodMultiplier = 0.2f + pastureLevel / 10;
            stoneMultiplier = 0.05f + pastureLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(pastureLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(pastureLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "Vineyard")
        {
            woodMultiplier = 0.25f + vineyardLevel / 10;
            stoneMultiplier = 0.1f + vineyardLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(vineyardLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(vineyardLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "Lumberyard")
        {
            woodMultiplier = 0.25f + lumberyardLevel / 10;
            stoneMultiplier = 0.2f + lumberyardLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(lumberyardLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(lumberyardLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "Quarry")
        {
            woodMultiplier = 0.35f + quarryLevel / 10;
            stoneMultiplier = 0.4f + quarryLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(quarryLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(quarryLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "Mine")
        {
            woodMultiplier = 0.5f + mineLevel / 10;
            stoneMultiplier = 0.5f + mineLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(mineLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(mineLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "Tailor")
        {
            woodMultiplier = 0.2f + tailorLevel / 10;
            stoneMultiplier = 0.4f + tailorLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(tailorLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(tailorLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "MetalWorks")
        {
            woodMultiplier = 0.5f + metalWorksLevel / 10;
            stoneMultiplier = 0.6f + metalWorksLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(metalWorksLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(metalWorksLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "Jewelry")
        {
            woodMultiplier = 0.3f + jewelryLevel / 10;
            stoneMultiplier = 0.8f + jewelryLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(jewelryLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(jewelryLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "BlackSmith")
        {
            woodMultiplier = 0.4f + blackSmithLevel / 10;
            stoneMultiplier = 0.5f + blackSmithLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(blackSmithLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(blackSmithLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "Fletcher")
        {
            woodMultiplier = 0.5f + fletcherLevel / 10;
            stoneMultiplier = 0.4f + fletcherLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(fletcherLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(fletcherLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "WeaponSmith")
        {
            woodMultiplier = 0.65f + weaponSmithLevel / 10;
            stoneMultiplier = 0.75f + weaponSmithLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(weaponSmithLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(weaponSmithLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "ArmorSmith")
        {
            woodMultiplier = 0.65f + armorSmithLevel / 10;
            stoneMultiplier = 0.75f + armorSmithLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(armorSmithLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(armorSmithLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        if (buildingType == "SiegeWorks")
        {
            woodMultiplier = 0.75f + siegeWorksLevel / 10;
            stoneMultiplier = 0.85f + siegeWorksLevel / 10;
            woodCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(siegeWorksLevel + 2, 2)) * 1000 * woodMultiplier);
            stoneCost = Mathf.FloorToInt(Mathf.Log(Mathf.Pow(siegeWorksLevel + 2, 2)) * 1000 * stoneMultiplier);
        }
        

        int[] returnArray = new int[2];
        returnArray[0] = woodCost;
        returnArray[1] = stoneCost;
        
        return returnArray;
    }
}
