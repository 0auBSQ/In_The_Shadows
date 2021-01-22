using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
	public string level_scene;
	public int level_index;
	public int[] level_requirements;
	private bool avaliable = true;

    void Start()
    {
        foreach (int lr in level_requirements) {
			if (Master.GetM.cleared_levels[lr] == 0) {
				avaliable = false;
			}
		}
		if (avaliable == false) {
			GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
		}
		if (Master.GetM.cleared_levels[level_index] == 0) {
			transform.Find("Medal").gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
		}
		GetComponent<Button>().onClick.AddListener(ClickEvent);
    }
	
	void ClickEvent() {
		print("cliqued");
		if (avaliable == true) {
			SceneManager.LoadScene(level_scene);
		}
	}
	
    void Update()
    {
        
    }
}
