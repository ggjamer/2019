using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

	private static MusicController _instance;

	public AudioClip Music;

	private AudioSource _audioSource;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			_instance = this;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		_audioSource = gameObject.GetComponent<AudioSource>();
		_audioSource.loop = true;
		_audioSource.playOnAwake = true;
		_audioSource.volume = 0.3f;

		_audioSource.clip = Music;
		_audioSource.Play();

		DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
