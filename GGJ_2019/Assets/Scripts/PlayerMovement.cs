using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class PlayerMovement : MonoBehaviour
{
	public float speedX = 20;
    public float speedY = 6;

	private bool _inDoorRange = false;
	public SavePlayerPosition _savePlayerPosition;

	private LoadHouse _houseInRange;

    // Start is called before the first frame update
    void OnEnable()
    {
		_savePlayerPosition = GameObject.FindObjectOfType<SavePlayerPosition>();
		gameObject.transform.position = _savePlayerPosition.GetPosition();
		Debug.Log(_savePlayerPosition.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.MovePosition(rigidbody.position + new Vector2(
            Time.deltaTime * speedX * Input.GetAxis("Horizontal"), 
            Time.deltaTime * speedY * Input.GetAxis("Vertical")));


		if(_houseInRange && Input.GetButtonDown("Jump"))
		{
			_savePlayerPosition.SetPosition(gameObject.transform.position);
			Debug.Log(_savePlayerPosition.GetPosition());
			_houseInRange.LoadScene();
		}
    }




	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.tag == "Door")
		{
			Debug.Log("At door");
			_houseInRange = collision.GetComponent<LoadHouse>();
		}

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.tag == "Door")
		{
			_houseInRange = null;
		}
	}

}
