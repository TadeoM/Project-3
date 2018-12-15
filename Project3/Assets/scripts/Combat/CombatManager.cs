using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    Creature playerCharacter;

    List<Creature> enemies = new List<Creature>();

    Queue<Creature> attackOrder = new Queue<Creature>();
    public bool takenTurn;
    public string winner;
    float enemyXP;
    public bool finished;
    public GameObject turnManager;
    public GameObject enemy;
    public bool firstRound = false;

	// Use this for initialization
	void Start () {
        winner = "nil";
        takenTurn = false;
        finished = false;
        GameObject dresdon = GameObject.FindGameObjectWithTag("player");
        playerCharacter = GameObject.FindGameObjectWithTag("player").GetComponent<Creature>();
        //GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("enemy");
        enemies.Add(enemy.GetComponent<Creature>());
        enemyXP = enemy.GetComponent<Creature>().Experience;
        //foreach (var enemy in enemyObjects)
        // {
        //   enemies.Add(enemy.GetComponent<Enemy>());
        // enemyXP = enemy.GetComponent<Creature>().Experience;
        // }
        DetermineAttackOrder();
    }
	
	// Update is called once per frame
	void Update () {
        if (firstRound)
        {
            enemies.Clear();
            enemies.Add(enemy.GetComponent<Creature>());
            attackOrder.Clear();
            
            DetermineAttackOrder();
            firstRound = false;
        }


        if (attackOrder.Peek() != null)
        {
            
            CalculateTurn();
        }
        else if(winner != "nil")
        {
            Debug.Log("The winner of this fight is " + winner);
            if(winner == "Dresden" && !finished)
            {
                playerCharacter.IncreaseExperience(enemyXP);
            }
            finished = true;
        }
        
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
            double maxSpeed = int.MinValue;
            int creatureIndex = 0;

            //Check each creature to see which one has the greatest speed;
            for (int i = 0; i < allCreatures.Count; i++)
            {

                //If the current creature's speed is greater than the max speed;
                if (allCreatures[i].Speed>maxSpeed)
                {
                    //Set the max speed value to the current 
                    maxSpeed = allCreatures[i].Speed;
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

    /// <summary>
    /// Moves the guy at the front of the line to the back.
    /// </summary>
    void ProgressTurnOrder()
    {
        takenTurn = false;
        //Take the top element of the attack order and move it to the bottom of the queue.
        attackOrder.Enqueue(attackOrder.Peek());

        //Remove the top element of the attack order.
        attackOrder.Dequeue();
    }

    void CalculateTurn()
    {
        
        //Get the creature's move
        if (attackOrder.Peek().gameObject.tag == "enemy")
        {
            Enemy currentEnemy = attackOrder.Peek().GetComponent<Enemy>();
            currentEnemy.GetChoice();
            string whatHappened = currentEnemy.SelectAttackChoice();

            Debug.Log(whatHappened);
            takenTurn = true;
        }
        else if (attackOrder.Peek().currentAbilityChoice != "")
        {
            string whatHappened = attackOrder.Peek().SelectAttackChoice();
            if (whatHappened == "Could not use ability due to not having enough mana" || whatHappened == "Could not use ability due to not having enough ammo")
                return;
            attackOrder.Peek().currentAbilityChoice = "";
            Debug.Log(whatHappened);
            takenTurn = true;
        }
        if (attackOrder.Peek().currentTarget.GetComponent<Creature>().CheckDeath())
        {
            Destroy(attackOrder.Peek().currentTarget);
            winner = attackOrder.Peek().gameObject.name;
        }

        //Move to the next character
        if (takenTurn)
            ProgressTurnOrder();
    }

    public void ChangeChoice(string name)
    {
        attackOrder.Peek().currentAbilityChoice = name;
    }
}
