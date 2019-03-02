using UnityEngine;

public class siris : MonoBehaviour
{
	public bool hover = false;
	public Transform theiris;
	public bool rotate = false;
	[SerializeField] SkinnedMeshRenderer rendererer;
	public float eye = 0;
	[SerializeField] float countdown = 0;
	public bool visible = true;
	[SerializeField] AudioSource sauce;

	void OnMouseEnter()
	{
		hover = true;
	}

	void OnMouseExit()
	{
		hover = false;
	}

	void OnMouseDown()
	{
		eye = Mathf.Lerp(eye, 102, 5f * Time.deltaTime);
		countdown = 6;
		sauce.pitch = Random.Range(1, 1.5f);
		sauce.Play();
	}

	void Update()
	{
		visible = rotate ? true : (Mathf.Repeat(transform.localEulerAngles.y + iris.addrot, 360) > 180);

		if (eye > 0) eye = Mathf.Lerp(eye, (countdown -= Time.deltaTime) < 0 ? 0 : 102, 5f * Time.deltaTime);
		rendererer.SetBlendShapeWeight(0, eye);
		rendererer.enabled = eye < 100;
	}
}
