using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature {
    int currentStage;
    List<string> knownAbilityNames = new List<string>();
    private void Start()
    {
        knownAbilityNames = stats.abilityNames;
        currentTarget = GameObject.FindGameObjectWithTag("player");
    }
    /// <summary>
    /// changes the stage based on the percentage of health it has
    /// </summary>
    public void ChangePhase()
    {
        if (currentHealth / MaxHealth > .7)
        {
            currentStage = 1;
        }
        else if (currentHealth / MaxHealth <= .7)
        {
            currentStage = 2;
        }
        else if (currentHealth / MaxHealth <= .3)
        {
            currentStage = 3;
        }
    }

    override public  void Update()
    {
        base.Update();
        ChangePhase();
        if(newAbility != currentAbilityChoice)
        {
            ChangeAnimation();
        }

    }

    /// <summary>
    /// gets a random ability that the creature can use
    /// </summary>
    /// <returns></returns>
    override public string GetChoice()
    {
        int randomChoice = Random.Range(0, knownAbilityNames.Count-1);
        //Debug.Log(randomChoice);
        currentAbilityChoice = knownAbilityNames[randomChoice];
        if (knownAbilities[currentAbilityChoice] > currentStage)
        {
            GetChoice();
        }
        return currentAbilityChoice;
    }

    public void ChangeAnimation()
    {
        newAbility = currentAbilityChoice;
        
    }
}
