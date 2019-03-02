using UnityEngine.UI;
using UnityEngine;

public class letterino : MonoBehaviour
{
	public Image bob;

	void Update()
	{
		transform.localPosition = new Vector3(Mathf.Clamp(((Input.mousePosition.x - Camera.main.pixelRect.xMin) / Mathf.Min(Screen.width, Screen.height) - 0.5f) * 500, -175, 175), 0, 0);
	}
}
