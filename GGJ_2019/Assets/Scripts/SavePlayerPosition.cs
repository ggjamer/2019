using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPosition : MonoBehaviour
{

	private static SavePlayerPosition _instance;

	public Vector3 _playerPosition;


    void Awake()
    {
		if(_instance != null && _instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			_instance = this;
			_playerPosition = new Vector3(-22.0f, -19.0f, 0);
		}
		DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetPosition(Vector3 position)
	{
		_playerPosition = position;
	}

	public Vector3 GetPosition()
	{
		return _playerPosition;
	}
}
