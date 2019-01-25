using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    public float speedY = 20;
    public float speedX = 6;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            Time.deltaTime * speedX * Input.GetAxis("Horizontal"),
            Time.deltaTime * speedY * Input.GetAxis("Vertical"),
            0);

    }


}
