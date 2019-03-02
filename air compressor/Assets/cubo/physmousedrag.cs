using UnityEngine;

public class physmousedrag : MonoBehaviour
{
	[SerializeField] ConfigurableJoint help;
	Vector3 globaloffset;
	bool count = false;
	static int amount;
	[SerializeField] bool areyoubusy = false;
	Vector3 r;
	[SerializeField] AudioSource sauce;
	[SerializeField] Rigidbody rgdbd;
	bool mork = true;
	[SerializeField] Object discard;

	void Start()
	{
		amount++;
	}

	void OnMouseDown()
	{
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, 1)), out hit, 100))
		{
			globaloffset = transform.position - hit.point;
			help.anchor = transform.InverseTransformPoint(hit.point);
			mousethingy.they = transform.position.z - globaloffset.z;
		}

		if (areyoubusy)
			r = transform.position;
	}

	void OnMouseUp()
	{
		if (areyoubusy)
		{
			physcube.that.endsequence();
			gameObject.SetActive(false);
		}

		help.xMotion = help.yMotion = help.zMotion = ConfigurableJointMotion.Free;
		help.anchor = Vector3.zero;
		count = false;
		rgdbd.AddForce(mousethingy.offsetto * 5, ForceMode.VelocityChange);
	}

	void OnMouseDrag()
	{
		if (areyoubusy && Vector3.Distance(transform.position, r) >= 3)
		{
			physcube.that.endsequence();
			gameObject.SetActive(false);
		}

		if (count == true)
			help.xMotion = help.yMotion = help.zMotion = ConfigurableJointMotion.Locked;

		count = true;
		mousethingy.dist = transform.position - globaloffset;
	}

	void OnCollisionEnter(Collision other)
	{
		sauce.pitch = Random.Range(0.7f, 0.9f);
		sauce.PlayOneShot(physcube.that.impacts[Random.Range(0, 5)], other.relativeVelocity.magnitude * 0.07f);
	}

	private void OnBecameInvisible()
	{
		asdlkjf();
		gameObject.SetActive(false);
	}

	public void asdlkjf()
	{
		if (mork)
		{
			if (areyoubusy)
			{
				physcube.that.endsequence();
			}
			else
			{
				Instantiate(discard, transform.position, Quaternion.identity);
				if (--amount == 1)
					foreach (GameObject go in GameObject.FindGameObjectsWithTag("CubeFace"))
						if (go != gameObject)
							(go.GetComponent(typeof(physmousedrag)) as physmousedrag).areyoubusy = true;
			}
			mork = false;
		}
	}
}
