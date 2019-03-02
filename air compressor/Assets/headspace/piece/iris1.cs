using UnityEngine;

public class iris1 : MonoBehaviour
{
	int state;
	float timmy;
	[SerializeField] GameObject camera1;
	[SerializeField] GameObject camera2;
	[SerializeField] AudioSource roomtone;

	[Header("Confused Eye")]
	[SerializeField] SkinnedMeshRenderer rendererer;
	[SerializeField] AnimationCurve vertical;
	[SerializeField] AnimationCurve horizontal;
	[SerializeField] float sizey;
	[SerializeField] float sizex;
	Vector3 irispos;
	float msangl;
	float tim;
	int slowone;
	float openness = 1;

	[Header("Rainbow")]
	[SerializeField] Material mat;

	[Header("Beam")]
	[SerializeField] GameObject particlethingy;
	[SerializeField] GameObject side6;
	[SerializeField] AnimationCurve uppness;
	[SerializeField] AnimationCurve rotatoness;
	[SerializeField] objshake camshake;
	[SerializeField] Material dist;
	[SerializeField] AudioSource beamsong;
	[SerializeField] AnimationCurve beamsongcurve;
	float risetim;
	float shakeroo;


	void Start()
	{
		mat.color = new Color(0, 0, 0, 1);
	}

	void OnEnable()
	{
		roomtone.mute = false;
		beamsong.mute = false;
		timmy = 0;
		state++;
	}

	void OnDisable()
	{
		roomtone.mute = true;
		beamsong.mute = true;
	}

	void Update()
	{
		if ((timmy += Time.deltaTime) > (state <= 1 ? 5.25f : 10.5f))
		{
			/*/
			timmy = 0;
			state++;
			/*/
			camera2.SetActive(true);
			camera1.SetActive(false);
			//*/
		}

		switch (state)
		{
			case 2:
				if (timmy < 3f) break;
				rendererer.enabled = true;
				openness = Mathf.Lerp(openness, 0, 5 * Time.deltaTime);
				rendererer.SetBlendShapeWeight(0, openness * 102);
				confuseledeye();
				break;
			case 3:
				confuseledeye();
				rainboweye();
				if (timmy >= 2.5f)
				{
					particlethingy.SetActive(true);
					rise();
					if (timmy >= 9)
						shake();
				}
				break;
			case 4:
				confuseledeye();
				rainboweye();
				rise();
				shake();
				break;
			case 5:
				confuseledeye();
				rainboweye();
				rise();
				break;
		}
	}

	void shake()
	{
		camshake.shakeamount = Mathf.Lerp(0, 0.05f, (shakeroo += Time.deltaTime) * 0.1f);
		dist.SetFloat("_Amount", camshake.shakeamount * 0.25f);
	}

	void confuseledeye()
	{
		if ((tim -= Time.deltaTime) <= 0)
		{
			msangl += Random.Range(0.3f, 1.7f);
			if (--slowone <= 0)
			{
				tim = Random.Range(0.5f, 1.5f);
				slowone = Random.Range(5, 15);
			}
			else
			{
				tim = Random.Range(0.22f, 0.45f);
			}
			irispos = new Vector3(0,
				(horizontal.Evaluate(Mathf.PingPong(msangl - 0.5f, 1)) - 0.5f) * sizex,
				(vertical.Evaluate(Mathf.PingPong(msangl, 1)) - 0.5f) * sizey);
		}
		transform.localPosition = Vector3.Lerp(transform.localPosition, irispos, 8f * Time.deltaTime);
	}

	void rainboweye()
	{
		mat.color = Color.HSVToRGB((Time.time * 0.5f) % 1, 1, 1);
	}

	void rise()
	{
		risetim += Time.deltaTime * 0.05f;
		side6.transform.position = new Vector3(0, 8.6f * uppness.Evaluate(risetim), 0);
		side6.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 109, -90), Quaternion.Euler(46, 142, -178), rotatoness.Evaluate(risetim));
		beamsong.volume = beamsongcurve.Evaluate(risetim * 10) * 0.5f;
	}
}
