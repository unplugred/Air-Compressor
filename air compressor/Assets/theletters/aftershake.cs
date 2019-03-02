using UnityEngine.UI;
using UnityEngine;

public class aftershake : MonoBehaviour
{
	Vector3 startpos;
	bool shake = true;
	[SerializeField] AudioSource sauce;
	int blanksince;
	static AudioSource themainone;

	void Start()
	{
		startpos = transform.localPosition;
		enabled = false;
		themainone = sauce;
	}

	void Update()
	{
		if (shake)
			transform.localPosition = startpos + Random.insideUnitSphere * 2;
		else
		{
			float amnt = Vector3.Distance(startpos, transform.localPosition) / Time.deltaTime;
			startpos = transform.localPosition;
			if (amnt == 0) blanksince++; else blanksince = 0;
			if (blanksince == 20) sauce.pitch = Random.Range(0.8f, 1.2f);
			if (blanksince != 1)
				sauce.volume = Mathf.Lerp(sauce.volume, amnt * 0.004f, Time.deltaTime * 15);
		}
	}

	void LateUpdate()
	{
		if (sauce.volume == 0)
			return;
		if (themainone.volume < sauce.volume)
		{
			themainone.mute = true;
			themainone = sauce;
			sauce.mute = false;
		}
	}

	public void ending()
	{
		transform.localPosition = startpos;
		(gameObject.GetComponent(typeof(Text)) as Text).color = new Color(0, 0, 0, 1);
		(gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody).isKinematic = false;
		shake = false;
	}
}
