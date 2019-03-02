using UnityEngine;

public class movebg : MonoBehaviour
{
	[SerializeField] Material[] mat;
	public Texture2D noiseTex;
	public float scale;
	[SerializeField] float speed;
	public float amount;
	[SerializeField] float scroll;
	static Color[] pix;

	void Start()
	{
		noiseTex = new Texture2D(64, 64, TextureFormat.RFloat, false);
		noiseTex.wrapMode = TextureWrapMode.Clamp;
		noiseTex.anisoLevel = 0;
		noiseTex.filterMode = FilterMode.Bilinear;
		init(64, 64);
		foreach (Material m in mat)
			m.SetTexture("_waves", noiseTex);
	}

	void Update()
	{
		transform.position = new Vector3((0.5f * Time.time) % 1, 0, 0);
		foreach (Material m in mat)
			m.SetFloat("_amount", amount);
		noiseTex.SetPixels(CalcNoise(64, 64, scale, scroll, speed));
		noiseTex.Apply();
	}

	public static void init(int width, int height)
	{
		pix = new Color[width * height];
	}

	public static Color[] CalcNoise(int height, int width, float scale, float scroll, float speed)
	{
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				float sample = threedperlinogaralino(x * scale + Time.time * scroll, y * scale, Time.time * speed);
				pix[y * width + x] = new Color(sample, 0, 0);
			}
		}
		return pix;
	}

	static float threedperlinogaralino(float x, float y, float z)
	{
		return (
		Mathf.PerlinNoise(x, y) +
		Mathf.PerlinNoise(y, x) +
		Mathf.PerlinNoise(x, z) +
		Mathf.PerlinNoise(z, x) +
		Mathf.PerlinNoise(y, z) +
		Mathf.PerlinNoise(z, y)) / 6;
	}
}
