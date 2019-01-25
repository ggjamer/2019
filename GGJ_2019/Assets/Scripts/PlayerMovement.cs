using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    public float speedX = 20;
    public float speedY = 6;


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
    }
}
