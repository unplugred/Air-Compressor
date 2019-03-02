using UnityEngine;

public class clicktoggle : MonoBehaviour
{
	[SerializeField] GameObject gmobj;
	[SerializeField] Material statc;
	[SerializeField] Material mat;

	void OnMouseDown()
	{
		mat.SetTextureScale("_MainTex", statc.GetTextureScale("stat") * 0.4f);
		gmobj.SetActive(true);
		gameObject.SetActive(false);
	}
}
