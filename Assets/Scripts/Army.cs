using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Army : NetworkBehaviour {


    public Kingdom myKingdom;



    //Total Troop Numbers.
    public List<TroopTypeScript> troopTypes = new List<TroopTypeScript>();
    public List<int> troopNumbers = new List<int>();
    public List<int> troopGörevYeriCount = new List<int>();

    //***Formation

    //Center
    public List<TroopTypeScript> centerTroopTypes = new List<TroopTypeScript>();
    public List<int> centerTroopNumbers = new List<int>();
    public List<float> centerTroopPercentages = new List<float>();

    //Right Flank
    public List<TroopTypeScript> rightFlankTroopTypes = new List<TroopTypeScript>();
    public List<int> rightFlankTroopNumbers = new List<int>();
    public List<float> rightFlankTroopPercentages = new List<float>();

    //Left Flank
    public List<TroopTypeScript> leftFlankTroopTypes = new List<TroopTypeScript>();
    public List<int> leftFlankTroopNumbers = new List<int>();
    public List<float> leftFlankTroopPercentages = new List<float>();

    //Rear
    public List<TroopTypeScript> rearTroopTypes = new List<TroopTypeScript>();
    public List<int> rearTroopNumbers = new List<int>();
    public List<float> rearTroopPercentages = new List<float>();

    public void FormUpArmy()
    {
        //Clear.
        centerTroopTypes.Clear();
        centerTroopNumbers.Clear();
        centerTroopPercentages.Clear();
        rightFlankTroopTypes.Clear();
        rightFlankTroopNumbers.Clear();
        rightFlankTroopPercentages.Clear();
        leftFlankTroopTypes.Clear();
        leftFlankTroopNumbers.Clear();
        leftFlankTroopPercentages.Clear();
        rearTroopTypes.Clear();
        rearTroopNumbers.Clear();
        rearTroopPercentages.Clear();
        troopGörevYeriCount.Clear();


        //Calculate Görev Yeri Counts.

        foreach (TroopTypeScript item in troopTypes)
        {
            int counter = 0;
            if (item.center == true)
            {
                counter++;
            }
            if (item.rightFlank == true)
            {
                counter++;
            }
            if (item.leftFlank == true)
            {
                counter++;
            }
            if (item.rear == true)
            {
                counter++;
            }

            troopGörevYeriCount[troopTypes.IndexOf(item)] = counter;

        }

        //***Now Calculate Numbers and Percentages For Flanks.

        //Center

        foreach (TroopTypeScript item in troopTypes)
        {
            int görevYeriCount = troopGörevYeriCount[troopTypes.IndexOf(item)];
            int totalNumber = troopNumbers[troopTypes.IndexOf(item)];
            int troopsForThisFlank = totalNumber / görevYeriCount;

            centerTroopTypes.Add(item);
            centerTroopNumbers.Add(troopsForThisFlank);

        }

        //Percentage
        int totalCenterTroops = 0;
        foreach (int item in centerTroopNumbers)
        {
            totalCenterTroops += item;
        }

        foreach(TroopTypeScript item in centerTroopTypes)
        {
            int myIndex = centerTroopTypes.IndexOf(item);
            int amount = centerTroopNumbers[myIndex];
            centerTroopPercentages[myIndex] = totalCenterTroops / amount;
        }

        //Right Flank
        foreach (TroopTypeScript item in troopTypes)
        {
            int görevYeriCount = troopGörevYeriCount[troopTypes.IndexOf(item)];
            int totalNumber = troopNumbers[troopTypes.IndexOf(item)];
            int troopsForThisFlank = totalNumber / görevYeriCount;

            rightFlankTroopTypes.Add(item);
            rightFlankTroopNumbers.Add(troopsForThisFlank);

        }

        //Percentage

        int totalRightFlankTroops = 0;
        foreach (int item in rightFlankTroopNumbers)
        {
            totalRightFlankTroops += item;
        }

        foreach (TroopTypeScript item in rightFlankTroopTypes)
        {
            int myIndex = rightFlankTroopTypes.IndexOf(item);
            int amount = rightFlankTroopNumbers[myIndex];
            rightFlankTroopPercentages[myIndex] = totalRightFlankTroops / amount;
        }

        //Left Flank
        foreach (TroopTypeScript item in troopTypes)
        {
            int görevYeriCount = troopGörevYeriCount[troopTypes.IndexOf(item)];
            int totalNumber = troopNumbers[troopTypes.IndexOf(item)];
            int troopsForThisFlank = totalNumber / görevYeriCount;

            leftFlankTroopTypes.Add(item);
            leftFlankTroopNumbers.Add(troopsForThisFlank);

        }

        //Percentage

        int totalLeftFlankTroops = 0;
        foreach (int item in leftFlankTroopNumbers)
        {
            totalLeftFlankTroops += item;
        }

        foreach (TroopTypeScript item in leftFlankTroopTypes)
        {
            int myIndex = leftFlankTroopTypes.IndexOf(item);
            int amount = leftFlankTroopNumbers[myIndex];
            leftFlankTroopPercentages[myIndex] = totalLeftFlankTroops / amount;
        }

        //Rear
        foreach (TroopTypeScript item in troopTypes)
        {
            int görevYeriCount = troopGörevYeriCount[troopTypes.IndexOf(item)];
            int totalNumber = troopNumbers[troopTypes.IndexOf(item)];
            int troopsForThisFlank = totalNumber / görevYeriCount;

            rearTroopTypes.Add(item);
            rearTroopNumbers.Add(troopsForThisFlank);

        }

        //Percentage

        int totalRearTroops = 0;
        foreach (int item in rearTroopNumbers)
        {
            totalRearTroops += item;
        }

        foreach (TroopTypeScript item in rearTroopTypes)
        {
            int myIndex = rearTroopTypes.IndexOf(item);
            int amount = rearTroopNumbers[myIndex];
            rearTroopPercentages[myIndex] = totalRearTroops / amount;
        }
    }

    
    //****Battle

}
