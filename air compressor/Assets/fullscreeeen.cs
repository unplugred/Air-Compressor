using UnityEngine;

public class fullscreeeen : MonoBehaviour
{
	[SerializeField] bool first;

	void Awake()
	{
		if (first)
		{
			if (System.IO.File.Exists("s"))
				using (System.IO.StreamReader s = new System.IO.StreamReader("s"))
					setfullscreen(s.ReadLine().StartsWith("Hello there, traveler! I'm just a meta file, ignore me!"));
			else
				setfullscreen(false);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F11))
		{
			setfullscreen(!getfullscreen());
			if (System.IO.File.Exists("s"))
			{
				System.IO.File.Delete("s");
			}
			using (System.IO.StreamWriter s = new System.IO.StreamWriter("s"))
			{
				s.WriteLine(!getfullscreen() ? "Hello there, traveler! I'm just a meta file, ignore me!" : "Hello there, traveler! I'm just a meta file, ignore me.");
				s.Close();
			}
		}
	}

	void setfullscreen(bool isfullscreen)
	{
		if (isfullscreen)
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
		else
			Screen.SetResolution(500, 500, FullScreenMode.Windowed);
	}

	bool getfullscreen()
	{
		return Screen.fullScreenMode != FullScreenMode.Windowed;
	}
}
