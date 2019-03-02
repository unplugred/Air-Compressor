using UnityEngine;

public class mousethingy : MonoBehaviour
{
	public static Vector3 dist;
	public static float they;
	public static Vector3 offsetto;
	[SerializeField] objshake shakalaka;

	void Start()
	{
		shakalaka.shakeamount = 0.2f;
	}

	void Update()
	{
		shakalaka.shakeamount = Mathf.Max(shakalaka.shakeamount - Time.deltaTime * 1, 0);

		Vector3 foo = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Vector3.Distance(dist, Camera.main.transform.position)));
		foo.y = Mathf.Max(-2, foo.y);
		foo.z = they;
		offsetto = foo - transform.position;
		transform.position = foo;
	}
}
