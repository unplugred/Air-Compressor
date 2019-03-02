using UnityEngine;

[ExecuteInEditMode]
public class staticshader : MonoBehaviour
{
	[SerializeField] Material mat;
	float tim;

	void Update()
	{
		tim += Time.deltaTime;
		if (tim >= 0.05f)
		{
			mat.SetTextureOffset("stat", new Vector2(Random.Range(0, 1024f) / 1024f, Random.Range(0, 1024) / 1024f));
			tim = 0;
		}
		float size = Mathf.Min(Screen.width, Screen.height) / 1024f;
		mat.SetTextureScale("stat", new Vector2(size, size));
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, mat);
	}
}
