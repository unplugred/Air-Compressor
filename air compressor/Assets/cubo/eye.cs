using UnityEngine;

public class eye : MonoBehaviour
{
	Vector3 start;
	[SerializeField] bool POINT;

	void Start()
	{
		start = transform.localRotation.eulerAngles;
	}

	void Update()
	{
		transform.LookAt(transform.position + Camera.main.gameObject.transform.rotation * Vector3.forward, Camera.main.gameObject.transform.rotation * Vector3.up);
		transform.localRotation = Quaternion.Euler(new Vector3(POINT ? transform.localRotation.eulerAngles.x : transform.localRotation.eulerAngles.y, 0, 0) + start);
	}
}
