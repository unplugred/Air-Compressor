using UnityEngine;
using UnityEngine.SceneManagement;

public class physcube : MonoBehaviour
{
	[SerializeField] BoxCollider col;
	[SerializeField] MeshCollider eyecol;
	[SerializeField] GameObject animpart;
	[SerializeField] GameObject physpart;
	[SerializeField] ending end;
	public static physcube that;
	[SerializeField] GameObject blackscreeno;
	public AudioClip[] impacts;
	[SerializeField] AudioSource shatter;
	bool faslkdfj = true;

	void Start()
	{
		col.enabled = true;
		eyecol.enabled = false;
		that = this;
	}

	void OnMouseDown()
	{
		shatter.Play();
		end.enabled = false;
		col.enabled = false;
		animpart.SetActive(false);
		physpart.SetActive(true);
		enabled = false;
	}

	public void endsequence()
	{
		if (faslkdfj)
		{
			faslkdfj = false;
			blackscreeno.SetActive(true);
			StartCoroutine(LoadNewScene());
		}
	}

	System.Collections.IEnumerator LoadNewScene()
	{
		yield return new WaitForSecondsRealtime(6);

		/*/
		Application.Quit();
		Debug.Log("Game done!");
		/*/
		AsyncOperation async = SceneManager.LoadSceneAsync(1);

		while (!async.isDone)
		{
			yield return null;
		}

		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		//*/
	}
}
