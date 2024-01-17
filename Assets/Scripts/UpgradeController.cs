using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private Tower t;

    public Step[] fireRates;

    public int curFire;

    public bool hasFire = true;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Tower>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpgradeFire()
    {
        t.fireRate = fireRates[curFire].num;
        curFire++;
        if (curFire >= fireRates.Length)
        {
            hasFire = false;
            
        }
    }
}

[System.Serializable]
public class Step
{
    public float num;
    public int cost;
    
}
