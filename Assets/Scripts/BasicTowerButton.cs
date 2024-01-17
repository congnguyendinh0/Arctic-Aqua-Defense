using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerButton : MonoBehaviour
{
 public Tower t;

 public void SelectT()
 {
PlayerManager.playerManager.TowerSetUp(t);
 }
}
