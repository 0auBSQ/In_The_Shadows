using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHandler : MonoBehaviour
{
	public float rotateSpeed = 3f;
	public float moveSpeed = 1f;
	private bool swimming = true;
	private float despawnTimer;
	private float internalTimer = 0f;
	private Quaternion qTmp;
	
	void Awake() {
		qTmp = Quaternion.Euler(new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)));
		despawnTimer = Random.Range(10f, 30f);
	}
	
    void Update() {
        internalTimer += Time.deltaTime;
		despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0f)
			qTmp = Quaternion.Euler(0f, 180f, 0f);
		if (internalTimer >= 3f) {
			swimming = !swimming;
			if (swimming)
				qTmp = Quaternion.Euler(new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)));
			internalTimer = 0f;
		}
		transform.rotation = Quaternion.Slerp(transform.rotation, qTmp, rotateSpeed * Time.deltaTime);
		if (swimming) {
			Vector3 movement = transform.rotation * Vector3.forward;
			transform.position += movement * moveSpeed * Time.deltaTime;
			Mathf.Clamp(transform.position.z, -50f, 9f);
			Mathf.Clamp(transform.position.y, -6.5f, 10f);
			Mathf.Clamp(transform.position.x, -3f, 30f);
			if (transform.position.z < -10f)
				Destroy(gameObject);
		}
    }
}
