using UnityEngine;

public class logoloading : MonoBehaviour
{
	[SerializeField] Material gogogadget;
	Texture2D noiseTex;
	float tim;

	void Start()
	{
		noiseTex = new Texture2D(32, 32, TextureFormat.RFloat, false);
		noiseTex.wrapMode = TextureWrapMode.Clamp;
		noiseTex.anisoLevel = 0;
		noiseTex.filterMode = FilterMode.Bilinear;
		movebg.init(32, 32);
		gogogadget.SetTexture("_MainTex", noiseTex);
	}

	void Update()
	{
		tim += Time.deltaTime * 0.1f;
		gogogadget.SetFloat("_Mult", Mathf.Min(tim, 0.5f));
		noiseTex.SetPixels(movebg.CalcNoise(32, 32, 0.1f, 1, 1));
		noiseTex.Apply();
	}
}
