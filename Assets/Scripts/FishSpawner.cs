using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
	private float internalTimer = 0f;
	private float spawnTimer;
	public GameObject[] fishArr;
	
    void Awake()
    {
        spawnTimer = Random.Range(2f, 6f);
    }

    void Update()
    {
        internalTimer += Time.deltaTime;
		if (internalTimer >= spawnTimer) {
			internalTimer = 0f;
			spawnTimer = Random.Range(3f, 9f);
			int fish = Random.Range(0, 7);
			Instantiate(fishArr[fish], transform.position, transform.rotation);
		}
    }
}
