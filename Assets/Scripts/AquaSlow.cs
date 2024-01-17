using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaSlow : MonoBehaviour
{
    public float effect = 0.6f;
    private Tower t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy e in t.enemiesRange)
        {
            e.slowEffect = t.fireRate;
        }
    }
}
