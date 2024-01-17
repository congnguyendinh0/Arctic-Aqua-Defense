using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ShipBase : MonoBehaviour
{
    public float totalHealth = 100f;
    public float curHealth;
    public Slider healthBar;
    public Transform[] zone;
    public float percent;

    void Start()
    {
        curHealth = totalHealth;
        healthBar.maxValue = totalHealth;
        healthBar.value = curHealth;

        // Calculate and display the initial health percentage
        CalculateHealthPercentage();
        UI.ui.life.text = percent.ToString("F0") + "%";
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here
    }

    public void GetDmg(float dmg)
    {
        curHealth -= dmg;
        if (curHealth <= 0)
        {
            curHealth = 0;
            Destroy(gameObject);
        }
        healthBar.value = curHealth;
        UI.ui.life.text = curHealth.ToString(CultureInfo.InvariantCulture);

        // Calculate health percentage and update UI
        CalculateHealthPercentage();
        UI.ui.life.text = percent.ToString("F1") + "%";
    }

    void CalculateHealthPercentage()
    {
        // Calculate health percentage
        percent = (curHealth / totalHealth) * 100f;
        // Clamp the percentage to be within the range [0, 100]
        percent = Mathf.Clamp(percent, 0f, 100f);
    }
}