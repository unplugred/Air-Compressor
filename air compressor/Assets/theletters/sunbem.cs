using UnityEngine;

public class sunbem : MonoBehaviour
{
	[SerializeField] GameObject trail;
	[SerializeField] GameObject croncle;
	[SerializeField] AnimationCurve cruve;
	[SerializeField] Transform go;
	[SerializeField] AnimationCurve rot;
	[SerializeField] AnimationCurve pos;
	[SerializeField] Transform got;
	[SerializeField] GameObject all;
	[SerializeField] GameObject nothing;
	[SerializeField] MeshRenderer clocl;
	[SerializeField] MeshFilter clockinside;
	[SerializeField] Mesh[] h;
	float tim;
	int state;

	int[,] timings = { { 10, 7, 6, 5, 4, 3, 0 }, { 1, 0, 1, 2, 0, 3, -1 } };

	void Start()
	{
		for (int t = 1; t < 12; t++)
			Instantiate(trail, transform).transform.localEulerAngles = new Vector3(0, 0, 30 * t);
	}

	void Update()
	{
		tim += Time.deltaTime;

		float s = tim * 0.3f;
		transform.localScale = new Vector3(s, s, s);
		transform.localEulerAngles = new Vector3(0, 0, Mathf.Sin(tim) * 4);
		s = cruve.Evaluate(tim * 0.05f) * 3.8f;
		croncle.transform.localScale = new Vector3(s, s, s);
		s = tim * 0.1f;
		go.Rotate(0, 0, rot.Evaluate(s) * 0.2f);
		go.position = Vector3.MoveTowards(go.position, got.position, pos.Evaluate(s) * 0.05f);

		if (tim >= 21.5f - timings[0, state] * 0.1f)
		{
			if (timings[1, state] == -1)
			{
				nothing.SetActive(true);
				all.SetActive(false);
			}
			else
			{
				clocl.enabled = false;
				clockinside.mesh = h[timings[1, state++]];
			}
		}
	}
}
