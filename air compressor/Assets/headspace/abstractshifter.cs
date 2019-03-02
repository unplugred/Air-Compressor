using UnityEngine;

public class abstractshifter : MonoBehaviour
{
	int state;
	[SerializeField] GameObject[] gb;
	[SerializeField] GameObject camera1;
	[SerializeField] abstractsoundtrack[] sndtrk;
	float tim;

	void OnEnable()
	{
		gb[state].SetActive(true);
		foreach (abstractsoundtrack item in sndtrk)
			item.sauce.mute = false;
	}

	void OnDisable()
	{
		foreach (abstractsoundtrack item in sndtrk)
			item.sauce.mute = true;
	}

	public void DoTheThingy()
	{
		gb[state++].SetActive(false);
		camera1.SetActive(true);
		gameObject.SetActive(false);
	}

	public void fademe()
	{
		tim += Time.deltaTime;
		foreach (abstractsoundtrack item in sndtrk)
			if (item.sauce.isPlaying)
				if ((item.sauce.volume = item.fadecurve.Evaluate(1 - (tim * item.fadetime)) * item.volume) >= 1)
					item.sauce.Stop();
	}
}

[System.Serializable]
public struct abstractsoundtrack
{
	public AudioSource sauce;
	public float fadetime;
	public AnimationCurve fadecurve;
	public float volume;
}