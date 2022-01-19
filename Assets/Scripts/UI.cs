using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;

public class UI : NetworkBehaviour
{
    public GameObject theServer;

    
    public Kingdom myKingdom;

    public bool isUIOpen = true;

    public Region selectedRegion;
    public TradeNodeScript selectedTradeNode;
    public Army selectedArmy;

    public GameObject loginScreen;
    public GameObject regionViewerOwn;
    public GameObject regionViewerOther;
    public GameObject tradeNodeViewer;
    public GameObject armyViewerOwn;
    public GameObject armyViewerOther;
    public GameObject kingdomViewerOwn;
    public GameObject kingdomViewerOther;

    public GameObject currentActiveUI;

    

    //Login Register Section
    public Text usernameText;
    public Text passwordText;
    public Button loginButton;
    public Button registerButton;
    public Text loginInfoText;

    public Button exitButton;

    //Production Section.

    Dropdown sectorDropdown;

    Text sectorName;
    Text productionAmount;
    Text workerAmount;
    Slider workerSlider;
    public string workerSliderSectorType;

    //Building Section.

    Dropdown economyDropdown;
    Dropdown militaryDropdown;
    Dropdown civilianDropdown;
    int currentDropdownValue;

    
    Text buildingName;
    Text buildingCost;
    Text buildingTime;
    Text buildingDescription;
    Button buildButton;
    public string buildButtonBuildingType;



    void Start()
    {
        //Find Server
        theServer = GameObject.Find("TheServer");
        
        AssignUIElements();
        SetUIElementInteraction();

        InvokeRepeating("RepeatingUIUpdate", 0f, 2f);


    }

    void RepeatingUIUpdate()
    {
        UpdateProductionSlot();

        
    }

    //Assign UI Elements.

    void AssignUIElements()
    {

        //Viewers.
        loginScreen = GameObject.Find("Login");
        regionViewerOwn = GameObject.Find("RegionViewerOwn");
        regionViewerOther = GameObject.Find("RegionViewerOther");
        tradeNodeViewer = GameObject.Find("TradeNodeViewer");
        armyViewerOwn = GameObject.Find("ArmyViewerOwn");
        armyViewerOther = GameObject.Find("ArmyViewerOther");
        kingdomViewerOwn = GameObject.Find("KingdomViewerOwn");
        kingdomViewerOther = GameObject.Find("KingdomViewerOther");

        //Generic
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(delegate { CloseUI(); });

        //Login Register
        usernameText = GameObject.Find("Username").GetComponent<Text>();
        passwordText = GameObject.Find("Password").GetComponent<Text>();
        loginButton = GameObject.Find("LoginButton").GetComponent<Button>();
        registerButton = GameObject.Find("RegisterButton").GetComponent<Button>();
        loginInfoText = GameObject.Find("LoginInfoText").GetComponent<Text>();

        loginButton.onClick.RemoveAllListeners();
        loginButton.onClick.AddListener(delegate { CmdProcessLogin(usernameText.text, passwordText.text, netId); });
        registerButton.onClick.RemoveAllListeners();
        registerButton.onClick.AddListener(delegate { CmdProcessRegister(usernameText.text, passwordText.text); });


        //Production Section.
        sectorDropdown = GameObject.Find("SectorDropdown").GetComponent<Dropdown>();
        sectorDropdown.onValueChanged.RemoveAllListeners();
        sectorDropdown.onValueChanged.AddListener(delegate { UpdateProductionSlot(); });

        sectorName = GameObject.Find("SectorName").GetComponent<Text>();
        productionAmount = GameObject.Find("ProductionAmount").GetComponent<Text>();
        workerAmount = GameObject.Find("WorkerAmount").GetComponent<Text>();

        workerSlider = GameObject.Find("WorkerSlider").GetComponent<Slider>();
        workerSlider.onValueChanged.RemoveAllListeners();
        workerSlider.onValueChanged.AddListener(delegate { WorkerSlider(); });

        //Building Section.
        economyDropdown = GameObject.Find("EconomyDropdown").GetComponent<Dropdown>();
        economyDropdown.onValueChanged.RemoveAllListeners();
        economyDropdown.onValueChanged.AddListener(delegate { UpdateEconomyBuildingSlot(); });

        militaryDropdown = GameObject.Find("MilitaryDropdown").GetComponent<Dropdown>();
        militaryDropdown.onValueChanged.AddListener(delegate { UpdateMilitaryBuildingSlot(); });

        civilianDropdown = GameObject.Find("CivilianDropdown").GetComponent<Dropdown>();
        civilianDropdown.onValueChanged.AddListener(delegate { UpdateCivilianBuildingSlot(); });

        buildingName = GameObject.Find("BuildingName").GetComponent<Text>();
        buildingCost = GameObject.Find("BuildingCost").GetComponent<Text>();
        buildingTime = GameObject.Find("BuildingTime").GetComponent<Text>();
        buildingDescription = GameObject.Find("BuildingDescription").GetComponent<Text>();

        buildButton = GameObject.Find("BuildButton").GetComponent<Button>();
        buildButton.onClick.RemoveAllListeners();
        buildButton.onClick.AddListener(delegate { Construction(); });

    }

    //Set UI Elements' Interactions

    void SetUIElementInteraction()
    {
        loginScreen.GetComponent<CanvasGroup>().alpha = 1;
        loginScreen.GetComponent<CanvasGroup>().interactable = true;
        loginScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;

        regionViewerOwn.GetComponent<CanvasGroup>().alpha = 0;
        regionViewerOwn.GetComponent<CanvasGroup>().interactable = false;
        regionViewerOwn.GetComponent<CanvasGroup>().blocksRaycasts = false;

        regionViewerOther.GetComponent<CanvasGroup>().alpha = 0;
        regionViewerOther.GetComponent<CanvasGroup>().interactable = false;
        regionViewerOther.GetComponent<CanvasGroup>().blocksRaycasts = false;

        tradeNodeViewer.GetComponent<CanvasGroup>().alpha = 0;
        tradeNodeViewer.GetComponent<CanvasGroup>().interactable = false;
        tradeNodeViewer.GetComponent<CanvasGroup>().blocksRaycasts = false;

        armyViewerOwn.GetComponent<CanvasGroup>().alpha = 0;
        armyViewerOwn.GetComponent<CanvasGroup>().interactable = false;
        armyViewerOwn.GetComponent<CanvasGroup>().blocksRaycasts = false;

        armyViewerOther.GetComponent<CanvasGroup>().alpha = 0;
        armyViewerOther.GetComponent<CanvasGroup>().interactable = false;
        armyViewerOther.GetComponent<CanvasGroup>().blocksRaycasts = false;

        kingdomViewerOwn.GetComponent<CanvasGroup>().alpha = 0;
        kingdomViewerOwn.GetComponent<CanvasGroup>().interactable = false;
        kingdomViewerOwn.GetComponent<CanvasGroup>().blocksRaycasts = false;

        kingdomViewerOther.GetComponent<CanvasGroup>().alpha = 0;
        kingdomViewerOther.GetComponent<CanvasGroup>().interactable = false;
        kingdomViewerOther.GetComponent<CanvasGroup>().blocksRaycasts = false;
              
    }

    //**********Production View.

    void UpdateProductionSlot()
    {
        int slot = sectorDropdown.value;

        if (slot == 0)
        {
            sectorName.text = "Food " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "Farm";
            workerSlider.value = selectedRegion.farmWorkers;
            workerSlider.maxValue = selectedRegion.farmLevel * 100;
        }
        if (slot == 1)
        {
            sectorName.text = "Wine " + "(" + selectedRegion.wineFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.wineProduction.ToString() + "(" + selectedRegion.wineUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.vineyardWorkers.ToString() + "/" + selectedRegion.vineyardMaxWorkers.ToString();
            workerSliderSectorType = "Vineyard";
        }
        if (slot == 2)
        {
            sectorName.text = "Wool " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "PastureWool";
        }
        if (slot == 3)
        {
            sectorName.text = "Horse " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "PastureHorse";
        }
        if (slot == 4)
        {
            sectorName.text = "Leather " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "PastureLeather";
        }
        if (slot == 5)
        {
            sectorName.text = "Wood " + "(" + selectedRegion.woodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.woodProduction.ToString() + "(" + selectedRegion.woodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.lumberyardWorkers.ToString() + "/" + selectedRegion.lumberyardMaxWorkers.ToString();
            workerSliderSectorType = "Lumberyard";
        }
        if (slot == 6)
        {
            sectorName.text = "Stone " + "(" + selectedRegion.stoneFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.stoneProduction.ToString() + "(" + selectedRegion.stoneUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.quarryWorkers.ToString() + "/" + selectedRegion.quarryMaxWorkers.ToString();
            workerSliderSectorType = "Quarry";
        }
        if (slot == 7)
        {
            sectorName.text = "Cloth " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "Tailor";
        }
        if (slot == 8)
        {
            sectorName.text = "Iron Ore " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "MineIronOre";
        }
        if (slot == 9)
        {
            sectorName.text = "Silver Ore " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "MineSilverOre";
        }
        if (slot == 10)
        {
            sectorName.text = "Gold Ore " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "MineGoldOre";
        }
        if (slot == 11)
        {
            sectorName.text = "Iron Bar " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "MetalWorksIronBar";
        }
        if (slot == 12)
        {
            sectorName.text = "Steel " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "MetalWorksSteel";
        }
        if (slot == 13)
        {
            sectorName.text = "Silverware " + "(" + selectedRegion.foodFertility.ToString() + ")";
            productionAmount.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
            workerAmount.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
            workerSliderSectorType = "Jewelry";
        }
    }

    //Slider.

    //Preparation.  
    
    [Client]
    void WorkerSlider()
    {
        float amount = workerSlider.value;
        NetworkInstanceId id = selectedRegion.netId;        
        string sliderType = workerSliderSectorType;

        CmdWorkerSlider(amount,id,sliderType);
        
    }
    
    [Command]
    void CmdWorkerSlider(float workers, NetworkInstanceId regionID, string sliderType)
    {

        Region region = NetworkServer.FindLocalObject(regionID).GetComponent<Region>();
        
        if(sliderType == "Farm")
        {
            region.farmWorkers = Mathf.FloorToInt(workers);            
        }
        if (sliderType == "Vineyard")
        {
            region.vineyardWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "PastureWool")
        {
            region.pastureWoolWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "Lumberyard")
        {
            region.lumberyardWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "Quarry")
        {
            region.quarryWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "MineIronOre")
        {
            region.mineIronOreWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "MineSilverOre")
        {
            region.mineSilverOreWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "MineGoldOre")
        {
            region.mineGoldOreWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "PastureLeather")
        {
            region.pastureLeatherWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "Tailor")
        {
            region.tailorWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "MetalWorksIronBar")
        {
            region.metalWorksIronBarWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "MetalWorksSteel")
        {
            region.metalWorksSteelWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "Jewelry")
        {
            region.jewelryWorkers = Mathf.FloorToInt(workers);
        }
        if (sliderType == "PastureHorse")
        {
            region.pastureHorseWorkers = Mathf.FloorToInt(workers);
        }
    }
       

    //**********Building View.    

    void UpdateEconomyBuildingSlot()
    {
        int slot = economyDropdown.value;

        if(slot == 0)
        {
            buildingName.text = "Farm " + "(" + selectedRegion.farmLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is farm.Adds 100 farmers.";
            buildButtonBuildingType = "farm";            
        }
        if (slot == 1)
        {
            buildingName.text = "Pasture " + "(" + selectedRegion.pastureLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Pasture").ToString() + " Stone: " + BSCF("Pasture").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Pasture.Adds 100 farmers.";
            buildButtonBuildingType = "pasture";
        }
        if (slot == 2)
        {
            buildingName.text = "Vineyard " + "(" + selectedRegion.vineyardLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Vineyard").ToString() + " Stone: " + BSCF("Vineyard").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Vineyard.Adds 100 farmers.";
            buildButtonBuildingType = "vineyard";
        }
        if (slot == 3)
        {
            buildingName.text = "Lumberyard " + "(" + selectedRegion.lumberyardLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Lumberyard").ToString() + " Stone: " + BSCF("Lumberyard").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Lumberyard.Adds 100 farmers.";
            buildButtonBuildingType = "lumberyard";
        }
        if (slot == 4)
        {
            buildingName.text = "Quarry " + "(" + selectedRegion.quarryLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Quarry").ToString() + " Stone: " + BSCF("Quarry").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Quarry.Adds 100 farmers.";
            buildButtonBuildingType = "quarry";
        }
        if (slot == 5)
        {
            buildingName.text = "Mine " + "(" + selectedRegion.mineLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Mine").ToString() + " Stone: " + BSCF("Mine").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Mine.Adds 100 farmers.";
            buildButtonBuildingType = "mine";
        }
        if (slot == 6)
        {
            buildingName.text = "Tailor " + "(" + selectedRegion.tailorLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Tailor").ToString() + " Stone: " + BSCF("Tailor").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Tailor.Adds 100 farmers.";
            buildButtonBuildingType = "tailor";
        }
        if (slot == 7)
        {
            buildingName.text = "Metal Works " + "(" + selectedRegion.metalWorksLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("MetalWorks").ToString() + " Stone: " + BSCF("MetalWorks").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Metal Works.Adds 100 farmers.";
            buildButtonBuildingType = "metal works";
        }
        if (slot == 8)
        {
            buildingName.text = "Jewelry " + "(" + selectedRegion.jewelryLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Jewelry").ToString() + " Stone: " + BSCF("Jewelry").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Jewelry.Adds 100 farmers.";
            buildButtonBuildingType = "jewelry";
        }
                
    }

    void UpdateMilitaryBuildingSlot()
    {
        int slot = militaryDropdown.value;

        if (slot == 0)
        {
            buildingName.text = "Blacksmith " + "(" + selectedRegion.blackSmithLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("BlackSmith").ToString() + " Stone: " + BSCF("BlackSmith").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Blacksmith.Adds 100 farmers.";
            buildButtonBuildingType = "blacksmith";
        }
        if (slot == 1)
        {
            buildingName.text = "Fletcher " + "(" + selectedRegion.fletcherLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("Fletcher").ToString() + " Stone: " + BSCF("Fletcher").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Fletcher.Adds 100 farmers.";
            buildButtonBuildingType = "fletcher";
        }
        if (slot == 2)
        {
            buildingName.text = "Weaponsmith " + "(" + selectedRegion.weaponSmithLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("WeaponSmith").ToString() + " Stone: " + BSCF("WeaponSmith").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Weaponsmith.Adds 100 farmers.";
            buildButtonBuildingType = "weaponSmith";
        }
        if (slot == 3)
        {
            buildingName.text = "Armorsmith " + "(" + selectedRegion.armorSmithLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("ArmorSmith").ToString() + " Stone: " + BSCF("ArmorSmith").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Armorsmith.Adds 100 farmers.";
            buildButtonBuildingType = "armorSmith";
        }
        if (slot == 4)
        {
            buildingName.text = "Siege Works " + "(" + selectedRegion.siegeWorksLevel.ToString() + ")";
            buildingCost.text = "Wood: " + BWCF("SiegeWorks").ToString() + " Stone: " + BSCF("SiegeWorks").ToString() + "\n" + "x" + "gold";
            buildingTime.text = 1.ToString();
            buildingDescription.text = "This is Siege Works.Adds 100 farmers.";
            buildButtonBuildingType = "siegeWorks";
        }
    }

    void UpdateCivilianBuildingSlot()
    {
        int slot = civilianDropdown.value;
    }

    [Client]
    void Construction()
    {
        
        NetworkInstanceId id = selectedRegion.netId;
        string type = buildButtonBuildingType;

        CmdAddToConstructionList(id, type);
    }

    //This should be a command.
    [Command]
    public void CmdAddToConstructionList(NetworkInstanceId id,string buildingType)
    {
        Region region = NetworkServer.FindLocalObject(id).GetComponent<Region>();

        region.AddToConstructionList(buildingType);
        Debug.Log("Server added " + buildingType + " to construction list.");
    }


    
    

    //Building Wood Cost Finder
    int BWCF(string buildingType)
    {
        int[] array = selectedRegion.BuildingCostDecider(buildingType);
        return array[0];
    }
    //Building Stone Cost Finder
    int BSCF(string buildingType)
    {
        int[] array = selectedRegion.BuildingCostDecider(buildingType);
        return array[1];
    }

    //*******Login - Register Section (All Commands)

    //Client Side
    
    [Command]
    void CmdProcessLogin(string username, string password, NetworkInstanceId playerID)
    {
        NetworkServer.SpawnObjects();
        
        Database database = GameObject.Find("Database").GetComponent<Database>();

        //If username exist.
        if (database.usernames.Contains(username))
        {            
            //Find Username.
            int index = database.usernames.IndexOf(username);
            
            //Validate password.
            if (database.passwords[index] == password)
            {

                //Find and pair Kingdom.                
                NetworkServer.FindLocalObject(playerID).GetComponent<UI>().myKingdom = database.kingdoms[index];
                database.kingdoms[index].myPlayerController = NetworkServer.FindLocalObject(playerID);



                RpcLoginSuccess(NetworkServer.FindLocalObject(playerID).GetComponent<UI>().myKingdom.gameObject);
                

            }
            else
            {
                RpcWrongPassword();
            }
        }
        else
        {
            RpcWrongUser();
        }

    }

    [Command]
    void CmdProcessRegister(string username, string password)
    {
        Database database = GameObject.Find("Database").GetComponent<Database>();

        //Find if username does not exist.
        if (database.usernames.Contains(username) == false)
        {
            //Create account.
            database.usernames.Add(username);
            database.passwords.Insert(database.usernames.IndexOf(username), password);

            //Spawn Kingdom and Add ID.
            GameObject go = Instantiate(theServer.GetComponent<Server>().kingdomPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            Kingdom spawnedKingdom = go.GetComponent<Kingdom>();
            database.kingdoms.Insert(database.usernames.IndexOf(username), spawnedKingdom);

            spawnedKingdom.myID = (database.kingdoms.Count);

            spawnedKingdom.transform.name = "Kingdom" + spawnedKingdom.myID.ToString();

            NetworkServer.Spawn(go);

            //Settle this new kingdom.

            //Find a good position.(FIX!)

            int settlePosX = 0;
            int settlePosY = 0;

            //

            GameObject settledTileObject = theServer.GetComponent<Map>().regions[settlePosX, settlePosY];

            settledTileObject.GetComponent<Region>().myKingdom = spawnedKingdom;
            settledTileObject.GetComponent<Region>().isSettled = true;
            settledTileObject.GetComponent<Region>().population = 100;
            settledTileObject.GetComponent<Region>().farmLevel = 1;      

        }
    }

    //Server Side

    [ClientRpc]
    void RpcLoginSuccess(GameObject myKingdomObject)
    {
        if (isLocalPlayer && !isServer)
        {
            loginInfoText.text = "Login Success!";
            myKingdom = myKingdomObject.GetComponent<Kingdom>();

            //Close Login UI And Move Player Camera To See Map.
            loginScreen.GetComponent<CanvasGroup>().alpha = 0;
            loginScreen.GetComponent<CanvasGroup>().interactable = false;
            loginScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
            isUIOpen = false;

            //Move Camera (FIX)
        }

    }

    [ClientRpc]
    void RpcRegisterSuccess()
    {
        loginInfoText.text = "Register success.Please login.";
    }

    [ClientRpc]
    void RpcWrongPassword()
    {
        loginInfoText.text = "Wrong password.";
    }

    [ClientRpc]
    void RpcWrongUser()
    {
        loginInfoText.text = "User not exist.";
    }

    //UI Methodes.

    public void CloseUI()
    {        
        StartCoroutine("CloseUICoro");
    }

    IEnumerator CloseUICoro()
    {
        yield return new WaitForSeconds(0.1f);
        currentActiveUI.GetComponent<CanvasGroup>().alpha = 0;
        currentActiveUI.GetComponent<CanvasGroup>().interactable = false;
        currentActiveUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        isUIOpen = false;
    }

    public void OpenUI(string type)
    {
        GameObject uiType = null;
        //Check if region.
        if(type == "region")
        {
            if(selectedRegion.myKingdom == myKingdom)
            {
                uiType = regionViewerOwn;
            }
            if(selectedRegion.myKingdom != myKingdom)
            {
                uiType = regionViewerOther;
            }

        }

        //Check if trade node.
        if(type == "tradeNode")
        {
            uiType = tradeNodeViewer;
        }

        //Check if army.
        if(type == "army")
        {
            if(selectedArmy.myKingdom == myKingdom)
            {
                uiType = armyViewerOwn;
            }
            if(selectedArmy.myKingdom != myKingdom)
            {
                uiType = armyViewerOther;
            }
        }

        uiType.GetComponent<CanvasGroup>().alpha = 1;
        uiType.GetComponent<CanvasGroup>().interactable = true;
        uiType.GetComponent<CanvasGroup>().blocksRaycasts = true;
        isUIOpen = true;
        currentActiveUI = uiType;

        // StartCoroutine(OpenUICoro(uiType));
    }

   /* IEnumerator OpenUICoro(GameObject uiType)
    {        
            yield return new WaitForSeconds(0.1f);
            uiType.GetComponent<CanvasGroup>().alpha = 1;
            uiType.GetComponent<CanvasGroup>().interactable = true;
            uiType.GetComponent<CanvasGroup>().blocksRaycasts = true;
            isUIOpen = true;
            currentActiveUI = uiType;             
    }
    */


}
