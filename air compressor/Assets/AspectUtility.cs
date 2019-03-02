using UnityEngine;

public class AspectUtility : MonoBehaviour
{
	[SerializeField] Camera cam;
	Vector2 screenres;

	void Awake()
	{
		cam = GetComponent<Camera>();
		screenres = new Vector2(Screen.height, Screen.width);
		SetCamera();
	}

	void Update()
	{
		Vector2 currentscreenres = new Vector2(Screen.height, Screen.width);
		if (screenres != currentscreenres)
		{
			screenres = currentscreenres;
			SetCamera();
		}
	}

	void SetCamera()
	{
		float currentAspectRatio = (float)Screen.width / Screen.height;
		if ((int)(currentAspectRatio * 100) / 100f == 1)
		{
			cam.rect = new Rect(0, 0, 1, 1);
			return;
		}
		if (currentAspectRatio > 1)
		{
			float inset = 1 / currentAspectRatio;
			cam.rect = new Rect(0.5f - inset * 0.5f, 0, inset, 1);
		}
		else
		{
			cam.rect = new Rect(0, 0.5f - currentAspectRatio * 0.5f, 1, currentAspectRatio);
		}
	}
}