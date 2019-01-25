using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float DeadZoneX = 10;
	public float DeadZoneY = 5;

	private Camera _camera;
	private Transform _playerTransform;
	private Vector2 _velocity;

    // Start is called before the first frame update
    void Start()
    {
		_camera = Camera.main;
		_playerTransform = gameObject.transform;
		_camera.transform.position = _playerTransform.position;
		_camera.transform.position += new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
		//transformPoint oder inversetransformpoint
		Vector3 playerInCameraSpace = _camera.transform.InverseTransformPoint(_playerTransform.position);
		if(playerInCameraSpace.x > DeadZoneX || playerInCameraSpace.x < -DeadZoneX 
			|| playerInCameraSpace.y > DeadZoneY || playerInCameraSpace.y < -DeadZoneY)
		{
			FollowPlayer();
		}

	}


	void FollowPlayer()
	{
		_velocity *= Time.smoothDeltaTime;
		_camera.transform.position = Vector2.SmoothDamp(_camera.transform.position, _playerTransform.position, ref _velocity, 0.15f);
		_camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, -1);
	}
}
