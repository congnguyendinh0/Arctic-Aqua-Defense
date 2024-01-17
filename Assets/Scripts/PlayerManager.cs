using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerManager;
    public Transform placing;
    public bool isSet;
    public LayerMask ground, hurdle;
    public float topBorder = 15f;
    public float bottomBorder = 20f;
    [HideInInspector] public Tower theTower;
    public GameObject effect;
    public void Awake()
    {
        playerManager = this;
    }

    public Tower aTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSet)
        {
            placing.position = GetPosition();

            RaycastHit hit;
            float mouseYPercentage = Input.mousePosition.y / Screen.height;

            if (mouseYPercentage > (1f - (topBorder / 100f)) || mouseYPercentage < (bottomBorder / 100f))
            {
                placing.gameObject.SetActive(false);
            }
            else if (Physics.Raycast(placing.position + new Vector3(0f, -2f, 0f), Vector3.up, out hit, 10f, hurdle))
            {
                placing.gameObject.SetActive(false);
            }
            else
            {
                placing.gameObject.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    if (AquaCreditsManager.manager.buy(aTower.price))
                    {
                        isSet = false;
                        Instantiate(aTower, placing.position, aTower.transform.rotation);
                        placing.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public Vector3 GetPosition()
    {
        Vector3 location = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 200f, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200f, ground))
        {
            location = hit.point;
        }

        location.y = 0;
        return location;
    }

    public void TowerSetUp(Tower t)
    {
        aTower = t;
        isSet = true;
        Destroy(placing.gameObject); // Consider deactivating instead of destroying
        Tower placingT = Instantiate(aTower);
        placingT.enabled = false;
        placingT.GetComponent<Collider>().enabled = false;
        placing = placingT.transform;
    }
    

    public void Effect()
    {
        if (theTower != null)
        {
            effect.transform.position = theTower.transform.position;
            effect.SetActive(true);
        }
        else
        {
            Debug.Log("cant find");
        }
    }
    

}