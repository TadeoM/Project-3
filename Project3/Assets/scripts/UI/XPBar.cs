using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour {

    public Image ImgXPBar;

    public int Min;

    public int Max;

    private float mCurrentValue;

    private float mCurrentPercent;

    public GameObject dresdon;

    public int currentLevel;

    public float currentXP;

    public Text current;
    public Text currentLvl;

    // Use this for initialization
    void Start()
    {
        Max = dresdon.GetComponent<Dresdon>().nextLevelXP;
        currentLevel = dresdon.GetComponent<Dresdon>().Level;
    }

    // Update is called once per frame
    void Update()
    {
        if (dresdon != null)
        {
            Max = dresdon.GetComponent<Dresdon>().nextLevelXP;
            SetXP(dresdon.GetComponent<Dresdon>().Experience);
            currentLevel = dresdon.GetComponent<Dresdon>().Level;
        }
        
        //current.text = "XP: " + currentXP + "/" + Max;
        currentLvl.text = "LVL: " + currentLevel;
    }

    public void SetXP(float xp)
    {
        if (xp < Max && currentLevel != 10)
        {
            mCurrentValue = xp;
            mCurrentPercent = mCurrentValue / (float)Max;
            //currentXP += xp;
            ImgXPBar.fillAmount = mCurrentPercent;
        }
        else
        {
            mCurrentValue = 0;
            mCurrentPercent = 0;
        }
    }

    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public float CurrentValue
    {
        get { return mCurrentValue; }
    }
}
