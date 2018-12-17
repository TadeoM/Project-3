using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour {

    Creature playerCharacter;

    List<Creature> enemies = new List<Creature>();

    Queue<Creature> attackOrder = new Queue<Creature>();
    public bool takenTurn;
    public string winner;
    float enemyXP;
    bool middleSet;
    float OGTimer;
    float timer;
    float fPercentage;
    float distanceBetween; // will be the distance between each position in the grid.
    float startTime;
    float middleTime;
    float speed;
    float journeyLength;
    public bool finished;
    public GameObject turnManager;
    public GameObject enemy;
    public bool firstRound = false;
    public GameObject gameOverUI;
    public GameObject combatUI;
    public MusicManagement musicManager;
    public GameObject hud;

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
        speed = 1.1f;
        distanceBetween = 0.4f;
    }
	
	// Update is called once per frame
	void Update () {
        if (firstRound)
        //Debug.Log(attackOrder.Peek());
        if (takenTurn && timer > timer / 2)
        {
            enemies.Clear();
            enemies.Add(enemy.GetComponent<Creature>());
            attackOrder.Clear();
            
            DetermineAttackOrder();
            firstRound = false;
        }
        if (takenTurn && timer > OGTimer * 0.4f)
        {
            
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            attackOrder.Peek().transform.position = Vector3.Lerp(attackOrder.Peek().startPos, attackOrder.Peek().endPos, fracJourney);
            
        }
        else if (takenTurn && (timer <= OGTimer * 0.4f && timer > 0))
        {
            if(!middleSet)
            {
                middleTime = Time.time;
                middleSet = true;
                attackOrder.Peek().currentTarget.GetComponent<Creature>().ChangeAnimation(2);
            }
            attackOrder.Peek().currentTarget.GetComponent<Creature>().ChangeAnimation(0);
            attackOrder.Peek().ChangeAnimation(1);

            // Distance moved = time * speed.
            float distCovered = (Time.time - middleTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            attackOrder.Peek().transform.position = Vector3.Lerp(attackOrder.Peek().endPos, attackOrder.Peek().startPos, fracJourney);
        }
        else if (takenTurn && timer <= 0)
        {
            // we will progress turn and update the health and mana of everything after the timer
            ProgressTurnOrder();
        }

        if (attackOrder.Peek() != null && !takenTurn)
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
            else
            {
                //SceneManager.LoadScene("title");
                musicManager.gameOver = true;
                gameOverUI.SetActive(true);
                combatUI.SetActive(false);
                hud.SetActive(false);
                Time.timeScale = 0;
            }
            finished = true;
        }
        //Debug.Log(timer);
        if(timer > 0)
        {
            timer -= (1 % Time.deltaTime);
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
        attackOrder.Peek().ChangeAnimation(0);
        attackOrder.Peek().currentTarget.GetComponent<Creature>().ChangeAnimation(0);
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
            middleSet = false;
            OGTimer = timer = 1f;
            startTime = Time.time;
            currentEnemy.startPos = currentEnemy.gameObject.transform.position;
            currentEnemy.endPos = currentEnemy.startPos + (Vector3.Normalize(currentEnemy.currentTarget.transform.position - currentEnemy.startPos) * distanceBetween);
            journeyLength = Vector3.Distance(attackOrder.Peek().startPos, attackOrder.Peek().endPos);
            currentEnemy.ChangeAnimation(1);
            
        }
        else if (attackOrder.Peek().currentAbilityChoice != "")
        {
            Creature dresdon = attackOrder.Peek();
            string whatHappened = dresdon.SelectAttackChoice();
            if (whatHappened == "Could not use ability due to not having enough mana" || whatHappened == "Could not use ability due to not having enough ammo")
                return;
            dresdon.currentAbilityChoice = "";
            Debug.Log(whatHappened);
            takenTurn = true;
            middleSet = false;
            OGTimer = timer = 1f;
            startTime = Time.time;
            dresdon.startPos = dresdon.gameObject.transform.position;
            Debug.Log(dresdon.gameObject.transform.position);
            dresdon.endPos = dresdon.startPos + (Vector3.Normalize(dresdon.currentTarget.transform.position - dresdon.startPos) * distanceBetween);
            Debug.Log(dresdon.endPos);
            journeyLength = Vector3.Distance(dresdon.startPos, dresdon.endPos);
            //dresdon.ChangeAnimation(1);
        }
        if (attackOrder.Peek().currentTarget.GetComponent<Creature>().CheckDeath())
        {
            Destroy(attackOrder.Peek().currentTarget);
            winner = attackOrder.Peek().gameObject.name;
        }

        //Move to the next character
       // if (takenTurn)
            //ProgressTurnOrder();
    }

    public void ChangeChoice(string name)
    {
        attackOrder.Peek().currentAbilityChoice = name;
    }
}
