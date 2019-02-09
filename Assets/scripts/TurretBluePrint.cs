using UnityEngine;

[System.Serializable]//since this script is not attached to any gameObject so to see it;s variable in the inspector we need to add this code
//removed mono behaviour code since we don't to attach this with any gameobject
public class TurretBluePrint
{

    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    
    private node target;

    public void SetNode(node node)
    {
        target = node;
    }
    
    public int SellAmount()
    {
        if (target.IsUpgraded)
        
           return (cost + UpgradeCost())/ 2;
      
        else
            return cost / 2;
    }


    public int UpgradeCost()
    {
        return cost * 3 / 10;
    }
}
