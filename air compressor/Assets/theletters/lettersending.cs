using UnityEngine.UI;
using UnityEngine;

public class lettersending : MonoBehaviour
{
	public aftershake[] ass;
	[SerializeField] AnimationCurve curve;
	Vector3 localpos;
	float tim;
	[SerializeField] Text txt;
	[SerializeField] GameObject gmbjct;
	float timmothy = 10;
	[SerializeField] AudioSource fall;
	bool playedthething = true;
	[SerializeField] AudioSource flutonium;

	void Start()
	{
		localpos = transform.localPosition;
		generateletters.s = this;
		enabled = false;
	}

	void Update()
	{
		if (tim == 0) fall.Play();
		tim += Time.deltaTime;
		transform.localPosition = localpos + new Vector3(0, curve.Evaluate(tim) * -100, 0);

		if (tim > 3)
		{
			if (playedthething)
			{
				flutonium.Play();
				playedthething = false;
			}

			if ((timmothy += Time.deltaTime) >= 0.05f)
			{
				flutonium.pitch = Random.Range(0.5f, 1.5f);

				for (int i = 0; i < 2; i++)
				{
					if (Random.Range(0f, 3f) > tim - 3)
					{
						txt.text = txt.text.Insert(Random.Range(0, txt.text.Length), ((char)Random.Range(0x0021, 0x007E)).ToString());
					}
					else
					{
						txt.text = txt.text.Remove(Random.Range(0, txt.text.Length), 1);
						if (txt.text == "")
						{
							//flutonium.pitch = 0.82f;
							flutonium.loop = false;
							flutonium.Play();
							gmbjct.SetActive(true);
							enabled = false;
						}
					}
				}
				timmothy = 0;
			}
		}
	}
}
