using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EHealth : MonoBehaviour
{

    public float tHealth;
    public Slider bar;
    public int deadCurrency = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        bar.maxValue = tHealth;
        bar.value = tHealth;
        GameManager.gameManager.enemies.Add(this);

    }

    // Update is called once per frame
    void Update()
    {
        bar.transform.rotation = Camera.main.transform.rotation;
    }

    public void Damage(float damage)
    {
        tHealth -= damage;
        if (tHealth <= 0)
        {
            tHealth = 0;
            Destroy(gameObject);
            AquaCreditsManager.manager.addCurrency(deadCurrency);
            GameManager.gameManager.enemies.Remove(this);
        }

        bar.value = tHealth;
    }
}
