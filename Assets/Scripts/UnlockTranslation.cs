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
			transform.Translate(new Vector3(xRate, yRate, 0) * Time.deltaTime, Space.World);
		}
    }
}
