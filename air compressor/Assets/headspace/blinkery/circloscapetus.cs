using UnityEngine;

public class circloscapetus : MonoBehaviour
{
	float[] h = new float[6];
	[SerializeField] abstractshifter hh;

	void Update()
	{
		move();

		if (Input.GetMouseButtonDown(0))
			if (ScreenCapture.CaptureScreenshotAsTexture().GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y - Screen.height) == Color.red)
				hh.DoTheThingy();
	}

	public void flerb()
	{
		for (int i = 0; i < h.Length; i++)
			h[i] = Random.Range(-10f, 10f);

		move();
	}

	void move()
	{
		transform.localPosition = new Vector3(
			Mathf.PerlinNoise(h[0] + Time.time, h[1]) - 0.5f,
			Mathf.PerlinNoise(h[2] - Time.time, h[3]) - 0.5f,
			Mathf.PerlinNoise(h[4], h[5] + Time.time) * 2 - 1) * 10;
	}
}
