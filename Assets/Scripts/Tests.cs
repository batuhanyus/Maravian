using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tests : MonoBehaviour
{



    void Start()
    {

        

    }

    
    IEnumerator Print()
    {
        print("a");
        yield return new WaitForSeconds(1f);
        print("b");
        yield return new WaitForSeconds(1f);
        StartCoroutine("Print");
    }


    void Printer()
    {
        Debug.Log("Printed!");
    }



}