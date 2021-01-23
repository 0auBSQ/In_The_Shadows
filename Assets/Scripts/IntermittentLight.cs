using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermittentLight : MonoBehaviour
{
	public Light gi;
	public Light spot;
	private float gi_max;
	private float spot_max;
	private float internal_timer = 0f;
	private float timer_thr = 1f;
	private bool asc_drop = false;
	
    void Awake() {
        gi_max = gi.intensity;
		spot_max = spot.intensity;
	}

	private void alter_lights() {
		if (asc_drop == true) {
			gi.intensity = Mathf.Clamp(gi.intensity + (Time.deltaTime * 60), 0, gi_max);
			spot.intensity = Mathf.Clamp(spot.intensity + (Time.deltaTime * 3), 0, spot_max);
		}
		else {
			gi.intensity = Mathf.Clamp(gi.intensity - (Time.deltaTime * 180), 0, gi_max);
			spot.intensity = Mathf.Clamp(spot.intensity - (Time.deltaTime * 9), 0, spot_max);
		}
		if (gi.intensity == 0f) {
			asc_drop = true;
		}
	}

    void Update() {
        internal_timer += Time.deltaTime;
		if (internal_timer > timer_thr) {
			alter_lights();
			if (gi.intensity == gi_max) {
				internal_timer = 0f;
				asc_drop = false;
				timer_thr = Random.Range(0.5f, 5f);
			}
		}
	}
}
