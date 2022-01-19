﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TradeNodeScript : NetworkBehaviour {


    public int myPosX;
    public int myPosY;
	public Map map;
	public int tradeNodeRadius;

	int mapSizeX;


	int mapSizeY;


    
    //Prices.
	public float foodPrice;
	public float woolPrice;
	public float woodPrice;
	public float stonePrice;
	public float ironOrePrice;
	public float winePrice;
	public float clothPrice;
	public float leatherPrice;
	public float steelPrice;
	public float silverOrePrice;
	public float silverWarePrice;
	public float ironBarPrice;
	public float horsePrice;
	public float goldOrePrice;

	//Stocks.
	public int foodStock;
	public int woolStock;
	public int woodStock;
	public int stoneStock;
	public int ironOreStock;
	public int wineStock;
	public int clothStock;
	public int leatherStock;
	public int steelStock;
	public int silverOreStock;
	public int silverWareStock;
	public int ironBarStock;
	public int horseStock;
	public int goldOreStock;

	//Supply.
	public float foodSupply;
	public float woolSupply;
	public float woodSupply;
	public float stoneSupply;
	public float ironOreSupply;
	public float wineSupply;
	public float clothSupply;
	public float leatherSupply;
	public float steelSupply;
	public float silverOreSupply;
	public float silverWareSupply;
	public float ironBarSupply;
	public float horseSupply;
	public float goldOreSupply;

	//Demand.
	public float foodDemand;
	public float woolDemand;
	public float woodDemand;
	public float stoneDemand;
	public float ironOreDemand;
	public float wineDemand;
	public float clothDemand;
	public float leatherDemand;
	public float steelDemand;
	public float silverOreDemand;
	public float silverWareDemand;
	public float ironBarDemand;
	public float horseDemand;
	public float goldOreDemand;

	void Start()
	{
		GameObject TheServer = GameObject.Find ("TheServer");
		map = TheServer.GetComponent<Map> ();
		
	}


   




	void UpdatePrices ()
	{
		foodPrice = 1 * (foodDemand / foodSupply);
		woolPrice = 1 * (woolDemand / woolSupply);
		woodPrice = 1 * (woodDemand / woodSupply);
		stonePrice = 1 * (stoneDemand / stoneSupply);
		ironOrePrice = 1 * (ironOreDemand / ironOreSupply);
		winePrice = 1 * (wineDemand / wineSupply);
		clothPrice = 1 * (clothDemand / clothSupply);
		leatherPrice = 1 * (leatherDemand / leatherSupply);
		steelPrice = 1 * (steelDemand / steelSupply);
		silverOrePrice = 1 * (silverOreDemand / silverOreSupply);
		silverWarePrice = 1 * (silverWareDemand / silverWareSupply);
		ironBarPrice = 1 * (ironBarDemand / ironBarSupply);
		horsePrice = 1 * (horseDemand / horseSupply);



	}

	//*************Supply and Demand Updates.

	public void UpdateFoodSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			foodSupply = foodSupply + amount;
			UpdatePrices ();
		}
		else
		{
			foodDemand = foodDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateWoolSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			woolSupply = woolSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			woolDemand = woolDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateWoodSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			woodSupply = woodSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			woodDemand = woodDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateStoneSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			stoneSupply = stoneSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			stoneDemand = stoneDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateIronOreSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			ironOreSupply = ironOreSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			ironOreDemand = ironOreDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateWineSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			wineSupply = wineSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			wineDemand = wineDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateClothSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			clothSupply = clothSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			clothDemand = clothDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateLeatherSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			leatherSupply = leatherSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			leatherDemand = leatherDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateSteelSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			steelSupply = steelSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			steelDemand = steelDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateSilverOreSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			silverOreSupply = silverOreSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			silverOreDemand = silverOreDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateSilverWareSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			silverWareSupply = silverWareSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			silverWareDemand = silverWareDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateIronBarSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			ironBarSupply = ironBarSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			ironBarDemand = ironBarDemand + amount;
			UpdatePrices ();
		}
	}

	public void UpdateHorseSupply (bool isSupply, int amount)
	{
		if(isSupply == true)
		{
			horseSupply = horseSupply + amount;
			UpdatePrices ();
		}
		else 
		{
			horseDemand = horseDemand + amount;
			UpdatePrices ();
		}
	}

	//*************Stock Updates.

	public void UpdateFoodStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			foodStock = foodStock + amount;

		}
		else
		{
			foodStock = foodStock - amount;

		}
	}

	public void UpdateWoolStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			woolStock = woolStock + amount;

		}
		else 
		{
			woolStock = woolStock - amount;

		}
	}

	public void UpdateWoodStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			woodStock = woodStock + amount;

		}
		else 
		{
			woodStock = woodStock - amount;

		}
	}

	public void UpdateStoneStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			stoneStock = stoneStock + amount;

		}
		else 
		{
			stoneStock = stoneStock - amount;

		}
	}

	public void UpdateIronOreStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			ironOreStock = ironOreStock + amount;

		}
		else 
		{
			ironOreStock = ironOreStock - amount;

		}
	}

	public void UpdateWineStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			wineStock = wineStock + amount;

		}
		else 
		{
			wineStock = wineStock - amount;

		}
	}

	public void UpdateClothStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			clothStock = clothStock + amount;

		}
		else 
		{
			clothStock = clothStock - amount;

		}
	}

	public void UpdateLeatherStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			leatherStock = leatherStock + amount;

		}
		else 
		{
			leatherStock = leatherStock - amount;

		}
	}

	public void UpdateSteelStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			steelStock = steelStock + amount;

		}
		else 
		{
			steelStock = steelStock - amount;

		}
	}

	public void UpdateSilverOreStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			silverOreStock = silverOreStock + amount;

		}
		else 
		{
			silverOreStock = silverOreStock - amount;

		}
	}

	public void UpdateSilverWareStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			silverWareStock = silverWareStock + amount;

		}
		else 
		{
			silverWareStock = silverWareStock - amount;

		}
	}

	public void UpdateIronBarStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			ironBarStock = ironBarStock + amount;

		}
		else 
		{
			ironBarStock = ironBarStock - amount;

		}
	}

	public void UpdateHorseStock (bool isIncrease, int amount)
	{
		if(isIncrease == true)
		{
			horseStock = horseStock + amount;

		}
		else 
		{
			horseStock = horseStock - amount;

		}
	}

}
