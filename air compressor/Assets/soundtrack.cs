using UnityEngine;

public class soundtrack : MonoBehaviour
{
	[SerializeField] AudioSource[] sauce;
	[SerializeField] AudioClip[] clipp;
	[SerializeField] float tim = 8;
	float[] timmy;

	void OnEnable()
	{
		if (tim > 0)
		{
			timmy = new float[sauce.Length];
			for (int i = 0; i < sauce.Length; i++)
			{
				timmy[i] = Random.Range(0, tim);
			}
		}
		foreach (AudioSource tomato in sauce)
		{
			if (tomato.enabled) updatesounds(tomato);
		}
	}

	void OnDisable()
	{
		foreach (AudioSource tomato in sauce)
		{
			if (tomato.enabled) tomato.Stop();
		}
	}

	void Update()
	{
		if (tim > 0)
		{
			for (int i = 0; i < timmy.Length; i++)
			{
				timmy[i] -= Time.deltaTime;
				if (timmy[i] <= 0)
				{
					if (i == 0)
					{
						updatesounds(sauce[i]);
					}
					else
					{
						sauce[i].enabled = !sauce[i].enabled;
						if (sauce[i].enabled)
						{
							updatesounds(sauce[i]);
						}
					}
					timmy[i] = Random.Range(0, tim);
				}
			}
		}
	}

	public void updatesounds(AudioSource tomato)
	{
		tomato.clip = clipp[Random.Range(0, clipp.Length)];
		tomato.Play();
	}
}
