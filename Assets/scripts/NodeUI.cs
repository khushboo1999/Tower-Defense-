using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    private node target;
    public GameObject ui;
    public Text upgradeCostText;
    public Text sellCostText;
    public Button upgradeButton;
    


    public void SetTarget(node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        sellCostText.text = "₹" + target.turretBlueprint.SellAmount();

        if (!target.isUpgraded)
        {
            
            upgradeCostText.text = "₹" + target.turretBlueprint.UpgradeCost();
            
            upgradeButton.interactable = true;

        }
        else
        {
            upgradeCostText.text = "DONE";
            upgradeButton.interactable = false;
        }

        
        ui.SetActive(true);//for gameobjects we use setactive

    }


    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
     
            target.UpgradeTurret();
            BuildManager.instance.DeselectNode();
   

    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
