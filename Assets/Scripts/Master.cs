using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
	private static Master instance = null;
	public Material[] m_list;
	public AudioClip[] sfx_list;
	public int[] cleared_levels = {0};
	public bool test_mode = false;

	public static Master GetM
	{
		get {
			return instance;
		}
	}

	private void Awake()
	{
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return ;
		}
		
		instance = this;
		DontDestroyOnLoad(this.gameObject);
     }

}
