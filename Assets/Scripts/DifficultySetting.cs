using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySetting : MonoBehaviour
{
    public TextMeshProUGUI diff;
	public Slider slider;

	private void adaptText() {
		if ((uint)slider.value == 0) {
			diff.color = new Color(0f, 1f, 1f, 1f);
			diff.text = "非常に簡単";
		}
		else if ((uint)slider.value == 1) {
			diff.color = new Color(0f, 1f, 0f, 1f);
			diff.text = "簡単";
		}
		else if ((uint)slider.value == 2) {
			diff.color = new Color(1f, 1f, 0f, 1f);
			diff.text = "普通";
		}
		else if ((uint)slider.value == 3) {
			diff.color = new Color(1f, 0.5f, 0f, 1f);
			diff.text = "難しい";
		}
		else if ((uint)slider.value == 4) {
			diff.color = new Color(1f, 0f, 0f, 1f);
			diff.text = "非常に難しい";
		}
		else {
			diff.color = new Color(0.5f, 0f, 0.5f, 1f);
			diff.text = "鬼";
		}
	}

	void Start() {
		slider.value = Master.GetM.difficulty;
		this.adaptText();
	}

    void Update() {
		Master.GetM.difficulty = (uint)slider.value;
		this.adaptText();
    }
}
