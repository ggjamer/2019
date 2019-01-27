using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject logic = GameObject.Find("GAME_LOGIC");
        Destroy(logic);
    }

}
