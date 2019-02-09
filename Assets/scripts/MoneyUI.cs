using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour {
    public Text money;
		
	// Update is called once per frame
	void Update () {
        money.text ="₹"+ PlayerStats.money;//can add convert to string also but unity implicitly do it when we added a string containg rupee symbol
	}
}
