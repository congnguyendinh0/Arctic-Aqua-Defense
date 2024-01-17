using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaCreditsManager : MonoBehaviour

{
    public static AquaCreditsManager manager;
    private void Awake()
    {
        manager = this;
        
    }

    public int credits;

    // Start is called before the first frame update
    void Start()
    {
        UI.ui.value.text = credits.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCurrency(int n)
    {
        credits += n;
        UI.ui.value.text = credits.ToString();
    }

    public bool buy(int b)
    {
        bool ableToBuy = false;
        if (b <= credits)
        {
            ableToBuy = true;
            credits -= b;
            UI.ui.value.text = credits.ToString();
        }
        return ableToBuy;
    }
}
