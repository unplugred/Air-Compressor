using UnityEngine;

public class iwanttoquit
{
	public static GameObject go = null;

	static bool wantsToQuit()
	{
		if (go == null)
			return true;
		go.SetActive(true);
		return false;
	}

	[RuntimeInitializeOnLoadMethod]
	static void RunOnStart()
	{
		Application.wantsToQuit += wantsToQuit;
	}
}