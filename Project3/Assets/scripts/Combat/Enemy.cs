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
        spellManager = GameObject.FindGameObjectWithTag("spellManager").GetComponent<SpellManager>();
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

    override public void Update()
    {
        base.Update();
        ChangePhase();
    }

    /// <summary>
    /// gets a random ability that the creature can use
    /// </summary>
    /// <returns></returns>
    override public string GetChoice()
    {
        int randomChoice = Random.Range(0, knownAbilityNames.Count-1);
        //Debug.Log(knownAbilityNames.Count);
        currentAbilityChoice = knownAbilityNames[randomChoice];
        if (knownAbilities[currentAbilityChoice] > currentStage)
        {
            GetChoice();
        }
        int[] neededResource = spellManager.abilitiesDictionary[currentAbilityChoice];
        if (neededResource[1] > CurrentMana)
        {
            GetChoice();
        }
        return currentAbilityChoice;
    }

    override public string SelectAttackChoice()
    {


        //switch (currentAbilityChoice)
        //{
        //    case "Slash":
        //    case "Swipe":
        //    case "Bite":
        //    case "Scratch":
        //        ChangeAnimation(1);
        //        break;
        //    case "Siphon":
        //    case "Scortch":
        //    case "Devour":
        //        ChangeAnimation(2);
        //        break;
        //    case "Feast":
        //    case "Howl":
        //    case "Fortify":
        //    case "Screech":
        //        ChangeAnimation(3)
        //        break;
        //    default:
        //        break;
        //}
        return base.SelectAttackChoice();
    }
}
