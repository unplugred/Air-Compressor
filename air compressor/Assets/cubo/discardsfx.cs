using UnityEngine;

public class discardsfx : MonoBehaviour
{
	[SerializeField] AudioClip[] pasta;
	[SerializeField] AudioSource sauce;
	static System.Collections.Generic.List<int> played = new System.Collections.Generic.List<int>(new int[] { 0, 1, 2, 3 });

	void Start()
	{
		int chosen = Random.Range(0, played.Count);
		sauce.clip = pasta[played[chosen]];
		sauce.Play();
		played.RemoveAt(chosen);
		if (played.Count == 0)
			played = new System.Collections.Generic.List<int>(new int[] { 0, 1, 2, 3 });
	}
}
