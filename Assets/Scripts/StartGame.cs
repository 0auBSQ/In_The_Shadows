using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour, IPointerClickHandler
{
	public bool enable_test = false;
	public AudioSource audios;

	public void OnPointerClick(PointerEventData eventData) {
		audios.PlayOneShot(Master.GetM.sfx_list[3], 6f);
		Master.GetM.test_mode = enable_test;
		SceneManager.LoadScene("LevelSelect");
	}
}
