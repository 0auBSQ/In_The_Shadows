using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
	public ObjectHandler[] handlers;
	public int level_id;
	private bool active = true;
	private AudioSource audios;
	
	void Awake()
	{
		audios = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
	}
	
    void Update()
    {
		if (active == true) {
			bool completed = true;
			foreach (ObjectHandler oh in handlers) {
				if (oh.satisfied == false) {
					completed = false;
				}
			}
			
			if (completed == true) {
				foreach (ObjectHandler oh in handlers) {
					oh.active = false;
					oh.translating = false;
					oh.enabled = false;
				}
				print("Level complete !");
				audios.clip = Master.GetM.sfx_list[4];
				audios.loop = false;
				audios.Play(0);
				Master.GetM.cleared_levels[level_id] = 1;
				active = false;
			}
		}
	}
}
