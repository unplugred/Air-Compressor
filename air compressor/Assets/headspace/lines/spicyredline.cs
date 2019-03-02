using UnityEngine;

public class spicyredline : MonoBehaviour
{
	void OnMouseDown()
	{
		(transform.parent.gameObject.GetComponent(typeof(secondscreen)) as secondscreen).h.DoTheThingy();
	}
}
