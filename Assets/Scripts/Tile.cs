using UnityEngine;
using System.Collections;
using UnityEngine.Networking;



public class Tile : NetworkBehaviour {

	[SyncVar]
    public int myPosX;
    [SyncVar]
    public int myPosY;
	public Material PlainsMaterial;
	public Material MountainMaterial;
	public Material HillsMaterial;
	public Material ForestMaterial;
	public string myType;

    
   


	


	public void ApplyMaterial()
	{
		
	}

	void Start ()
	{
		if(myType == "Plains") 
		{
			Renderer renderer = GetComponent<Renderer> ();
			renderer.material = PlainsMaterial;
		}

		if(myType == "Mountain") 
		{
			Renderer renderer = GetComponent<Renderer> ();
			renderer.material = MountainMaterial;
		}

}
}