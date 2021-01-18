using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRotation : MonoBehaviour
{
	private GameObject MainCamera;
	public float speed = 120.0f;
	public bool xAxis = true;
	public bool yAxis = true;

	void Awake ()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
		if (GetComponent<ObjectHandler>().active == true) {
			float xRate = -Input.GetAxis("Mouse X") * speed;
			float yRate = Input.GetAxis("Mouse Y") * speed;
			if (xAxis == false) {
				xRate = 0;
			}
			if (yAxis == false) {
				yRate = 0;
			}
			transform.Rotate(new Vector3(yRate, xRate, 0) * Time.deltaTime, Space.World);
		}
    }
}
