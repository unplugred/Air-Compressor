using UnityEngine;

public class sceneresetti : MonoBehaviour
{
	[SerializeField] Material redeye;
	[SerializeField] Material arrow;
	[SerializeField] Material logo;
	[SerializeField] Material linesdistortion;
	[SerializeField] Material outline1;
	[SerializeField] Material outline2;

	void OnApplicationQuit()
	{
		redeye.color = new Color(1, 0, 0, 1);
		linesdistortion.SetFloat("_Amount", 0);
		logo.SetTextureOffset("_MainTex", new Vector2(0, -1));
		arrow.color = Color.black;
		outline1.color = new Color(0, 0, 0, 1);
		outline2.color = new Color(0, 0, 0, 0);
	}
}
