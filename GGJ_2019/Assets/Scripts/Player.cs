using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Actor {
    private string _name;
    private Sprite _sprite;
   
    public float speedX = 20;
    public float speedY = 6;

    private bool _inDoorRange = false;
    private LoadHouse _houseInRange;

    
    public void SetParams(string name, Sprite sprite) {
        _name = name;
        _sprite = sprite;
    }
    public void Init() {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = _sprite;
    }
 
    // Start is called before the first frame update
    void OnEnable()
    {
        gameObject.transform.position = GameLogic.Instance.PlayerPosition;
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
            GameLogic.Instance.PlayerPosition = gameObject.transform.position;
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
