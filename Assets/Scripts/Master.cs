using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Master : MonoBehaviour
{
	private static Master instance = null;
	public Material[] m_list;
	public AudioClip[] sfx_list;
	public int[] cleared_levels = {0};
	public bool test_mode = false;
	public uint difficulty = 0;

	public static Master GetM {
		get {
			return instance;
		}
	}
	
	public static void SaveGame() {
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/save.oof";
		FileStream stream = new FileStream(path, FileMode.Create);
		
		formatter.Serialize(stream, Master.GetM.cleared_levels);
		stream.Close();
		print("Game saved !");
	}
	
	public static void LoadGame() {
		string path = Application.persistentDataPath + "/save.oof";
		if (File.Exists(path)) {
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			int[] fetched_levels = formatter.Deserialize(stream) as int[];
			for (int i = 0; i < 20; i++) {
				Master.GetM.cleared_levels[i] = fetched_levels[i];
			}
			stream.Close();
			print("Game loaded !");
		}
		else {
			print("No save data");
		}
	}

	private void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return ;
		}
		
		instance = this;
		Master.LoadGame();
		DontDestroyOnLoad(this.gameObject);
	}

}
