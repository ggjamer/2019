using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Dialogue", order = 1)]
public class DialogueObject : ScriptableObject
{

	public string PersonA;
	public string PersonB;

	[TextArea(3, 6)]
	public string[] diaglogue;

}