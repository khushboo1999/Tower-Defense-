using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;//making a copy of turretBluprint in the name  of standardTurretPrfab can be seen in the inspector 
    public TurretBluePrint missileLauncher;//making a copy just like above
    public TurretBluePrint laserBeamer;
    BuildManager buildmanager;
    
    // Use this for initialization
    void Start()
    {
        buildmanager = BuildManager.instance;
    }

    public void SelectStandardTurretItem()//called by clicking on the standard turret item button
    {
        Debug.Log("Standard Turret Purchased");
        buildmanager.SelectTurretToBuild(standardTurret);//sending standard turret to selectturrettobuild method
    }

    public void SelectMissileLauncherItem()//called by clicking on the missile launcher button
    {
        Debug.Log("Missile Launcher Purchased");
        buildmanager.SelectTurretToBuild(missileLauncher); //sending missile launcher to selectturrettobuild method

    }

    public void SelectLaserbeamerItem()//called by clicking on the laser beamer button
    {
        Debug.Log("Missile launcher Purchased");
        buildmanager.SelectTurretToBuild(laserBeamer); //sending missile launcher to selectturrettobuild method

    }
}