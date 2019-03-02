using UnityEngine;

public class clack : MonoBehaviour
{
	[SerializeField] Material mat;
	[SerializeField] Transform rot;
	[SerializeField] Transform mov;
	[SerializeField] int a;
	[SerializeField] int b;
	[SerializeField] int c;
	[SerializeField] int d;
	[SerializeField] int e;
	[SerializeField] int f;
	[SerializeField] float mount = 100;
	[SerializeField] float gradientwidth;
	public float val;
	bool down;
	bool over;
	float offset;
	[SerializeField] clock clck;
	[SerializeField] AudioSource sauce;
	int before, after;

	void Start()
	{
		int clean = (int)(transform.localEulerAngles.z - (transform.localEulerAngles.z % 5));
		before = clean - 5;
		after = clean + 5;
	}

	void Update()
	{
		if (down)
		{
			if (transform.localEulerAngles.z >= 175 && transform.localEulerAngles.z <= 185)
			{
				transform.localEulerAngles = new Vector3(0, 0, 180);

				mat.color = new Color(0, 0, 0, 1);
				transform.localPosition = new Vector3(0, 0, 0.5f);

				if (clck.smol == null || clck.ling == null)
				{
					clck.insides.SetActive(true);
					clck.outsides.SetActive(false);
				}
				else
				{
					sauce.pitch = 1.2f;
					sauce.volume = 1;
					sauce.Play();
					recalc();
				}

				Object.Destroy(this);
			}
			else
			{
				transform.localEulerAngles = new Vector3(0, 0, arrow.thanksstackoverflow(Input.mousePosition, new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)) - offset);
				if (transform.localEulerAngles.z > after || transform.localEulerAngles.z < before)
				{
					int clean = (int)(transform.localEulerAngles.z - (transform.localEulerAngles.z % 5));
					before = clean - 5;
					after = clean + 5;
					sauce.volume = Random.Range(0.6f, 1f);
					sauce.pitch = Random.Range(0.99f, 1.01f);
					sauce.Play();
				}
				recalc();
			}
		}
	}

	void OnMouseEnter()
	{
		over = true;

		mat.color = new Color(1, 0, 0, 1);
		transform.localPosition = new Vector3(0, 0, 0.6f);
	}

	void OnMouseExit()
	{
		over = false;

		if (!down)
		{
			mat.color = new Color(0, 0, 0, 1);
			transform.localPosition = new Vector3(0, 0, 0.5f);
		}
	}

	void OnMouseDown()
	{
		down = true;

		offset = arrow.thanksstackoverflow(Input.mousePosition, new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)) - transform.localEulerAngles.z;
	}

	void OnMouseUp()
	{
		down = false;

		if (!over)
		{
			mat.color = new Color(0, 0, 0, 1);
			transform.localPosition = new Vector3(0, 0, 0.5f);
		}
	}

	public void recalc()
	{
		float h = transform.localEulerAngles.z - 180;
		float g = (h / 180) * Mathf.PI;
		rot.localEulerAngles = new Vector3(0, 0, Mathf.Sin(g * a) * b + Mathf.Sin(g * c) * d + h * e + f);

		float s = transform.localEulerAngles.z;
		while (s > 180)
			s -= 360;
		while (s < -180)
			s += 360;
		s -= val;

		mov.localPosition = new Vector3((Mathf.Abs(s) * (mount / (s > 0 ? 180 - val : 180 + val))) - gradientwidth, 0, 50);
	}
}
