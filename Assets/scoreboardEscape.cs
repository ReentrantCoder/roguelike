using UnityEngine;
using System.Collections;

public class scoreboardEscape : MonoBehaviour {
	
	// Take me back to the Start Menu
	public void update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("startMenu");
        }
    }
}
