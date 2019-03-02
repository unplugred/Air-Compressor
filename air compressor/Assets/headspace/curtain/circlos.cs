using UnityEngine;

public class circlos : MonoBehaviour
{
	[SerializeField] abstractshifter h;
	[SerializeField] movebg tex;
	float camthing;
	Vector2 cleanx;

	void Start()
	{
		camthing = Camera.main.orthographicSize;
	}

	void Update()
	{
		cleanx = new Vector3(
			Mathf.Floor(cleanx.x) + (((Time.time - Time.deltaTime) * 0.5f) % 1) + (Time.deltaTime * 0.5f),
			cleanx.y + (Mathf.PerlinNoise(Time.time * tex.scale * 10, -10.35f) - 0.5f) * Time.deltaTime * 10);
		if (Mathf.Abs(transform.position.y) > camthing + transform.localScale.y * 0.5f)
			cleanx = new Vector2(Random.Range(-5, 2) + cleanx.x % 1, cleanx.y + (10 + transform.localScale.y) * (cleanx.y > 0 ? -1 : 1));
		Vector2 v3r = cleanx / (camthing * 2) + new Vector2(0.5f, 0.5f);
		Vector2 v3l = (cleanx - new Vector2(0.5f, 0)) / (camthing * 2) + new Vector2(0.5f, 0.5f);
		float right = Mathf.Clamp01(tex.noiseTex.GetPixelBilinear(v3r.x, 1 - v3r.y).r);
		float left = Mathf.Clamp01(tex.noiseTex.GetPixelBilinear(v3l.x, 1 - v3l.y).r);
		float size = 1 + (right - left) * camthing * 3;
		transform.position = new Vector3(cleanx.x + tex.amount * (left + right - 1) * camthing * 0.5f, cleanx.y, 0);
		transform.localScale = new Vector3(size, size, size);

		if (Input.GetMouseButtonDown(0))
			if (ScreenCapture.CaptureScreenshotAsTexture().GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y - Screen.height) == Color.red)
				h.DoTheThingy();
	}
}
