using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WillBar : MonoBehaviour {

    public Image ImgWillBar;

    public int Min;

    public int Max;

    private int mCurrentValue;

    private float mCurrentPercent;

    public GameObject dresdon;

    public Text willText;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dresdon != null)
        {
            Max = dresdon.GetComponent<Dresdon>().MaxMana;
            SetWill(dresdon.GetComponent<Dresdon>().currentMana);
        }
        
        willText.text = "Will: " + mCurrentValue + "/" + Max;
    }

    public void SetWill(int will)
    {
        if (will != mCurrentValue)
        {
            if (Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = will;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            ImgWillBar.fillAmount = mCurrentPercent;
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
