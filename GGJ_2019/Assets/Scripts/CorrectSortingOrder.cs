using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectSortingOrder : MonoBehaviour
{

	public int sortingLayer = 1000;

	private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
		_spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		_spriteRenderer.sortingOrder = sortingLayer - (int)gameObject.transform.position.y;
    }
}
