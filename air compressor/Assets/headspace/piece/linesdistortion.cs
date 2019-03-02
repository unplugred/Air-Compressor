using UnityEngine;

[ExecuteInEditMode]
public class linesdistortion : MonoBehaviour
{
	[SerializeField] Material mat;

	void Update()
	{
		mat.SetTextureOffset("_Noise", new Vector2(Random.Range(0, 512) / 512f, Random.Range(0, 512) / 512f));
		float size = Mathf.Min(Screen.width, Screen.height) / 512f;
		mat.SetTextureScale("_Noise", new Vector2(size, size));
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, mat);
	}
}
