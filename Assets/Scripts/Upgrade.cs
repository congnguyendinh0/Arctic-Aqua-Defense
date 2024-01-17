using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour

{
    public void Sell()
    {
        AquaCreditsManager.manager.buy(-25);
        Destroy(PlayerManager.playerManager.theTower.gameObject);
        UI.ui.Close();
    }

    public void FireUpgrade()
    {
        UpgradeController upgrade = PlayerManager.playerManager.theTower.upgrade;
        if (upgrade.hasFire)
        {
            if (AquaCreditsManager.manager.buy(upgrade.fireRates[upgrade.curFire].cost))
            {
                upgrade.UpgradeFire();
            }
        }
    }
}
