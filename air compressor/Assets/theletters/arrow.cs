using UnityEngine;

public class arrow : MonoBehaviour
{
	Vector3 mousepos;
	Vector3 mouseposunlerped;
	bool stage;
	[SerializeField] Transform moveme;
	[SerializeField] Material mat;
	[SerializeField] Canvas cavnas;
	[SerializeField] AudioSource clickos;

	void Start()
	{
		mousepos = Input.mousePosition + Vector3.left * 50;
	}

	void Update()
	{
		if (!stage && Input.mousePosition != mouseposunlerped)
		{
			transform.localRotation = Quaternion.Euler(0, 180, thanksstackoverflow(mousepos, Input.mousePosition));
			mousepos = Vector3.Lerp(mousepos, Input.mousePosition, Time.deltaTime * 3);
			mouseposunlerped = Input.mousePosition;
		}
	}

	void FixedUpdate()
	{
		if (stage)
		{
			transform.position = Vector3.MoveTowards(transform.position, moveme.position, Time.deltaTime * 8);
			transform.localPosition = new Vector3(
				Mathf.Repeat(transform.localPosition.x + 275, 550) - 275,
				Mathf.Repeat(transform.localPosition.y + 275, 550) - 275, 0);
		}
	}

	void OnMouseUpAsButton()
	{
		if (!stage)
		{
			stage = true;
			cavnas.pixelPerfect = false;
			mat.color = Color.black;
			clickos.Play();
			if (Mathf.PingPong(transform.localEulerAngles.z, 45) <= 2)
			{
				transform.localEulerAngles += new Vector3(0, 0, 2) * (Random.Range(0, 1) * 2 - 1);
			}
		}
	}

	void OnMouseEnter()
	{
		if (!stage)
			mat.color = new Color(0.666f, 0, 0);
	}

	void OnMouseExit()
	{
		mat.color = Color.black;
	}

	public static float thanksstackoverflow(Vector2 vec1, Vector2 vec2)
	{
		Vector2 diference = vec2 - vec1;
		float sign = (vec2.y < vec1.y) ? 1.0f : -1.0f;
		return Vector2.Angle(Vector2.right, diference) * sign;
	}
}
