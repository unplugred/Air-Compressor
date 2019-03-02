using UnityEngine.UI;
using UnityEngine;

public class blobclick : MonoBehaviour
{
	[Header("Blob")]
	[SerializeField] AnimationCurve size;
	[SerializeField] AnimationCurve amnt;
	float tim = 1000;
	float scale;
	[SerializeField] AudioClip[] borito;
	[SerializeField] AudioSource sauce;
	[SerializeField] AudioClip[] korito;
	[SerializeField] AudioSource bauce;

	[Header("Other")]
	[SerializeField] Transform rotatocubothing;

	[Header("Countdown")]
	[SerializeField] henlothere[] hi;
	float timmy;
	int lvl;
	float counter;

	void Start()
	{
		counter = hi[lvl].timing;
		scale = transform.localScale.x;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ScreenCapture.CaptureScreenshotAsTexture().GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y - Screen.height) == Color.red)
			{
				scale = Mathf.Min(scale, transform.localScale.x);
				tim = 0;
				sauce.clip = borito[Random.Range(0, borito.Length)];
				sauce.pitch = Random.Range(0.5f, 1.5f);
				sauce.volume = scale;
				sauce.Play();
				bauce.clip = korito[Random.Range(0, korito.Length)];
				sauce.pitch = Random.Range(0.8f, 1.2f);
				bauce.Play();
			}
		}

		tim += Time.deltaTime;
		halfblob.mult = amnt.Evaluate(tim);
		float scl = size.Evaluate(tim) * scale;
		transform.localScale = new Vector3(scl, scl, scl);

		if (scale <= 0.5f)
		{
			rotatocubothing.Rotate(0, Time.deltaTime * 45, 0, Space.Self);

			timmy += Time.deltaTime;
			if (timmy >= counter)
			{
				timmy -= counter;
				hi[lvl].obj.SetActive(true);
				lvl++;
				if (hi[lvl].timing >= 0)
					counter = hi[lvl].timing;
			}
		}
	}
}

[System.Serializable]
public struct henlothere
{
	public GameObject obj;
	public float timing;
}