using UnityEngine;

public class ending : MonoBehaviour
{
	[SerializeField] Vector3 cuberotation;
	[SerializeField] Vector3 outlinerotationadd;
	Quaternion outlinerotation;
	[SerializeField] cubo cube;
	[SerializeField] lookat outlinethingy;
	[SerializeField] sineify wrapper;
	Quaternion[] lerpididoop = new Quaternion[4];
	[SerializeField] GameObject[] outline;
	[SerializeField] AudioSource sauce;
	[SerializeField] AudioSource sauce2;
	[SerializeField] AudioSource sauce3;
	float tim = 0;
	[SerializeField] staticshader stat;
	[SerializeField] Material mat;
	int stage = -1;
	[SerializeField] physcube phys;

	void Start()
	{
		outlinerotation = Quaternion.Euler(Quaternion.LookRotation(outline[0].transform.position - Camera.main.transform.position).eulerAngles + outlinerotationadd);
		wrapper.enabled = false;
	}

	void Update()
	{
		if (cube.speed > 0)
		{
			cube.speed = Mathf.Max(cube.speed - Time.deltaTime * 6, 0);
		}
		else
		{
			if (outlinethingy.enabled)
			{
				outlinethingy.enabled = false;
				sauce.Play();
				for (int i = 0; i < outline.Length; i++)
				{
					lerpididoop[i] = outline[i].transform.rotation;
				}
			}
			cube.transform.localRotation = Quaternion.Lerp(cube.transform.localRotation, Quaternion.Euler(cuberotation), 2f * Time.deltaTime);
			for (int i = 0; i < outline.Length; i++)
			{
				lerpididoop[i] = Quaternion.Lerp(lerpididoop[i], outlinerotation, ((4 - i) * 0.5f) * Time.deltaTime);
				outline[i].transform.rotation = lerpididoop[i];
			}

			if (tim > 0)
			{
				tim += Time.deltaTime;
				transform.localEulerAngles = new Vector3(0, Mathf.Lerp(transform.transform.localEulerAngles.y, 90, 4 * Time.deltaTime), 90);
			}
			switch (stage)
			{
				case 0:
					if (tim > 3)
					{
						mat.color = new Color(0, 1, 0, 1);
						stage = 1;
						sauce3.Play();
					}
					break;
				case 1:
					if (tim > 3.5f)
					{
						mat.color = new Color(0, 0, 1, 1);
						stat.enabled = false;
						sauce3.Stop();
						phys.enabled = true;
						stage++;
					}
					break;
			}


			if (tim > 0)
			{
				transform.localEulerAngles = new Vector3(0, Mathf.Lerp(transform.transform.localEulerAngles.y, 90, 4 * Time.deltaTime), 90);
				tim += Time.deltaTime;
			}
		}
	}

	void OnMouseDown()
	{
		if (stage == -1)
		{
			sauce2.Play();
			tim += Time.deltaTime;
			stage = 0;
			stat.enabled = true;
		}
	}
}
