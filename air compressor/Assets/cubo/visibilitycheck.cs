using UnityEngine;

public class visibilitycheck : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
		(other.gameObject.GetComponent(typeof(physmousedrag)) as physmousedrag).asdlkjf();
	}
}
