using UnityEngine;

public class eyeshrinkaroo : MonoBehaviour
{
	void Update()
	{
		float siz = Mathf.Lerp(transform.localScale.y, 0, Time.deltaTime * 4);
		transform.localScale = new Vector3(1, siz, siz);
		if (siz <= 0.01f)
			Object.Destroy(gameObject);
	}
}
