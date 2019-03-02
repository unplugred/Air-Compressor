using UnityEngine;

public class halfblob : MonoBehaviour
{
	public static float mult = 1;
	[SerializeField] Material[] mat;
	[SerializeField] Vector2 amnt;
	[SerializeField] float offset;
	[SerializeField] float amount;
	[SerializeField] float speed;
	[SerializeField] float minimum;

	void Start()
	{
		dod();
	}

	void Update()
	{
		dod();
	}

	void dod()
	{
		Vector2 offsetto = new Vector2(Mathf.Sin(Time.time * 0.0005f), Mathf.Cos(Time.time * 0.0005f)) * amnt;

		foreach (Material item in mat)
		{
			item.SetTextureOffset("_Displace", offsetto);
			item.SetFloat("_Amount", (Mathf.Sin(Time.time * speed + offset) * amount + minimum) * mult);
		}
	}
}
