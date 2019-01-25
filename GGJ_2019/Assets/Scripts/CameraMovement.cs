using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	private Camera _camera;
	private Vector3 playerPosition = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
		_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {




		if(Input.GetKey(KeyCode.D))
		{
			playerPosition = new Vector3(playerPosition.x + 5 * Time.deltaTime, playerPosition.y, playerPosition.z);
			//Debug.Log(playerPosition);
		}

		_camera.transform.position = Vector3.Lerp(playerPosition, _camera.transform.position, 1);
		Debug.Log(Vector3.Lerp(playerPosition, _camera.transform.position, 1));
	}
}
