﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	public float DeadZoneX = 10;
	public float DeadZoneY = 5;

	private Vector3[] _housePositions;

	private Camera _camera;
	private Transform _playerTransform;
	private Vector2 _velocity;
	private float _zommVelocity;

	public float HouseCameraSize = 10;
	public float HouseZoomDistance = 10;

	private bool triggerControlled = false;

	private float _defaultCameraSize;
	private Vector3 lastPlayerPosition;

	private IEnumerator moveToHouse;

	// Start is called before the first frame update
	void Start()
	{

		_camera = Camera.main;
		_defaultCameraSize = _camera.orthographicSize;


		_playerTransform = gameObject.transform;
		lastPlayerPosition = _playerTransform.position;

		if (GameLogic.Instance.Location == Locations.OUTSIDE)
		{
			_camera.transform.position = _playerTransform.position;
			_camera.transform.position += new Vector3(0, 0, -1);
		}
		
		GameObject[] houses;
		houses = GameObject.FindGameObjectsWithTag("HousePosition");

		_housePositions = new Vector3[houses.Length];
		for (int i = 0; i < houses.Length; i++)
		{
			_housePositions[i] = houses[i].transform.position;
		}

	}


	// Update is called once per frame
	void Update() //TODO: weniger kamerabewegung weil ruckeln
	{
		if (GameLogic.Instance.Location == Locations.OUTSIDE)
		{
			if (!triggerControlled)
			{
				Vector3 playerInCameraSpace = _camera.transform.InverseTransformPoint(_playerTransform.position);
				if (playerInCameraSpace.x > DeadZoneX || playerInCameraSpace.x < -DeadZoneX
					|| playerInCameraSpace.y > DeadZoneY || playerInCameraSpace.y < -DeadZoneY)
				{
					FollowPlayer();
				}

				if (lastPlayerPosition == _playerTransform.position)
				{
					FollowPlayer();
				}

				lastPlayerPosition = _playerTransform.position;
			}


			UpdateCameraSize();


		}

	}


	void FollowPlayer()
	{
		_velocity *= Time.smoothDeltaTime;
		_camera.transform.position = Vector2.SmoothDamp(_camera.transform.position, _playerTransform.position, ref _velocity, 0.25f);
		_camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, -1);
	}



	void UpdateCameraSize()
	{
		for (int i = 0; i < _housePositions.Length; i++)
		{
			if (Vector2.Distance(_housePositions[i], _playerTransform.position) < HouseZoomDistance)
			{
				
				float distance = Vector2.Distance(_playerTransform.position, _housePositions[i]);
				distance = (distance / HouseZoomDistance);
				_camera.orthographicSize = Mathf.Lerp(HouseCameraSize, _defaultCameraSize, distance);
				

				//_zommVelocity *= Time.smoothDeltaTime;
				//_camera.orthographicSize = Mathf.SmoothDamp(HouseCameraSize, _defaultCameraSize, ref _zommVelocity, 0.25f);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "HousePosition")
		{
			triggerControlled = true;
			moveToHouse = LookAtHouse(collision);
			StartCoroutine(moveToHouse);
		}
		//Debug.Log("enterd house zone");
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "HousePosition")
		{
			StopCoroutine(moveToHouse);
			triggerControlled = false;
			//Debug.Log("exited house zone");
		}
	}

	IEnumerator LookAtHouse(Collider2D collision)
	{

		while(Vector3.Distance(collision.transform.position, _camera.transform.position) > 1.5)
		{
			_velocity *= Time.smoothDeltaTime;
			_camera.transform.position = Vector2.SmoothDamp(_camera.transform.position, collision.transform.position, ref _velocity, 0.25f);
			_camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, -1);
			yield return new WaitForSeconds(0.015f);
		}
	}
}
