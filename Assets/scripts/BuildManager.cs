using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance; //creating an object for this script to call it

    public GameObject buildEffect;
    public GameObject DestroyEffect;

    public NodeUI nodeUI;

    private node selectedNode;
    private TurretBluePrint turretToBuild ;

    // Use this for initialization
    void Awake()
    {
        if (instance != null)//checking if there are more than one buildmanager
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;//giving instance a value which used by other scripts
        
    }

    

    
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }
    //check the condition of turrettobuild and if it's true then return true and set void HasMoney as true


    public void SelectedNode(node node)//called by node script mouse down function
    {
        if (selectedNode == node)//if we clicked the same node
        {
            DeselectNode();
            return;
        }

        turretToBuild = null;//since we don't want to select turret and node at the same time
        selectedNode = node;

        nodeUI.SetTarget(node);//send this node to nodeUI script

    }

    public bool CanBuild { get { return turretToBuild != null; } }
    //check the condition of turrettobuild and if it's true then return true and set CanBuild void as true


    public void SelectTurretToBuild(TurretBluePrint turret)//called by shop script
    {
        turretToBuild = turret;
        DeselectNode();
    }
    

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }


    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void DeselectTurret()
    {
        turretToBuild = null;
    }
}
   
