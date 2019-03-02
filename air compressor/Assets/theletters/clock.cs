using UnityEngine;

public class clock : MonoBehaviour
{
	[SerializeField] GameObject clack;
	[SerializeField] SphereCollider cldr;
	public clack ling;
	public clack smol;
	public GameObject insides;
	public GameObject outsides;
	int amnt;
	float tim = 1;

	void Update()
	{
		if (amnt == 0)
		{
			tim -= Time.deltaTime;
			if (tim <= 0)
			{
				float mnt = ((System.DateTime.Now.Second / 60f) + System.DateTime.Now.Minute) / 60f;

				smol.val = (System.DateTime.Now.Hour + mnt) * 30 + 180;
				while (smol.val > 180)
					smol.val -= 360;
				while (smol.val < -180)
					smol.val += 360;
				smol.transform.localEulerAngles = new Vector3(0, 0, smol.val);
				smol.recalc();

				ling.val = mnt * 360 + 180;
				while (ling.val > 180)
					ling.val -= 360;
				while (ling.val < -180)
					ling.val += 360;
				ling.transform.localEulerAngles = new Vector3(0, 0, ling.val);
				ling.recalc();

				clack.SetActive(true);
				cldr.isTrigger = false;
				enabled = false;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		amnt++;
	}

	void OnTriggerExit(Collider other)
	{
		amnt--;
		tim = 0;
	}
}
