using UnityEngine;

public class endingsizzle : MonoBehaviour
{
	[SerializeField] GameObject thingstodisable;
	[SerializeField] AudioSource sauce;
	float tim;

	void OnEnable()
	{
		thingstodisable.SetActive(false);
	}

	void Update()
	{
		tim += Time.deltaTime;
		if (tim >= 0.75f)
		{
			sauce.Stop();
			if (tim >= 1)
			{
				iwanttoquit.go = null;
				Application.Quit();
			}
		}
	}
}