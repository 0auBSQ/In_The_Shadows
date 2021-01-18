using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
	public bool active = false;
	private bool focused = false;
	public GameObject[] sub_models;
	public Constraint constraints;
	private Ray ray;
	private RaycastHit hit;
	public bool randomise_yrot = true;
	private AudioSource audios;
	public bool satisfied = false;
	
	void Awake()
	{
		audios = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
	}
	
    void Start()
    {
        if (randomise_yrot == true) {
			transform.Rotate(0, Random.Range(-160f, 160f), 0);
		}
    }

    void Update()
    {
		satisfied = constraints.satisfied;
		
		// Only handles rotations for now, moves will be added soon for hard levels
		if (Input.GetMouseButtonDown(0) && focused == true) {
			active = true;
			RefreshMats(Master.GetM.m_list[1]);
		}
		if (Input.GetMouseButtonUp(0)) {
			active = false;
		}
		
		if (active == false) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.gameObject == this.gameObject) {
					RefreshMats(Master.GetM.m_list[2]);
					if (focused == false) {
						audios.PlayOneShot(Master.GetM.sfx_list[0], 10f);
					}
					focused = true;
				}
				else {
					RefreshMats(Master.GetM.m_list[0]);
					focused = false;
				}
			}
			else {
				RefreshMats(Master.GetM.m_list[0]);
				focused = false;
			}
		}
    }
	
	void RefreshMats(Material m) {
		foreach (GameObject g in sub_models) {
			g.GetComponent<Renderer>().material = m;
		}
	}
	
}
