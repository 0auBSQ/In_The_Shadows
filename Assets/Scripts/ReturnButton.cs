using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnButton : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData) {
		SceneManager.LoadScene("LevelSelect");
	}
}
