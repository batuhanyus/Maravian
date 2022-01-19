using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Battle : NetworkBehaviour {

    public int battleRound = 0;

    //Damages
    public int centerPierce = 0;
    public int centerSlash = 0;
    public int centerBlunt = 0;
    public int rightFlankPierce = 0;
    public int rightFlankSlash = 0;
    public int rightFlankBlunt = 0;
    public int leftFlankPierce = 0;
    public int leftFlankSlash = 0;
    public int leftFlankBlunt = 0;
    public int rearPierce = 0;
    public int rearSlash = 0;
    public int rearBlunt = 0;

    public List<Army> attackerArmies = new List<Army>();
    public List<Army> defenderArmies = new List<Army>();

    public List<Kingdom> attackerKingdoms = new List<Kingdom>();
    public List<Kingdom> defenderKingdoms = new List<Kingdom>();

    //Add Attacker

    public void AddAttacker(Army attacker)
    {
        attackerArmies.Add(attacker);
        if(attackerKingdoms.Contains(attacker.myKingdom) == false)
        {
            attackerKingdoms.Add(attacker.myKingdom);
        }
    }

    //Add Defender

    public void AddDefender(Army defender)
    {
        defenderArmies.Add(defender);
        if (defenderKingdoms.Contains(defender.myKingdom) == false)
        {
            defenderKingdoms.Add(defender.myKingdom);
        }
    }



    //Battle Round

    void BattleRound()
    {
        InitiliazeRound();
        PhasePicker();
        CenterDamageCalculations();
        CenterApplyDamages();

    }


    //Initiliaze
    void InitiliazeRound()
    {
        foreach(Army item in attackerArmies)
        {
            item.FormUpArmy();
        }
        foreach (Army item in defenderArmies)
        {
            item.FormUpArmy();
        }
    }

    //Phase Picker
    void PhasePicker()
    {

    }

    //Damage Calculations

    void CenterDamageCalculations()
    {

    }

    //Apply Damages

    void CenterApplyDamages()
    {

    }
}
