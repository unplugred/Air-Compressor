using UnityEngine.UI;
using UnityEngine;

public class generateletters : MonoBehaviour
{
	[SerializeField] Text txt;
	float time;
	static int amnt = 0;
	static int amnt2 = 0;
	bool isdown = true;
	[SerializeField] aftershake hn;
	public static lettersending s;
	[SerializeField] letterino h;
	[SerializeField] AudioSource sauce;
	[SerializeField] AudioClip[] cliposdoritos;
	[SerializeField] AudioSource salsa;

	void Start()
	{
		updateLetter();
		amnt2++;
	}

	void Update()
	{
		time -= Time.deltaTime;
		if (time <= 0 && isdown)
			updateLetter();
	}

	void OnMouseEnter()
	{
		txt.color = Color.red;
		amnt++;

		if (amnt == 1)
			h.gameObject.SetActive(true);
	}

	void OnMouseExit()
	{
		isdown = true;
		salsa.mute = true;
		txt.color = Color.black;
		h.bob.color = Color.white;
		amnt--;

		if (amnt == 0)
			h.gameObject.SetActive(false);
	}

	void OnMouseDown()
	{
		isdown = false;
		salsa.mute = false;
		txt.color = Color.green;
		h.bob.color = Color.green;
	}

	void OnMouseUp()
	{
		if (!isdown)
		{
			isdown = true;
			salsa.mute = true;
			txt.color = Color.blue;
			h.bob.color = Color.white;
			hn.enabled = true;
			amnt--;
			if (amnt == 0)
				h.gameObject.SetActive(false);
			amnt2--;
			if (amnt2 == 0)
			{
				s.enabled = true;
				foreach (aftershake shake in s.ass)
					shake.ending();
			}
			Object.Destroy(this);
		}
	}

	void updateLetter()
	{
		int racismCheck = Random.Range(0x4e00, 0x9FD5);
		while (racismCheck == 0x5350 || racismCheck == 0x534D)
			racismCheck = Random.Range(0x4e00, 0x9FD5);
		txt.text = ((char)racismCheck).ToString();
		time = Random.Range(0f, 1f);

		sauce.pitch = Random.Range(0.8f, 1f);
		sauce.volume = Random.Range(0.95f, 1f);
		sauce.clip = cliposdoritos[Random.Range(0, cliposdoritos.Length)];
		sauce.Play();
	}
}