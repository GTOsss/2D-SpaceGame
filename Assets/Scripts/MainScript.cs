using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class MainScript : MonoBehaviour {

    public GameObject Background1;
    public GameObject Background2;
    public GameObject Background3;
    public GameObject Background4;
    public float BackgroundDistanse = 25;
    public GameObject Player;
    public GameObject Camera;
    public GameObject Enemy;
    public GameObject ClearLeft;
    public GameObject ClearRight;

    static MainScript mainScr;
    public static MainScript mainScript { get { return mainScr; } }

    void Awake()
    {
        Physics2D.IgnoreLayerCollision(8, 9);

        Camera.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, Camera.transform.position.z);
        Player.transform.position = new Vector3(Screen.width / 2, Screen.height / 3, Player.transform.position.z);
        mainScr = this;

        if(Background2 != null)
            Background2.transform.position += new Vector3(0,0, Background1.transform.position.z + BackgroundDistanse * 1);
        if(Background3 != null)
            Background3.transform.position += new Vector3(0,0, Background1.transform.position.z + BackgroundDistanse * 2);
        if(Background4 != null)
            Background4.transform.position += new Vector3(0,0, Background1.transform.position.z + BackgroundDistanse * 3);
    }

    void Start ()
    {

	}
	
	void Update ()
    {
        Camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Camera.transform.position.z);
    }

}
