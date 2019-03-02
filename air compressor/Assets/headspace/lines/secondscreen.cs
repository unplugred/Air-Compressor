using UnityEngine;

public class secondscreen : MonoBehaviour
{
	public abstractshifter h;
	[SerializeField] Transform gradient;
	[SerializeField] Object shapeobj;
	[SerializeField] Object specialobj;
	Transform[,] shapes = new Transform[12, 12];
	int lastone = -1;

	void Start()
	{
		int[] j = new int[2] { Random.Range(0, 12), Random.Range(0, 12) };
		for (int i = 0; i < 12; i++)
		{ //y
			for (int n = 0; n < 12; n++)
			{ //x
				shapes[n, i] = ((GameObject)Instantiate(((j[0] == n) && (j[1] == i)) ? specialobj : shapeobj, transform)).transform;
			}
			lastone++;
		}
	}

	void Update()
	{
		if (shapes[lastone, lastone].localPosition.x + Time.deltaTime >= 12)
		{
			int n = 23;
			int[] h = interpolate(n);
			while (n > 1)
			{
				int[] k = interpolate(Random.Range(0, n--));
				h = interpolate(n);
				Transform temppppp = shapes[h[0], h[1]];
				shapes[h[0], h[1]] = shapes[k[0], k[1]];
				shapes[k[0], k[1]] = temppppp;
			}
			lastone = lastone == 0 ? 11 : (lastone - 1);
		}
		for (int i = 0; i < 12; i++)
		{ //y
			for (int n = 0; n < 12; n++)
			{ //x
				shapes[n, i].localPosition = new Vector3((Time.time + n) % 12, (Time.time + i) % 12, 0);
				shapes[n, i].localEulerAngles = new Vector3(Time.time * 80 + (shapes[n, i].localPosition.x + shapes[n, i].localPosition.y) * 8.175934f, 90, 90); //credit to the wonderful people over at discord
			}
		}

		gradient.localPosition = new Vector3(Mathf.PingPong(Time.time * 5, 80), 0, 0);
	}

	int[] interpolate(int num)
	{
		if (num >= 12)
			return new int[2] { lastone, num >= (lastone + 12) ? (num - 11) : (num - 12) };
		else
			return new int[2] { num, lastone };
	}
}
