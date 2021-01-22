using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraint : MonoBehaviour
{
	public Vector3 rotationConstraints;
	public Vector3 rotationLeniency;
	public Vector3[] attachConstraints;
	public Vector3[] attachLeniency;
	public GameObject[] attachObjects;
	private bool rotationSatisfied = false;
	private bool positionSatisfied = false;
	public bool satisfied = false;

    void Update()
    {
		// Rotation constraints
        Vector3 current_r = transform.eulerAngles;
		if (Mathf.Abs(Mathf.DeltaAngle(current_r.y, rotationConstraints.y)) <= rotationLeniency.y
			&& Mathf.Abs(Mathf.DeltaAngle(current_r.x, rotationConstraints.x)) <= rotationLeniency.x
			&& Mathf.Abs(Mathf.DeltaAngle(current_r.z, rotationConstraints.z)) <= rotationLeniency.z) {
			rotationSatisfied = true;
		}
		else {
			rotationSatisfied = false;
		}
		
		// Attach constraints
		int i = 0;
		positionSatisfied = true;
		foreach (GameObject g in attachObjects) {
			Vector3 current = transform.position;
			Vector3 relative = g.transform.position;
			float yrange = current.y - relative.y;
			float xrange = current.x - relative.x;
			if (!(Mathf.Abs(yrange - attachConstraints[i].y) <= attachLeniency[i].y
				&& Mathf.Abs(xrange - attachConstraints[i].x) <= attachLeniency[i].x)) {
				positionSatisfied = false;
			}
			i++;
		}
		
		// Check all constraints
		if (rotationSatisfied && positionSatisfied) {
			satisfied = true;
		}
		else {
			satisfied = false;
		}
    }
}
