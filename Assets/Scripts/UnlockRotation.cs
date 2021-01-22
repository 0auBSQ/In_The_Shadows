using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRotation : MonoBehaviour
{
	private GameObject MainCamera;
	public float speed = 200.0f;
	public bool xAxis = true;
	public bool yAxis = true;

	void Awake ()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
		if (GetComponent<ObjectHandler>().active == true && GetComponent<ObjectHandler>().translating == false) {
			float xRate = -Input.GetAxis("Mouse X") * speed;
			float yRate = Input.GetAxis("Mouse Y") * speed;
			if (xAxis == false) {
				xRate = 0;
			}
			if (yAxis == false) {
				yRate = 0;
			}
			// If only Yaxis rotation is allowed, rotation is world space, else rotation follow camera axis
			if (xAxis == true) {
				transform.Rotate(new Vector3(0.4f * yRate, xRate, -0.6f * yRate) * Time.deltaTime, Space.World);
			}
			else {
				transform.Rotate(new Vector3(yRate, xRate, 0) * Time.deltaTime, Space.World);
			}
		}
    }
}
