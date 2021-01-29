using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHandler : MonoBehaviour
{
	public ObjectHandler[] handlers;
	public int level_id;
	private bool active = true;
	private AudioSource audios;
	public TextMeshProUGUI level_nameplate;
	public string level_name;
	public LevelCountdown level_countdown;
	public float max_time;
	
	public TextMeshProUGUI failure;
	public TextMeshProUGUI clear;
	
	public GameObject victory_gfx;
	
	void Awake()
	{
		audios = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
		level_nameplate.text = level_name;
		level_countdown.c_timer = max_time / (Master.GetM.difficulty + 1);
	}
	
    void Update()
    {
		if (active == true) {
			
			// Check if level completed
			bool completed = true;
			foreach (ObjectHandler oh in handlers) {
				if (oh.satisfied == false) {
					completed = false;
				}
			}
			
			// Handle level failed event
			if (level_countdown.c_timer == 0f && completed == false) {
				foreach (ObjectHandler oh in handlers) {
					oh.active = false;
					oh.translating = false;
					oh.enabled = false;
				}
				// Display level failed msg
				failure.text = "レベル失敗\nタイムアウト";
				// Play lose sfx
				audios.clip = Master.GetM.sfx_list[5];
				audios.loop = false;
				audios.Play(0);
				level_countdown.on_going = false;
				ObjectHandler.busy = false;
				active = false;
			}
			
			// Handle level completed event
			if (completed == true) {
				foreach (ObjectHandler oh in handlers) {
					oh.active = false;
					oh.translating = false;
					oh.enabled = false;
				}
				// Display level complete msg
				clear.text = "レベル完了！";
				// Throw confetti
				GameObject vgfx = Instantiate(victory_gfx);
				Destroy(vgfx, 5f);
				audios.PlayOneShot(Master.GetM.sfx_list[6], 1f);
				// Play win sfx
				audios.clip = Master.GetM.sfx_list[4];
				audios.loop = false;
				audios.Play(0);
				level_countdown.on_going = false;
				Master.GetM.cleared_levels[level_id] = 1;
				if (Master.GetM.test_mode == false) {
					Master.SaveGame();
				}
				ObjectHandler.busy = false;
				active = false;
			}
		}
	}
}
