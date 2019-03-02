using UnityEngine;

public class thirdscreen : MonoBehaviour
{
	[SerializeField] circloscapetus[] corcl;
	[SerializeField] Material material;
	[SerializeField] GameObject hnnn;
	float[] h = new float[8];
	float tim;

	void Start()
	{
		dod(false);
	}

	void Update()
	{
		dod(true);
	}

	void dod(bool first)
	{
		if ((tim -= Time.deltaTime) <= 0)
		{
			foreach (circloscapetus egg in corcl)
				egg.flerb();

			for (int i = 0; i < h.Length; i++)
				h[i] = Random.Range(-10f, 10f);

			if (first) hnnn.SetActive(true);

			tim = 3;
		}
		if (tim <= 2.7f)
			hnnn.SetActive(false);

		float fef = Time.time * 0.005f;
		material.mainTextureOffset = new Vector2(
			Mathf.PerlinNoise(h[0] + fef, h[1]),
			Mathf.PerlinNoise(h[2] - fef, h[3])
		);
		material.mainTextureScale = new Vector2(
			Mathf.PerlinNoise(h[4], h[5] + fef),
			Mathf.PerlinNoise(h[6], h[7] - fef)
		);
	}
}
