using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwipeMenu : MonoBehaviour
{
	// Tutorial source : https://www.youtube.com/watch?v=GURPmGoAOoM&ab_channel=AkbarProject
	
	public GameObject scrollbar;
	private float scroll_pos = 0;
	private float[] pos;
	
	public RectTransform xpos;
	private static float last_pos = 0;
	
	public TextMeshProUGUI error_msg;
	
	public GameObject background;
	private float whole_width;
	
	void Awake() {
		scrollbar.GetComponent<Scrollbar>().value = SwipeMenu.last_pos;
		scroll_pos = SwipeMenu.last_pos;
	}

	void Update() {
		whole_width = GetComponent<HorizontalLayoutGroup>().preferredWidth;
		SwipeMenu.last_pos = scrollbar.GetComponent<Scrollbar>().value;

		float hue = 240 + (((Mathf.Clamp(-2 * xpos.position.x, 0f, whole_width) + whole_width) * -240) / (1 * whole_width)) + 240;
		if (hue >= 0f && hue <= 240f) {
			background.GetComponent<RawImage>().color = Color.HSVToRGB(hue / 360f, 1f, 0.7f);
		}
		
		pos = new float[transform.childCount];
		float distance = 1f / (pos.Length - 1f);
		for (int i = 0; i < pos.Length; i++) {
			pos[i] = distance * i;
		}

		if (Input.GetMouseButton(0)) {
			scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
		}
		else {
			for (int i = 0; i < pos.Length; i++) {
				if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2)) {
					scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
				}
			}
		}

		for (int i = 0; i < pos.Length; i++) {
			if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2)) {
				if (transform.GetChild(i).GetComponent<LevelButton>().avaliable == false) {
					error_msg.text = "レベル" + string.Join("・", transform.GetChild(i).GetComponent<LevelButton>().level_requirements) + "クリア必要がある";
				}
				else {
					error_msg.text = "";
				}
				transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.1f, 1.1f), 0.1f);
				for (int j = 0; j < pos.Length; j++) {
					if (j != i) {
						transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.9f, 0.9f), 0.1f);
					}
				}
			}
		}
	}
}
