using UnityEngine;

public class nostalgiasound : MonoBehaviour
{
	[SerializeField] abstractshifter snd;
	[SerializeField] AudioSource nostalgia;

	void Update()
	{
		nostalgia.pitch = Mathf.Lerp(nostalgia.pitch, 1, Time.deltaTime * 1.3f);
		snd.fademe();
	}
}
