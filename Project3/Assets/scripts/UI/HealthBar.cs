using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image ImgHealthBar;

    public int Min;

    public int Max;

    private int mCurrentValue;

    private float mCurrentPercent;

    public GameObject dresdon;

    public Text ammoCounter;
    public Text hpText;

    public int currentAmmo;

    public int maxAmmo;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (dresdon != null)
        {
            Max = dresdon.GetComponent<Dresdon>().MaxHealth;
            SetHealth(dresdon.GetComponent<Dresdon>().currentHealth);
            maxAmmo = dresdon.GetComponent<Dresdon>().MaxAmmo;
            currentAmmo = dresdon.GetComponent<Dresdon>().Ammo;
        }
        

        ammoCounter.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
        hpText.text = "HP: " + mCurrentValue + "/" + Max;
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
