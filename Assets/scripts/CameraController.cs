using UnityEngine;

public class CameraController : MonoBehaviour {

  
    public float panSpeed = 30f;
    public float panBorderthickness = 20f;
    public float scrollSpeed = 3f;
    public float minY = 30f;
    public float maxY = 130f;
    private float minX = -10f;
    private float maxX = 40f;
    private float minZ = -50f;
    private float maxZ = 30f;
    private bool DoMovement = true;

		
	// Update is called once per frame
	void Update () {

        
        if (GameManager.gameIsOver)
        {
            this.enabled = false; // or enabled = false or code will run without writing any of enabled statement
            return;
        }

        if (Input.GetKey("n"))
            DoMovement = !DoMovement;

        if (!DoMovement)
            return;


		if(Input.GetKey("w")|| Input.mousePosition.y>= Screen.height - panBorderthickness)//when w key is pressed or mouse is on top move up
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);//vector 3.forward is equivanlent to new vector3(of,of,1f) 
        }
        if (Input.GetKey("s")|| Input.mousePosition.y <= panBorderthickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
       if (Input.GetKey("d")|| Input.mousePosition.x >= Screen.width - panBorderthickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
       if (Input.GetKey("a")|| Input.mousePosition.x <= panBorderthickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
       
        Vector3 pos = transform.position;
        pos.y -= scroll*scrollSpeed *1000* Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;

    }
}
