using UnityEngine;
using System.Collections;

public class inGameMenuAccess : MonoBehaviour {

    public GameObject Canvas, InGameMenuCanvas;

    void Awake()
    {
        Canvas.SetActive(true);
        InGameMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Canvas.activeSelf)
            {
                Canvas.SetActive(false);
                InGameMenuCanvas.SetActive(true);
            }
            else
            {
                Canvas.SetActive(true);
                InGameMenuCanvas.SetActive(false);
            }
        }
    }

}
