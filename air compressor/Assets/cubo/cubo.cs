using UnityEngine;

public class cubo : MonoBehaviour
{
	public float speed;

	void Update()
	{
		transform.Rotate(0, Time.deltaTime * speed, 0);
	}
}
