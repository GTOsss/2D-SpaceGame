using UnityEngine; 
using System.Collections;

[ExecuteInEditMode]
public class CameraScr : MonoBehaviour {

    public float Zoom = 2;

    static CameraScr camscr;
    public static CameraScr cameraScr { get { return camscr; } }

    void Awake()
    {
        camscr = this;
        gameObject.GetComponent<Camera>().orthographicSize = Screen.height / Zoom;
    }

	void Start ()
    {
	
	}
	
	void Update ()
    {

	}
}
