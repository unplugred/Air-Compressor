using UnityEngine;

public class sideofathingy : MonoBehaviour
{
	[SerializeField] AnimationCurve curve;
	float amnt;
	float tim;

	void Start()
	{
		amnt = transform.localPosition.y;
	}

	void Update()
	{
		tim += Time.deltaTime;
		transform.localPosition = new Vector3(transform.localPosition.x, (1 - curve.Evaluate(tim * 0.3f)) * amnt, transform.localPosition.z);
	}
}
