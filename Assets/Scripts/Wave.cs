using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Wave : MonoBehaviour
{
    // Start is called before the first frame update
    [FormerlySerializedAs("Spawn")] public List<eWave> WaveList;
    private float count;
    public float waiting;
    public bool spawn;
    
    public Transform location;
    [FormerlySerializedAs("_waypoints")] public Waypoints waypoints;
    [FormerlySerializedAs("ShipBase")] [FormerlySerializedAs("_ShipBase")] public ShipBase shipBase;

    void Start()
    {
        count = waiting;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            count -= Time.deltaTime;
            if (count < 0)
            {
                if (WaveList.Count > 0)
                {
                    if (WaveList[0].enemiesList.Count > 0)
                    {
                        Instantiate(WaveList[0].enemiesList[0], location.position, location.rotation);
                        count = WaveList[0].time;
                        WaveList[0].enemiesList.RemoveAt(0);
                        if (WaveList[0].enemiesList.Count == 0)
                        {
                            count = WaveList[0].timeWave;
                            WaveList.RemoveAt(0);
                            if (WaveList.Count == 0)
                            {
                                spawn = false;
                            }
                        }
                    }
                }
            }
        }
    
    }
}
[System.Serializable]
public class eWave
{
    public List<Enemy> enemiesList = new List<Enemy>();
    public float time;
    public float timeWave;

}