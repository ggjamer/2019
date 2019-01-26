using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHouse : MonoBehaviour
{

	public string SceneName;
	public Locations location;

	public void LoadScene() {
		GameLogic.Instance.Location = location;
		SceneManager.LoadScene(SceneName);
	}
}
