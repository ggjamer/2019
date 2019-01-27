using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Well : MonoBehaviour
{
    
    private float activationDistance = 3;
    private float duration = 1.0f;

    public Image polaroid;
    
    
    private double animTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        
        if (animTime > 0)
        {
            animTime += Time.deltaTime;
            float i = (float) Math.Min(duration, animTime)/duration;
            polaroid.gameObject.SetActive(true);
            polaroid.transform.localScale = new Vector3(i*3,i*3,i*3);
            polaroid.transform.localRotation = Quaternion.Euler(
                (float) i*80-70,
                (float) i*90-90,
                (float) i*40-20);
            
            
            if (animTime >= 7)
            {
                polaroid.gameObject.SetActive(false);
                animTime = 0;
            }
        }
        else
        {
            if (Vector3.Distance(GameLogic.Instance.player.transform.position, this.transform.position) < activationDistance
                && Input.GetButtonDown("Jump")) {
                animTime += Time.deltaTime;
            }
        }
    }

   
}
