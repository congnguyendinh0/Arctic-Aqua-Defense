using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    public Tower tower;

    public GameObject fireball;

    public Transform firePosition;

    public float timeBtwFire = 2f;

    public float fireCounter;

    public Transform target;

    public Transform weapon;

    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            weapon.rotation = Quaternion.Slerp(weapon.rotation,Quaternion.LookRotation(target.position - transform.position), 5f*Time.deltaTime);
            weapon.rotation = Quaternion.Euler(0f, weapon.rotation.eulerAngles.y, 0f);
        }
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0 && target != null)
        {
            fireCounter = timeBtwFire;
            firePosition.LookAt(target);
            Instantiate(fireball, firePosition.position, firePosition.rotation);
            Instantiate(particle, firePosition.position, firePosition.rotation);
        }

        if (tower.eUpdate)
        {
            if (tower.enemiesRange.Count > 0)
            {
                float minDistance = tower.range + 1f;
                foreach (Enemy e in tower.enemiesRange)
                {
                    if (e != null)
                    {
                        float distance = Vector3.Distance(transform.position, e.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = e.transform;
                        }
                    }
                }
            }  else
            {
                target = null;
            }
        }
        
    }
}
