using UnityEngine;

public class blankpause : MonoBehaviour
{
	[SerializeField] GameObject enablething;
	float tim;

	void OnEnable()
	{
		tim = 0;
	}

	void Update()
	{
		if ((tim += Time.deltaTime) >= 1)
		{
			enablething.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
