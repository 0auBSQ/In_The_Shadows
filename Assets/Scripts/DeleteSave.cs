using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.EventSystems;
using UnityEngine;

public class DeleteSave : MonoBehaviour, IPointerClickHandler
{
	public AudioSource audios;

    public void OnPointerClick(PointerEventData eventData) {
		audios.PlayOneShot(Master.GetM.sfx_list[1], 6f);
		Master.DeleteSave();
	}
}
