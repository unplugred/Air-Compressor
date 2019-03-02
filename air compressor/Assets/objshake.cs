using UnityEngine;

public class objshake : MonoBehaviour
{
	public float shakeamount = 0.15f;
	Vector3 startpos;

	void Start()
	{
		startpos = transform.localPosition;
	}

	void Update()
	{
		transform.localPosition = startpos + new Vector3(
			Random.value - 0.5f,
			Random.value - 0.5f,
			Random.value - 0.5f) * shakeamount;
	}
}
