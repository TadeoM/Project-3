using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHB : MonoBehaviour {

    public Image ImgHealthBar;
    public int Min;
    public int Max;
    private int mCurrentValue;
    private float mCurrentPercent;
    public GameObject enemy;
   // public Text hpText;
    public GameObject CBManager;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(CBManager.GetComponent<CombatManager>().enemy != null)
        {
            enemy = CBManager.GetComponent<CombatManager>().enemy;
        }
        if(enemy != null)
        {
            Max = enemy.GetComponent<Creature>().MaxHealth;
            SetHealth(enemy.GetComponent<Creature>().currentHealth);
        }
       
       // hpText.text = "HP: " + mCurrentValue + "/" + Max;
    }

    public void SetHealth(int health)
    {
        if (health != mCurrentValue)
        {
            if (Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            ImgHealthBar.fillAmount = mCurrentPercent;
        }
    }

    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public int CurrentValue
    {
        get { return mCurrentValue; }
    }
}
