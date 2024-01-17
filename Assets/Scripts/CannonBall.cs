using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour


{
    public Rigidbody rb;
    
    public GameObject particle;

    public float moveSpeed;

    public float dmgA;

    private bool damaged;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * moveSpeed;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !damaged)
        {
            other.GetComponent<EHealth>().Damage(dmgA);
            damaged = true;
        }
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
