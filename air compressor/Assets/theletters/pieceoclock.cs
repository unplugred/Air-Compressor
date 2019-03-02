using UnityEngine;

public class pieceoclock : MonoBehaviour
{
	[SerializeField] Transform henlothere;
	[SerializeField] GameObject endingo;
	Vector3 startpos;
	float startrot;
	float tim = 0.5f;
	static int num;
	[SerializeField] AudioSource hecky;
	readonly float[] pitches = new float[] { 1.6f, 1.92f, 1.38f, 0.87f };

	void Start()
	{
		startpos = henlothere.transform.localPosition;
		startrot = henlothere.transform.localEulerAngles.z;
		henlothere.transform.localPosition = Vector3.zero;
		henlothere.transform.localEulerAngles = Vector3.zero;

		if (startrot > 180)
			startrot -= 360;
	}

	void Update()
	{
		tim = Mathf.Lerp(tim, 2f, Time.deltaTime * 0.1f);
		henlothere.transform.localPosition = startpos * tim;
		henlothere.transform.localEulerAngles = new Vector3(0, 0, startrot * tim);
	}

	void OnMouseDown()
	{
		//hecky.pitch = Random.Range(0.5f, 2f);
		hecky.pitch = pitches[num];
		hecky.Play();
		if (++num == 4)
			endingo.SetActive(true);
		gameObject.SetActive(false);
	}
}
