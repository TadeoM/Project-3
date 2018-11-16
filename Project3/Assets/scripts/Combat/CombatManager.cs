using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public Dresdon playerCharacter;

    List<Creature> enemies = new List<Creature>();

    Queue<Creature> attackOrder = new Queue<Creature>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DetermineAttackOrder()
    {
        //Create a temporary list to hold all the fighters
        List<Creature> allCreatures = enemies;

        //Add dresdon to that list.
        allCreatures.Add(playerCharacter);
   

        //While there are still creatures that haven't been added to the queue.
        while (allCreatures.Count!=0)
        {

            //Start off the max speed as the smallest possible value.
            int maxSpeed = int.MinValue;
            int creatureIndex = 0;

            //Check each creature to see which one has the greatest speed;
            for (int i = 0; i < allCreatures.Count; i++)
            {

                //If the current creature's speed is greater than the max speed;
                if (allCreatures[i].speed>maxSpeed)
                {
                    //Set the max speed value to the current 
                    maxSpeed = allCreatures[i].speed;
                    //Get the index of the creature we may want to add to the queue.
                    creatureIndex = i;
                }
            }

            //Add the creature with the highest speed to the back of the line.
            attackOrder.Enqueue(allCreatures[creatureIndex]);

            //Remove the creature from the list of all creatures to make sure
            //it isn't checked twice.
            allCreatures.RemoveAt(creatureIndex);
        }
        
    }

   void ProgressTurnOrder()
    {
        //Take the top element of the attack order and move it to the bottom of the queue.
        attackOrder.Enqueue(attackOrder.Peek());

        //Remove the top element of the attack order.
        attackOrder.Dequeue();

        //This effectively moves the guy at the front of the line to the back.
    }

    void NewTurn()
    {


        //Get the creature's move

        //Display the results of the move

        //Move to the next character
        ProgressTurnOrder();
    }


}
