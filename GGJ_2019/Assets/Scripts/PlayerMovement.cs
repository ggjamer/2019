using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speedX = 20;
    public float speedY = 6;

	private bool inDoorRange = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.MovePosition(rigidbody.position + new Vector2(
            Time.deltaTime * speedX * Input.GetAxis("Horizontal"), 
            Time.deltaTime * speedY * Input.GetAxis("Vertical")));


		if(Input.GetButtonDown("Jump"))
		{
			Debug.Log("house entered");
			SceneManager.LoadScene("verlust_robert");
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Door")
		{
			Debug.Log("At door");
			inDoorRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.tag == "Door")
		{
			inDoorRange = false;
		}
	}

}
