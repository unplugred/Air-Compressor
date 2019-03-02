using UnityEngine;

public class lookat : MonoBehaviour
{
	void Update()
	{
		transform.LookAt(transform.position + Camera.main.gameObject.transform.rotation * Vector3.forward, Camera.main.gameObject.transform.rotation * Vector3.up);
		transform.localRotation = Quaternion.Euler(
			Mathf.Floor(transform.localRotation.eulerAngles.x / 90f - 1) * 90,
			Mathf.Floor(transform.localRotation.eulerAngles.y / 90f + 1) * 90,
			0);
	}
}
