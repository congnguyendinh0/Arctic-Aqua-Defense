using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float slowEffect = 1f;
    private bool _isLast;
    public float enemyScore;

    private Waypoints _waypoints;
    public float btwAttacks, attackDmg;
    private float _countAtk;
    private int _currentWp;
    private int _zoneSelector;

    private ShipBase _shipBase;

    // Start is called before the first frame update
    void Start()
    {
        if (_waypoints == null)
        {
            _waypoints = FindObjectOfType<Waypoints>();
        }

        if (_shipBase == null)
        {
            _shipBase = FindObjectOfType<ShipBase>();
        }
        _countAtk = btwAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the ship's health is above 0
        if (GameManager.gameManager.isLive)
        {
            if (_isLast == false)
            {
                if (_waypoints != null && _waypoints.waypoints.Length > 0 && _currentWp < _waypoints.waypoints.Length)
                {
                    transform.LookAt(_waypoints.waypoints[_currentWp]);
                    transform.position = Vector3.MoveTowards(transform.position, _waypoints.waypoints[_currentWp].position, moveSpeed * Time.deltaTime * slowEffect);

                    if (Vector3.Distance(transform.position, _waypoints.waypoints[_currentWp].position) < 0.01f)
                    {
                        _currentWp++;

                        if (_currentWp >= _waypoints.waypoints.Length)
                        {
                            _isLast = true;

                            if (_shipBase != null && _shipBase.zone.Length > 0)
                            {
                                _zoneSelector = Random.Range(0, _shipBase.zone.Length);
                            }
                        }
                    }
                }
            }
            else
            {
                if (_shipBase != null && _shipBase.zone.Length > 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _shipBase.zone[_zoneSelector].position,
                        moveSpeed * Time.deltaTime * slowEffect);
                    _countAtk -= Time.deltaTime;
                    if (_countAtk <= 0)
                    {
                        _countAtk = btwAttacks;
                        if (_shipBase != null)
                        {
                            _shipBase.GetDmg(attackDmg);
                        }
                    }
                }
            }
        }
        
    }

    public void createEnemy(ShipBase newShipbase, Waypoints newWaypoints)
    {
        _shipBase = newShipbase;
        _waypoints = newWaypoints;
    }
}
