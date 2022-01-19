using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : NetworkBehaviour {

    public Text usernameText;
    public Text passwordText;
    public Text infoText;

    public GameObject kingdomPrefab;
     

    public Database database;

    public Text wrongPass;

    void Start()
    {
        //Find UI Elements.
        if(isServer)
        {
            database = gameObject.GetComponent<Database>();
        }
              

    }


    //************************************Server Side.

    [Server]
    public void DoLogin(string username, string password)
    {
        //If username exist.
        if (database.usernames.Contains(username))
        {
            //Find Username.
            int index = database.usernames.IndexOf(usernameText.text);

            //Validate password.
            if (database.passwords[index] == passwordText.text)
            {
                //Find and pair Kingdom.
                int id = database.kingdoms[database.usernames.IndexOf(username)].myID;
                RpcLoginSuccess(id);

            }
            else
            {
                infoText.text = "Wrong password.";
            }
        }
        else
        {
            infoText.text = "User not exist.";
        }
        
    }

    [Server]
    public void DoRegister(string username, string password)
    {
        //Find if username does not exist.
        if (database.usernames.Contains(username) == false)
        {
            //Create account.
            database.usernames.Add(username);
            database.passwords.Insert(database.usernames.IndexOf(username), password);

            //Spawn Kingdom and Add ID.
            GameObject go = Instantiate(kingdomPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            Kingdom spawnedKingdom = go.GetComponent<Kingdom>();
            database.kingdoms.Insert(database.usernames.IndexOf(username), spawnedKingdom);

            spawnedKingdom.myID = (database.kingdoms.Count + 1);

            spawnedKingdom.transform.name = "Kingdom" + spawnedKingdom.myID.ToString();

            NetworkServer.Spawn(go);

            
        }
    }




    //***************************Client Side.

    [ClientRpc]
    void RpcLoginSuccess(int id)
    {
        if (isLocalPlayer)
        {
            infoText.text = "Login Success!";
        }
        //Assign kingdom.
        Kingdom[] array = GameObject.FindObjectsOfType<Kingdom>();
        foreach (Kingdom item in array)
        {
            if (item.myID == id)
            {
                gameObject.GetComponent<UI>().myKingdom = item;
            }
        }
        //Close Login UI And Move Player Camera To See Map.
    }

    [ClientRpc]
    void RpcRegisterSuccess()
    {
        infoText.text = "Register success.Please login.";
    }

}
