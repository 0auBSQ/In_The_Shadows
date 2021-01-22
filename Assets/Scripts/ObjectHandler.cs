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
	public bool randomise_xrot = true;
	public bool randomise_ypos = false;
	public bool randomise_xpos = false;
	private AudioSource audios;
	public bool satisfied = false;
	public bool translating = false;
	// Only one object can be selected at the same time, assigned checks if the given object is set, busy checks if the user selected an object
	public static bool busy = false;
	public bool assigned = false;
	
	void Awake()
	{
		audios = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
	}
	
    void Start()
    {
        if (randomise_yrot == true) {
			transform.Rotate(0, Random.Range(-160f, 160f), 0, Space.World);
		}
		if (randomise_xrot == true) {
			transform.Rotate(Random.Range(-160f, 160f), 0, 0, Space.World);
		}
		if (randomise_ypos == true) {
			transform.position = new Vector3(transform.position.x, Random.Range(-3f, 3f), 0);
		}
		if (randomise_xpos == true) {
			transform.position = new Vector3(Random.Range(-3f, 3f), transform.position.y, 0);
		}
    }

    void Update()
    {
		satisfied = constraints.satisfied;
		translating = Input.GetKey(KeyCode.LeftControl);
		
		if (ObjectHandler.busy == false || assigned == true) {
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
						ObjectHandler.busy = true;
						assigned = true;
						focused = true;
					}
					else {
						RefreshMats(Master.GetM.m_list[0]);
						ObjectHandler.busy = false;
						assigned = false;
						focused = false;
					}
				}
				else {
					RefreshMats(Master.GetM.m_list[0]);
					ObjectHandler.busy = false;
					assigned = false;
					focused = false;
				}
			}
		}
    }
	
	void RefreshMats(Material m) {
		foreach (GameObject g in sub_models) {
			g.GetComponent<Renderer>().material = m;
		}
	}
	
}
