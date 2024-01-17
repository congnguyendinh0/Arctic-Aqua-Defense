using UnityEngine;
using UnityEngine.Serialization;

public class SpawnerTest : MonoBehaviour
{
    public Enemy[] enemies;
    public Transform location;
    public float betweenSpawn;
    public float maxEnemyScore;
    public float counterSpawn;
    [FormerlySerializedAs("_waypoints")] public Waypoints waypoints;
    [FormerlySerializedAs("ShipBase")] [FormerlySerializedAs("_ShipBase")] public ShipBase shipBase;
    public float amount;

    // Start is called before the first frame update
    void Start()
    {
        counterSpawn = betweenSpawn;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amount > 0 && GameManager.gameManager.isLive)
        {
            if (amount > 0.001f)
            {
                counterSpawn -= Time.deltaTime;

                if (counterSpawn <= 0)
                {
                    counterSpawn = betweenSpawn;
                    Instantiate(enemies[Random.Range(0,enemies.Length)], location.position, location.rotation).createEnemy(shipBase, waypoints);
                    amount--;
                }
            }
        }
        
        
    }

  
}