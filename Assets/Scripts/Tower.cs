

using System;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 2f;
    public Collider[] colliders;
    public LayerMask selectedLayers;
    
    public List<Enemy> enemiesRange = new List<Enemy>();

    [HideInInspector] public bool eUpdate;

    private float updateCounter;
    public float updateTime = 0.5f;
    public float fireRate;

    public int price = 100;
    public UpgradeController upgrade;
    
    private void Start()
    {

        updateCounter = updateTime;
        upgrade = GetComponent<UpgradeController>();
    }

    private void Update()
    {
        eUpdate = false;
        updateCounter -= Time.deltaTime;
        if (updateCounter <= 0)
        {
            updateCounter = updateTime;
            colliders =Physics.OverlapSphere(transform.position, range, selectedLayers);
            enemiesRange.Clear();
            foreach (Collider c in colliders)
            {
                enemiesRange.Add(c.GetComponent<Enemy>());
            }

            eUpdate = true;
        }

      
    }

    private void OnMouseDown()
    {
        UI.ui.Open();
        PlayerManager.playerManager.theTower = this;
        PlayerManager.playerManager.Effect();
    }
}