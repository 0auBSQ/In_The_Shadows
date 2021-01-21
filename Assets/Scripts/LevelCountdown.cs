using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCountdown : MonoBehaviour
{
	private TextMeshProUGUI timer;
	public float c_timer;
	public bool on_going = true;
    
    void Awake()
    {
        timer = GetComponent<TextMeshProUGUI>();
		timer.text = Mathf.Floor(c_timer).ToString();
    }

	void Update()
	{
		if (on_going == true) {
			c_timer -= Time.deltaTime;
			if (c_timer < 0f) {
				c_timer = 0f;
			}
			timer.text = Mathf.Floor(c_timer).ToString();
		}
	}
}
