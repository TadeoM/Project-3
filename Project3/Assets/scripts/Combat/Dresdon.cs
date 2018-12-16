using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresdon : Creature {

	// Use this for initialization
	void Start () {
        currentTarget = GameObject.FindGameObjectWithTag("enemy");
    }

    override public string SelectAttackChoice()
    {

        switch (currentAbilityChoice)
        {
            case "Attack":
                ChangeAnimation(1);
                break;
            case "Shoot":
                ChangeAnimation(2);
                break;
            case "Defendarius":
                ChangeAnimation(3);
                break;
            case "Fuego":
                ChangeAnimation(4);
                break;
            case "CircleOfFire":
                ChangeAnimation(5);
                break;
            case "CircleOfIron":
                ChangeAnimation(6);
                break;
            case "EnfAttack":
                ChangeAnimation(7);
                break;
            case "EnfGuard":
                ChangeAnimation(8);
                break;
            case "Fortius":
                ChangeAnimation(9);
                break;
            default:
                break;
        }
        return base.SelectAttackChoice();
    }
}
