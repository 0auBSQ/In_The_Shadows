using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraint : MonoBehaviour
{
	public Vector3 rotationConstraints;
	public Vector3 rotationLeniency;
	private bool rotationSatisfied = false;
	public bool satisfied = false;

    void Update()
    {
		// Rotation constraints
        Vector3 current = transform.eulerAngles;
		if (Mathf.Abs(current.y - rotationConstraints.y) <= rotationLeniency.y
			&& Mathf.Abs(current.x - rotationConstraints.x) <= rotationLeniency.x) {
			rotationSatisfied = true;
		}
		else {
			rotationSatisfied = false;
		}
		
		// Check all constraints (Move and Link constraints comming soon)
		if (rotationSatisfied == true) {
			satisfied = true;
		}
		else {
			satisfied = false;
		}
    }
}
