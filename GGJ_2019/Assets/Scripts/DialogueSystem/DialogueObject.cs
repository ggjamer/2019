using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Dialogue", order = 1)]
public class DialogueObject : ScriptableObject {
	public ActorTypes actorIdentifier;
	public int index;
	
	public string PersonA;
	public Sprite PersonAImage;
	public string PersonB;
	public Sprite PersonBImage;


	[TextArea(3, 6)]
	public string[] diaglogue;

}