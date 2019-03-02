using UnityEngine;

public class iris : MonoBehaviour
{
	[SerializeField] AnimationCurve vertical;
	[SerializeField] AnimationCurve horizontal;
	[SerializeField] float sizey;
	[SerializeField] float sizex;
	[SerializeField] siris[] irises;
	public static float addrot;
	[SerializeField] GameObject ending;

	void Update()
	{
		addrot = transform.eulerAngles.y;

		Vector3 irispos;
		int closedvisibleamount = 0;
		foreach (siris iris in irises)
		{
			if (iris.visible)
			{
				if (iris.eye < 100)
				{
					Vector3 screenposthing = Camera.main.WorldToScreenPoint(iris.transform.right * -1);
					float msangl = Vector2.SignedAngle(new Vector2(screenposthing.x, screenposthing.y) - new Vector2(Input.mousePosition.x, Input.mousePosition.y), new Vector2(0, 1));
					if (iris.rotate)
					{
						msangl -= iris.transform.eulerAngles.y;
					}
					msangl /= 180;

					irispos = new Vector3(0,
						(horizontal.Evaluate(Mathf.PingPong(msangl - 0.5f, 1)) - 0.5f) * sizex,
						(vertical.Evaluate(Mathf.PingPong(msangl, 1)) - 0.5f) * sizey);

					if (iris.hover)
					{
						RaycastHit hit;
						Debug.DrawRay(Camera.main.transform.position, -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, 1)));
						if (Physics.Raycast(Camera.main.transform.position, -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, 1)), out hit, 100))
						{
							Vector3 mousepos = iris.transform.InverseTransformPoint(hit.point);
							if (Vector3.Distance(iris.transform.position, iris.transform.TransformPoint(0, mousepos.y, mousepos.z)) < Vector3.Distance(iris.transform.position, irispos))
							{
								irispos = new Vector3(0, mousepos.y, mousepos.z);
							}
						}
					}

					iris.theiris.localPosition = Vector3.Lerp(iris.theiris.localPosition, irispos, 7f * Time.deltaTime);
				}
				else
				{
					closedvisibleamount++;
					irispos = new Vector3(0, 0, -0.3f);
				}
			}
		}

		if (closedvisibleamount >= 3)
		{
			ending.SetActive(true);
			foreach (siris iris in irises)
			{
				iris.gameObject.SetActive(false);
			}
			enabled = false;
		}
	}
}
