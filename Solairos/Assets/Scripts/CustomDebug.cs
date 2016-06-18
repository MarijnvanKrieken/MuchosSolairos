using UnityEngine;
using UnityEngine.UI;

public class CustomDebug: MonoBehaviour
{
	public Text text;

	public void AddDebug(string error)
	{
		text.text += "\n" + error;
	}

	public void Clear()
	{
		text.text = string.Empty;
	}
}
