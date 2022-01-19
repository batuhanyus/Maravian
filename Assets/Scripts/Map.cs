using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;



public class Map : NetworkBehaviour
{

    public int mapSizeX = 5;
    public int MapSizeY = 5;
    public const int tradeNodeRadius = 2;

    public GameObject[,] regions;

    public GameObject Tile;
    public GameObject TradeNodePrefab;

    public string[,] worldTileTypes;
	public GameObject[,] tradeNodes;

    bool mapIsGenerated = false;

    

    void Start()
    {
        regions = new GameObject[mapSizeX, MapSizeY];
        tradeNodes = new GameObject[mapSizeX, MapSizeY];
        if (mapIsGenerated != true)
        {
            CreateWorld();
            PopulateWorldMap();
            mapIsGenerated = true;
            
        }

       
     

    }


    //This will generate the world on paper.
    [Server]
    void CreateWorld()
    {
        //Create 2D array to specify tile types.
        worldTileTypes = new string[mapSizeX, MapSizeY];

        //Convert some to plains.
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < MapSizeY; y++)
            {
                if (y < 11)
                {
                    worldTileTypes[x, y] = "Plains";
                }
            }
        }



        //Convert some to mountains.
        for (int x = 0; x < mapSizeX; x++)
        {

            for (int y = 0; y < MapSizeY; y++)
            {

                if (y > 10)
                {
                    worldTileTypes[x, y] = "Mountain";
                }
            }
        }

        //Convert some to Trade Node.
        
        //First one is manual.
        worldTileTypes[tradeNodeRadius, tradeNodeRadius] = "TradeNode";

        for (int x = tradeNodeRadius; x < mapSizeX; x = x + tradeNodeRadius * 2 + 1)
        {
            for (int y = tradeNodeRadius; y < MapSizeY; y = y + tradeNodeRadius*2 + 1)
            {
                        worldTileTypes[x, y] = "TradeNode";

            }

        }

       
    }

    //This will create/spawn tiles for previously generated -on paper- world.
    [Server]
    void PopulateWorldMap()
    {

        //Spawn plains.
        for (int counterX = 0; counterX < mapSizeX; counterX++)
        {
            for (int counterY = 0; counterY < MapSizeY; counterY++)
            {
                if (worldTileTypes[counterX, counterY] == "Plains")
                {

                    GameObject go = Instantiate(Tile, new Vector3(counterX, counterY, 0), Quaternion.identity) as GameObject;
                    regions[counterX, counterY] = go;

                    Tile goScript = go.GetComponent<Tile>();
                    goScript.myPosX = counterX;
                    goScript.myPosY = counterY;
                    goScript.myType = "Plains";

                    NetworkServer.Spawn(go);

                }
            }
        }

        //Spawn mountains.
        for (int counterX = 0; counterX < mapSizeX; counterX++)
        {
            for (int counterY = 0; counterY < MapSizeY; counterY++)
            {
                if (worldTileTypes[counterX, counterY] == "Mountain")
                {

                    GameObject go = Instantiate(Tile, new Vector3(counterX, counterY, 0), Quaternion.identity) as GameObject;
                    regions[counterX, counterY] = go;

                    Tile goScript = go.GetComponent<Tile>();
                    goScript.myPosX = counterX;
                    goScript.myPosY = counterY;
                    goScript.myType = "Mountain";

                    NetworkServer.Spawn(go);

                }
            }
        }

        //Spawn trade nodes.
        for (int counterX = 0; counterX < mapSizeX; counterX++)
        {
            for (int counterY = 0; counterY < MapSizeY; counterY++)
            {
                if (worldTileTypes[counterX, counterY] == "TradeNode")
                {
					
					GameObject go = Instantiate(TradeNodePrefab, new Vector3(counterX, counterY, 0), Quaternion.identity) as GameObject;
					tradeNodes[counterX, counterY] = go;


                    TradeNodeScript goScript = go.GetComponent<TradeNodeScript>();
                    goScript.myPosX = counterX;
                    goScript.myPosY = counterY;

                    NetworkServer.Spawn(go);

                }
            }
        }

    }

    


   
    

	




}