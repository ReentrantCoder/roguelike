using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// scene transitions for UI
	public void ChangeToScene (string scene) {
        Application.LoadLevel(scene);
	}

    //Quit game from UI
    public void QuitGame()
    {
        Application.Quit();
    }

}
