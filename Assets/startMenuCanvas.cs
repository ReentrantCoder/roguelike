using UnityEngine;
using System.Collections;

public class startMenuCanvas : MonoBehaviour {

    public GameObject menuCanvas, scoreCanvas;

    void Awake()
    {
        menuCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
    }

    void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            menuCanvas.SetActive(true);
            scoreCanvas.SetActive(false);
        }
    }

    public void showScoreCanvas()
    {
            menuCanvas.SetActive(false);
            scoreCanvas.SetActive(true);
    }
}
