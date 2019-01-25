using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            Time.deltaTime * speed * Input.GetAxis("Horizontal"),
            Time.deltaTime * speed * Input.GetAxis("Vertical"),
            0);

    }


}
