using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHouse : MonoBehaviour
{

	public string SceneName;
	public Locations location;

	public AudioClip DoorSound;
	private AudioSource _audioSource;

	private void Start()
	{
		_audioSource = gameObject.GetComponent<AudioSource>();

		_audioSource.loop = true;
		_audioSource.playOnAwake = true;
		_audioSource.volume = 0.3f;

		_audioSource.clip = DoorSound;

	}

	public void LoadScene() {
		_audioSource.Play();
		StartCoroutine( WaitForSound());
	}

	IEnumerator WaitForSound()
	{
		yield return new WaitForSeconds(DoorSound.length * 0.6f);
		GameLogic.Instance.Location = location;
		SceneManager.LoadScene(SceneName);
	}


}
