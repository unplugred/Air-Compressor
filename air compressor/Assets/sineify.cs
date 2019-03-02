using UnityEngine;

public class sineify : MonoBehaviour
{
	[SerializeField]
	bool rotation = true;
	[SerializeField] Vector3 offset;
	[SerializeField] bool randomizeOffset = true;
	[SerializeField] Vector3 speed;
	[SerializeField] Vector3 amount;
	Vector3 start;
	float time;

	void Start()
	{
		if (rotation) start = transform.localEulerAngles;
		else start = transform.localPosition;
		if (randomizeOffset) offset = new Vector3(
			 Random.Range(0f, Mathf.PI),
			 Random.Range(0f, Mathf.PI),
			 Random.Range(0f, Mathf.PI));
	}

	void Update()
	{
		time += Time.deltaTime;
		Vector3 bob = start + new Vector3(
			Mathf.Cos(time * speed.x + offset.x) * amount.x,
			Mathf.Cos(time * speed.y + offset.y) * amount.y,
			Mathf.Cos(time * speed.z + offset.z) * amount.z);
		if (rotation) transform.localRotation = Quaternion.Euler(bob);
		else transform.localPosition = bob;
	}
}
