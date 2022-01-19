using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UIOld : NetworkBehaviour {

    //public Kingdom myKingdom;


    //public Text foodProductionText;
    //public Text foodWorkersText;
    //public Text foodNameText;
    //public Text wineProductionText;
    //public Text wineWorkersText;
    //public Text wineNameText;
    //public Text woolProductionText;
    //public Text woolWorkersText;    
    //public Text woodProductionText;
    //public Text woodWorkersText;
    //public Text woodNameText;
    //public Text stoneProductionText;
    //public Text stoneWorkersText;
    //public Text stoneNameText;
    //public Text ironOreProductionText;
    //public Text ironOreWorkersText;
    //public Text ironOreNameText;
    //public Text silverOreProductionText;
    //public Text silverOreWorkersText;
    //public Text silverOreNameText;
    //public Text goldOreProductionText;
    //public Text goldOreWorkersText;
    //public Text goldOreNameText;
    //public Text leatherProductionText;
    //public Text leatherWorkersText;
    //public Text clothProductionText;
    //public Text clothWorkersText;
    //public Text ironBarProductionText;
    //public Text ironBarWorkersText;
    //public Text steelProductionText;
    //public Text steelWorkersText;
    //public Text silverWareProductionText;
    //public Text silverWareWorkersText;
    //public Text horseProductionText;
    //public Text horseWorkersText;

    //public Text farmName;
    //public Text vineyardName;
    //public Text pastureName;
    //public Text lumberyardName;
    //public Text quarryName;
    //public Text mineName;
    //public Text tailorName;
    //public Text metalWorksName;
    //public Text jewelryName;
    //public Text blackSmithName;
    //public Text fletcherName;
    //public Text weaponSmithName;
    //public Text armorSmithName;
    //public Text siegeWorksName;

    //public Text farmCost;
    //public Text vineyardCost;
    //public Text pastureCost;
    //public Text lumberyardCost;
    //public Text quarryCost;
    //public Text mineCost;
    //public Text tailorCost;
    //public Text metalWorksCost;
    //public Text jewelryCost;
    //public Text blackSmithCost;
    //public Text fletcherCost;
    //public Text weaponSmithCost;
    //public Text armorSmithCost;
    //public Text siegeWorksCost;

    //public Text farmConstructionTime;
    //public Text vineyardConstructionTime;
    //public Text pastureConstructionTime;
    //public Text lumberyardConstructionTime;
    //public Text quarryConstructionTime;
    //public Text mineConstructionTime;
    //public Text tailorConstructionTime;
    //public Text metalWorksConstructionTime;
    //public Text jewelryConstructionTime;
    //public Text blackSmithConstructionTime;
    //public Text fletcherConstructionTime;
    //public Text weaponSmithConstructionTime;
    //public Text armorSmithConstructionTime;
    //public Text siegeWorksConstructionTime;

    //public Text farmDescription;
    //public Text vineyardDescription;
    //public Text pastureDescription;
    //public Text lumberyardDescription;
    //public Text quarryDescription;
    //public Text mineDescription;
    //public Text tailorDescription;
    //public Text metalWorksDescription;
    //public Text jewelryDescription;
    //public Text blackSmithDescription;
    //public Text fletcherDescription;
    //public Text weaponSmithDescription;
    //public Text armorSmithDescription;
    //public Text siegeWorksDescription;

    //public Slider farmProgressBar;
    //public Slider vineyardProgressBar;
    //public Slider pastureProgressBar;
    //public Slider lumberyardProgressBar;
    //public Slider quarryProgressBar;
    //public Slider mineProgressBar;
    //public Slider tailorProgressBar;
    //public Slider metalWorksProgressBar;
    //public Slider jewelryProgressBar;
    //public Slider blackSmithProgressBar;
    //public Slider fletcherProgressBar;
    //public Slider weaponSmithProgressBar;
    //public Slider armorSmithProgressBar;
    //public Slider siegeWorksProgressBar;
    
    //public Slider foodSlider;
    //public Slider wineSlider;
    //public Slider woolSlider;
    //public Slider woodSlider;
    //public Slider stoneSlider;
    //public Slider ironOreSlider;
    //public Slider silverOreSlider;
    //public Slider goldOreSlider;
    //public Slider leatherSlider;
    //public Slider clothSlider;
    //public Slider ironBarSlider;
    //public Slider steelSlider;    
    //public Slider silverWareSlider;
    //public Slider horseSlider;

    //public Button farmButton;
    //public Button vineyardButton;
    //public Button pastureButton;
    //public Button lumberyardButton;
    //public Button quarryButton;
    //public Button mineButton;
    //public Button tailorButton;
    //public Button metalWorksButton;
    //public Button jewelryButton;
    //public Button blackSmithButton;
    //public Button fletcherButton;
    //public Button weaponSmithButton;
    //public Button armorSmithButton;
    //public Button siegeWorksButton;







    //void Start()
    //{
    //    InvokeRepeating("UpdateGUI", 1f, 1f);
    //}

    //public bool isUIOpen = false;

    //public Region selectedRegion;

    //public Canvas regionViewerOwn;
    //public Canvas regionViewerOther;
    //public Canvas tradeNodeViewer;


    
    


    
    //void UpdateGUI()
    //{

    //    RegionViewerOwnUpdater();
        

    //}

    ////Find UI Elements.



    ////*****Update Texts on UI.

    //void RegionViewerOwnUpdater()
    //{
    //    if(selectedRegion != null)
    //    {
    //        //Overview Sub-Tab.

    //        //********************Production Sub-Tab.
    //        //Edit names of some to show fertility.
    //        foodNameText.text = "Food " + "(" + selectedRegion.foodFertility.ToString() + ")";
    //        wineNameText.text = "Wine " + "(" + selectedRegion.wineFertility.ToString() + ")";
    //        woodNameText.text = "Wood " + "(" + selectedRegion.woodFertility.ToString() + ")";
    //        stoneNameText.text = "Stone " + "(" + selectedRegion.stoneFertility.ToString() + ")";
    //        ironOreNameText.text = "Iron Ore " + "(" + selectedRegion.ironOreFertility.ToString() + ")";
    //        silverOreNameText.text = "Silver Ore " + "(" + selectedRegion.silverOreFertility.ToString() + ")";
    //        goldOreNameText.text = "Gold Ore " + "(" + selectedRegion.goldOreFertility.ToString() + ")";

    //        foodProductionText.text = "Production: " + selectedRegion.foodProduction.ToString() + "(" + selectedRegion.foodUsage.ToString() + ")";
    //        wineProductionText.text = "Production: " + selectedRegion.wineProduction.ToString() + "(" + selectedRegion.wineUsage.ToString() + ")";
    //        woolProductionText.text = "Production: " + selectedRegion.woolProduction.ToString() + "(" + selectedRegion.woolUsage.ToString() + ")";
    //        woodProductionText.text = "Production: " + selectedRegion.woodProduction.ToString() + "(" + selectedRegion.woodUsage.ToString() + ")";
    //        stoneProductionText.text = "Production: " + selectedRegion.stoneProduction.ToString() + "(" + selectedRegion.stoneUsage.ToString() + ")";
    //        ironOreProductionText.text = "Production: " + selectedRegion.ironOreProduction.ToString() + "(" + selectedRegion.ironOreUsage.ToString() + ")";
    //        silverOreProductionText.text = "Production: " + selectedRegion.silverOreProduction.ToString() + "(" + selectedRegion.silverOreUsage.ToString() + ")";
    //        goldOreProductionText.text = "Production: " + selectedRegion.goldOreProduction.ToString() + "(" + selectedRegion.goldOreUsage.ToString() + ")";
    //        leatherProductionText.text = "Production: " + selectedRegion.leatherProduction.ToString() + "(" + selectedRegion.leatherUsage.ToString() + ")";
    //        clothProductionText.text = "Production: " + selectedRegion.clothProduction.ToString() + "(" + selectedRegion.clothUsage.ToString() + ")";
    //        ironBarProductionText.text = "Production: " + selectedRegion.ironBarProduction.ToString() + "(" + selectedRegion.ironBarUsage.ToString() + ")";
    //        steelProductionText.text = "Production: " + selectedRegion.steelProduction.ToString() + "(" + selectedRegion.steelUsage.ToString() + ")";            
    //        silverWareProductionText.text = "Production: " + selectedRegion.silverWareProduction.ToString() + "(" + selectedRegion.silverWareUsage.ToString() + ")";            
    //        horseProductionText.text = "Production: " + selectedRegion.horseProduction.ToString() + "(" + selectedRegion.horseUsage.ToString() + ")";
            

    //        //Workers and Capacities.
    //        foodWorkersText.text = "Workers: " + selectedRegion.farmWorkers.ToString() + "/" + selectedRegion.farmMaxWorkers.ToString();
    //        wineWorkersText.text = "Workers: " + selectedRegion.vineyardWorkers.ToString() + "/" + selectedRegion.vineyardMaxWorkers.ToString();
    //        woolWorkersText.text = "Workers: " + selectedRegion.pastureWoolWorkers.ToString() + "/" + selectedRegion.pastureWoolMaxWorkers.ToString();
    //        woodWorkersText.text = "Workers: " + selectedRegion.lumberyardWorkers.ToString() + "/" + selectedRegion.lumberyardMaxWorkers.ToString();
    //        stoneWorkersText.text = "Workers: " + selectedRegion.quarryWorkers.ToString() + "/" + selectedRegion.quarryMaxWorkers.ToString();
    //        ironOreWorkersText.text = "Workers: " + selectedRegion.mineIronOreWorkers.ToString() + "/" + selectedRegion.mineIronOreMaxWorkers.ToString();
    //        silverOreWorkersText.text = "Workers: " + selectedRegion.mineSilverOreWorkers.ToString() + "/" + selectedRegion.mineSilverOreMaxWorkers.ToString();
    //        goldOreWorkersText.text = "Workers: " + selectedRegion.mineGoldOreWorkers.ToString() + "/" + selectedRegion.mineGoldOreMaxWorkers.ToString();
    //        leatherWorkersText.text = "Workers: " + selectedRegion.pastureLeatherWorkers.ToString() + "/" + selectedRegion.pastureLeatherMaxWorkers.ToString();
    //        clothWorkersText.text = "Workers: " + selectedRegion.tailorWorkers.ToString() + "/" + selectedRegion.tailorMaxWorkers.ToString();
    //        ironBarWorkersText.text = "Workers: " + selectedRegion.metalWorksIronBarWorkers.ToString() + "/" + selectedRegion.metalWorksIronBarMaxWorkers.ToString();
    //        steelWorkersText.text = "Workers: " + selectedRegion.metalWorksSteelWorkers.ToString() + "/" + selectedRegion.metalWorksSteelMaxWorkers.ToString();
    //        silverWareWorkersText.text = "Workers: " + selectedRegion.jewelryWorkers.ToString() + "/" + selectedRegion.jewelryMaxWorkers.ToString();
    //        horseWorkersText.text = "Workers: " + selectedRegion.pastureHorseWorkers.ToString() + "/" + selectedRegion.pastureHorseMaxWorkers.ToString();

    //        //Slider Max Values.

    //        foodSlider.maxValue = selectedRegion.farmMaxWorkers;
    //        wineSlider.maxValue = selectedRegion.vineyardWorkers;
    //        woolSlider.maxValue = selectedRegion.pastureWoolWorkers;
    //        woodSlider.maxValue = selectedRegion.lumberyardWorkers;
    //        stoneSlider.maxValue = selectedRegion.quarryWorkers;
    //        ironOreSlider.maxValue = selectedRegion.mineIronOreWorkers;
    //        silverOreSlider.maxValue = selectedRegion.mineSilverOreWorkers;
    //        goldOreSlider.maxValue = selectedRegion.mineGoldOreWorkers;
    //        leatherSlider.maxValue = selectedRegion.pastureLeatherWorkers;
    //        clothSlider.maxValue = selectedRegion.tailorWorkers;
    //        ironBarSlider.maxValue = selectedRegion.metalWorksIronBarWorkers;
    //        steelSlider.maxValue = selectedRegion.metalWorksSteelWorkers;
    //        silverWareSlider.maxValue = selectedRegion.jewelryWorkers;
    //        horseSlider.maxValue = selectedRegion.pastureHorseWorkers;

    //        //****************Building Sub-Tab.

    //        //Economic Section.
    //        //Name (Level).
    //        farmName.text = "Farm " + "(" + selectedRegion.farmLevel.ToString() + ")";
    //        pastureName.text = "Farm " + "(" + selectedRegion.pastureLevel.ToString() + ")";
    //        vineyardName.text = "Farm " + "(" + selectedRegion.vineyardLevel.ToString() + ")";            
    //        lumberyardName.text = "Farm " + "(" + selectedRegion.lumberyardLevel.ToString() + ")";
    //        quarryName.text = "Farm " + "(" + selectedRegion.quarryLevel.ToString() + ")";
    //        mineName.text = "Farm " + "(" + selectedRegion.mineLevel.ToString() + ")";
    //        tailorName.text = "Farm " + "(" + selectedRegion.tailorLevel.ToString() + ")";
    //        metalWorksName.text = "Farm " + "(" + selectedRegion.metalWorksLevel.ToString() + ")";
    //        jewelryName.text = "Farm " + "(" + selectedRegion.jewelryLevel.ToString() + ")";
    //        blackSmithName.text = "Farm " + "(" + selectedRegion.blackSmithLevel.ToString() + ")";
    //        fletcherName.text = "Farm " + "(" + selectedRegion.fletcherLevel.ToString() + ")";
    //        weaponSmithName.text = "Farm " + "(" + selectedRegion.weaponSmithLevel.ToString() + ")";
    //        armorSmithName.text = "Farm " + "(" + selectedRegion.armorSmithLevel.ToString() + ")";
    //        siegeWorksName.text = "Farm " + "(" + selectedRegion.siegeWorksLevel.ToString() + ")";
    //        //Cost. fix
    //        farmCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        pastureCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        vineyardCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        lumberyardCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        quarryCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        mineCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        tailorCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        metalWorksCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        jewelryCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        blackSmithCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        fletcherCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        weaponSmithCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        armorSmithCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        siegeWorksCost.text = "Wood: " + BWCF("Farm").ToString() + " Stone: " + BSCF("Farm").ToString() + "\n" + "x" + "gold";
    //        //Construction Time. fix
    //        farmConstructionTime.text = 1.ToString();;
    //        pastureConstructionTime.text = 1.ToString();;
    //        vineyardConstructionTime.text = 1.ToString();;
    //        lumberyardConstructionTime.text = 1.ToString();;
    //        quarryConstructionTime.text = 1.ToString();;
    //        mineConstructionTime.text = 1.ToString();;
    //        tailorConstructionTime.text = 1.ToString();;
    //        metalWorksConstructionTime.text = 1.ToString();;
    //        jewelryConstructionTime.text = 1.ToString();;
    //        blackSmithConstructionTime.text = 1.ToString();;
    //        fletcherConstructionTime.text = 1.ToString();;
    //        weaponSmithConstructionTime.text = 1.ToString();;
    //        armorSmithConstructionTime.text = 1.ToString();;
    //        siegeWorksConstructionTime.text = 1.ToString();;
    //        //Military Section.

    //        //Civilian Section.



    //    }
    //}


    ////Worker Sliders.
    //public void FoodSlider(float workers)
    //{
    //    selectedRegion.farmWorkers = Mathf.FloorToInt(workers);
    //}
    //public void WineSlider(float workers)
    //{
    //    selectedRegion.vineyardWorkers = Mathf.FloorToInt(workers);
    //}
    //public void WoolSlider(float workers)
    //{
    //    selectedRegion.pastureWoolWorkers = Mathf.FloorToInt(workers);
    //}
    //public void WoodSlider(float workers)
    //{
    //    selectedRegion.lumberyardWorkers = Mathf.FloorToInt(workers);
    //}
    //public void StoneSlider(float workers)
    //{
    //    selectedRegion.quarryWorkers = Mathf.FloorToInt(workers);
    //}
    //public void IronOreSlider(float workers)
    //{
    //    selectedRegion.mineIronOreWorkers = Mathf.FloorToInt(workers);
    //}
    //public void SilverOreSlider(float workers)
    //{
    //    selectedRegion.mineSilverOreWorkers = Mathf.FloorToInt(workers);
    //}
    //public void GoldOreSlider(float workers)
    //{
    //    selectedRegion.mineGoldOreWorkers = Mathf.FloorToInt(workers);
    //}
    //public void LeatherSlider(float workers)
    //{
    //    selectedRegion.pastureLeatherWorkers = Mathf.FloorToInt(workers);
    //}
    //public void ClothSlider(float workers)
    //{
    //    selectedRegion.tailorWorkers = Mathf.FloorToInt(workers);
    //}
    //public void IronBarSlider(float workers)
    //{
    //    selectedRegion.metalWorksIronBarWorkers = Mathf.FloorToInt(workers);
    //}
    //public void SteelSlider(float workers)
    //{
    //    selectedRegion.metalWorksSteelWorkers = Mathf.FloorToInt(workers);
    //}
    //public void SilverWareSlider(float workers)
    //{
    //    selectedRegion.jewelryWorkers = Mathf.FloorToInt(workers);
    //}    
    //public void HorseSlider(float workers)
    //{
    //    selectedRegion.pastureHorseWorkers = Mathf.FloorToInt(workers);
    //}


    
    //public void ConstructionStarter(string type)
    //{
    //    if (selectedRegion.currentlyConstructing == false)
    //    {
    //        selectedRegion.StartConstruction(type);
    //    }
    //}

    ////Building Wood Cost Finder
    //int BWCF(string buildingType)
    //{
    //    int[] array = selectedRegion.BuildingCostDecider(buildingType);
    //    return array[0];
    //}
    ////Building Stone Cost Finder
    //int BSCF(string buildingType)
    //{
    //    int[] array = selectedRegion.BuildingCostDecider(buildingType);
    //    return array[1];
    //}

    //public void CloseUI()
    //{
    //    StartCoroutine("CloseUICoro");
    //}

    //IEnumerator CloseUICoro()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    regionViewerOwn.GetComponent<CanvasGroup>().alpha = 0;
    //    regionViewerOwn.GetComponent<CanvasGroup>().interactable = false;
    //    isUIOpen = false;
    //}

    //public void OpenUI()
    //{
    //    StartCoroutine("OpenUICoro");
    //}

    //IEnumerator OpenUICoro()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    regionViewerOwn.GetComponent<CanvasGroup>().alpha = 1;
    //    regionViewerOwn.GetComponent<CanvasGroup>().interactable = true;
    //    isUIOpen = true;
    //}
}
