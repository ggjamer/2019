using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour {

    public GameObject dialogueSystem;
    private GameObject dsObj;
    private DialogueSystem system;

    public DialogueObject[] objs;

    private DialogueObject current;
    private int idx = 0;
    // Start is called before the first frame update
    void Start() {
        dsObj = Instantiate(dialogueSystem);
        system = dsObj.GetComponent<DialogueSystem>();
        system.finished = true;
		GameObject music = GameObject.Find("Music");
		music.GetComponent<MusicController>().PlayFinaleMusic();

    }

    void Update() {
        if (idx < objs.Length) {
            current = objs[idx];
            if (system.finished) {
                Debug.Log(idx);
                system.StartDialogue(current);
				system.FinalDialogue();
                idx++;
            }
        }
        else {
            SceneManager.LoadScene("EndScene");
        }
    }


}
