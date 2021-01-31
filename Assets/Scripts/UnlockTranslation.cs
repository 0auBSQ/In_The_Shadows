using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTranslation : MonoBehaviour
{
    private GameObject MainCamera;
	public float speed = 10.0f;
	public bool xAxis = true;
	public bool yAxis = true;

	void Awake ()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
		if (GetComponent<ObjectHandler>().active == true && GetComponent<ObjectHandler>().translating == true) {
			float xRate = Input.GetAxis("Mouse X") * speed;
			float yRate = Input.GetAxis("Mouse Y") * speed;
			Vector3 current = transform.position;
			if (xAxis == false) {
				xRate = 0;
			}
			if (yAxis == false) {
				yRate = 0;
			}
			transform.Translate(new Vector3(xRate, yRate, 0) / 60f, Space.World);
			
			float xPos = Mathf.Clamp(transform.position.x, -3, 3);
			float yPos = Mathf.Clamp(transform.position.y, -3, 3);
			transform.position = new Vector3(xPos, yPos, transform.position.z);
		}
    }
}
