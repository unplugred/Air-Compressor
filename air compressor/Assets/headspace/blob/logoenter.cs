using UnityEngine;

public class logoenter : MonoBehaviour
{
	[SerializeField] blobclick h;
	[SerializeField] Transform top;
	[SerializeField] Transform bottom;
	[SerializeField] Material logo;
	[SerializeField] AnimationCurve curve;
	float tim;

	void Start()
	{
		h.enabled = false;
	}

	void Update()
	{
		tim += Time.deltaTime * 0.3f;
		top.localPosition = new Vector3(0, (1 - curve.Evaluate(tim)) * 350, 0);
		bottom.localPosition = new Vector3(0, curve.Evaluate(tim - 1) * 52 - 302, 0);
		logo.SetTextureOffset("_MainTex", new Vector2(0, 0.5f - (top.localPosition.y - 25) / 142));
	}
}
