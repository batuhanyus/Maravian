using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;


public class Database : NetworkBehaviour {


    public List<string> usernames = new List<string>();
    public List<string> passwords = new List<string>();
    public List<Kingdom> kingdoms = new List<Kingdom>();
	
}
