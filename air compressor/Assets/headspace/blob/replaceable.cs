using UnityEngine;

public class replaceable : MonoBehaviour
{
	[SerializeField] MeshRenderer[] sides;
	[SerializeField] sineify sin;
	[SerializeField] GameObject[] disablo;
	[SerializeField] Material outline1;
	[SerializeField] Material outline2;
	[SerializeField] GameObject endo;
	float tim;

	void Start()
	{
		foreach (GameObject side in disablo)
			side.SetActive(false);
		iwanttoquit.go = endo;
		sin.enabled = true;
	}

	void Update()
	{
		tim += 0.03f;
		outline1.color = new Color(0, 0, 0, 2 - tim);
		outline2.color = new Color(0, 0, 0, tim);
		if (tim >= 2)
		{
			foreach (MeshRenderer side in sides)
				side.enabled = false;
			enabled = false;
		}
	}
}
