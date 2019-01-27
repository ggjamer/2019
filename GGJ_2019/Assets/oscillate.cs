using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillate : MonoBehaviour
{
    
    private float time = 0;
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.fixedDeltaTime;
        gameObject.transform.localPosition = new Vector3((float) (Math.Sin(time*speed) * 7 ),0,0);
    }
}
