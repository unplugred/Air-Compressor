using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(LoadNewScene());
	}

	System.Collections.IEnumerator LoadNewScene()
	{
		yield return new WaitForSecondsRealtime(6);

		/*/
		Application.Quit();
		Debug.Log("Game done!");
		/*/
		AsyncOperation async = SceneManager.LoadSceneAsync(2);

		while (!async.isDone)
		{
			yield return null;
		}

		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		//*/
	}
}
