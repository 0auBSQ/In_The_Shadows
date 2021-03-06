﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
	public string level_scene;
	public int level_index;
	public int[] level_requirements;
	public bool avaliable = true;
	private AudioSource audios;

	void Awake()
	{
		audios = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
	}
	
    void Start()
    {
		// Check if requirements are satisfied
        foreach (int lr in level_requirements) {
			if (Master.GetM.cleared_levels[lr - 1] == 0) {
				avaliable = false;
			}
		}
		// All level are unlocked if test mode is on
		if (Master.GetM.test_mode == true) {
			avaliable = true;
		}
		// Gray-ish the button if the level isn't unlocked
		if (avaliable == false) {
			GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
		}
		// Medal and image appears only if the level is cleared
		if (Master.GetM.cleared_levels[level_index] == 0) {
			transform.GetChild(2).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
		}
		else {
			transform.GetChild(1).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
		}
		GetComponent<Button>().onClick.AddListener(ClickEvent);
    }
	
	void ClickEvent() {
		if (avaliable == true) {
			SceneManager.LoadScene(level_scene);
			audios.PlayOneShot(Master.GetM.sfx_list[3], 6f);
		}
		else {
			audios.PlayOneShot(Master.GetM.sfx_list[2], 6f);
		}
	}
	
    void Update()
    {
        
    }
}
