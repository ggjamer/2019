using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMap : MonoBehaviour
{

	private string _mapName;

    // Start is called before the first frame update
    void Start()
    {
		_mapName = GameObject.Find("GAME_LOGIC(Clone)").GetComponent<GameLogic>().initScene;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
		{
			//SceneManager.LoadScene("Tranquil_Fenja");
			GameLogic.Instance.Location = Locations.OUTSIDE;
			SceneManager.LoadScene(_mapName);
		}
    }
}
