using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public GameObject interactionMessage;
    public GameObject player;
    public float activationDistance = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < activationDistance)
        {
            interactionMessage.GetComponent<Text>().text = "Press A to interact.";
            interactionMessage.SetActive(true);
            gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else
        {
            interactionMessage.SetActive(false);
            interactionMessage.GetComponent<Text>().text = "";
            gameObject.transform.localScale = new Vector3(1,1, 1);
        }

    }
}
