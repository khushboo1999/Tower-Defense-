using UnityEngine.EventSystems;//for is pointer over gameObject
using UnityEngine;

public class node : MonoBehaviour
{

    public Color hoverColor;
    private Color startColor;
    public Color warningColor;
    private Renderer rend;
    public NodeUI nodeUI;
    
    public Vector3 positionOffset;
    BuildManager buildmanager;

    [HideInInspector]
    public GameObject turret;//filled by buildmanager script
    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
  
    
     


    void Start()
    {

        rend = GetComponent<Renderer>(); //get renderer component
        startColor = rend.material.color;//the original color of the node
        buildmanager = BuildManager.instance;
                 
    }

    public bool IsUpgraded { get { return isUpgraded; } }

    
   public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

 

    void OnMouseEnter()//when mouse moves over that node
    { 
       
        if (EventSystem.current.IsPointerOverGameObject())//if pointer is over a gameobject here it can be over buttons(didn't understand completely)
            return;

       

        if (!buildmanager.CanBuild||turret!=null)//if no turret is selected or some turret is already there

           return;
       
        
            if (!buildmanager.HasMoney)//if we don't have enough money or already a turret is instantiated there
            {
                rend.material.color = warningColor;
            return;

            }

            else rend.material.color = hoverColor;//change material's color to hover color


        
        
    }

    void OnMouseDown()//on clicking once
    {
       
        if (EventSystem.current.IsPointerOverGameObject())
            return;

       
        if (turret != null)
        {
            turretBlueprint.SetNode(this);
            buildmanager.SelectedNode(this);//if turret is there pass on this node

            return;
        }

        else buildmanager.DeselectNode();


        if (!buildmanager.CanBuild)//if turret is not selected
        {
            Debug.Log("Can't build ");
            return;
        }


        if ( !buildmanager.HasMoney )// we don't have money
        {
            
            rend.material.color = warningColor;
            buildmanager.DeselectTurret();

            return;
        }

        BuildTurret(buildmanager.GetTurretToBuild());
    }

    void BuildTurret(TurretBluePrint blueprint)
    {

        if (PlayerStats.money < blueprint.cost)//if we do not have enough money
        {
            Debug.Log("Not enough Money");
            return;
        }
        turretBlueprint = blueprint;
        
        PlayerStats.money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab,GetBuildPosition(), Quaternion.identity);//instantiate turrret,quaternion identity means to retain the rotation of turret only
        turret = _turret;//filling turret value
        GameObject Buildeffect = (GameObject)Instantiate(buildmanager.buildEffect,GetBuildPosition(), buildmanager.buildEffect.transform.rotation);
        Destroy(Buildeffect, 5f);

        Debug.Log("Turret purchased!");//display money left
    }

    public void UpgradeTurret()
    {

        if (PlayerStats.money < turretBlueprint.UpgradeCost())//if we do not have enough money
        {   
            Debug.Log("Not enough Money to Upgrade turret");
            return;
        }
        PlayerStats.money -= turretBlueprint.UpgradeCost();

        Destroy(turret);
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);//instantiate turrret,quaternion identity means no rotation of turret and allign with standard axis
        turret = _turret;
        GameObject Buildeffect = (GameObject)Instantiate(buildmanager.buildEffect, GetBuildPosition(),buildmanager.buildEffect.transform.rotation );
        Destroy(Buildeffect, 3f);

        isUpgraded = true;
        Debug.Log("Turret Upgraded");//display money left
        
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.SellAmount();
        

        GameObject Destroyeffect = (GameObject)Instantiate(buildmanager.DestroyEffect, GetBuildPosition(), buildmanager.buildEffect.transform.rotation);
        Destroy(Destroyeffect, 3f);
        Destroy(turret);
        isUpgraded = false;
    }



    void OnMouseExit()//when mouse exits the collider of gameObject or the space covered by gameObeject
    {
        rend.material.color = startColor;//change color back to start color
    }



    

   
}