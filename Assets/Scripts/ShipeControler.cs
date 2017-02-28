using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipeControler : MonoBehaviour {

    public int SpeedShip = 20;
    public GameObject Bullet;
    public GameObject Bullet2;

    public float SpeedMoveForward = 10;
    public float SpeedMoveBack = 2;
    public float SpeedTurn = 10;

    public float RPM1 = 1;
    public float RPM2 = 1;

    float TimerRpm1 = 0;
    float TimerRpm2 = 0;

    float CameraWidth = 0, PlayerWidth = 0, BackgroundWirth = 0;
    static float MaxMoveX = 0, MinMoveX = 0, BackgroundPosX = 0;
    float cosX, sinY;

    public static float minMoveX { get { return MinMoveX; } }
    public static float maxMoveX { get { return MaxMoveX; } }
    public static float backgroundPosX { get { return BackgroundPosX; } }

    Rigidbody2D RigiPlayer;
    List<Transform> Childs = new List<Transform>();
    Transform PointGun1;
    Transform PointGun2;
    Transform PointGun3;

    void Awake()
    {
        RigiPlayer = gameObject.GetComponent<Rigidbody2D>();
        Childs.AddRange(gameObject.GetComponentsInChildren<Transform>());

        foreach (Transform el in Childs)
        {
            if (el.name.Split('_').Length >= 2)
            {
                switch (el.name.Split('_')[1])
                {
                    case "1":
                        PointGun1 = el;
                        break;
                    case "2":
                        PointGun2 = el;
                        break;
                    case "3":
                        PointGun3 = el;
                        break;
                }
            }
        }
    }

    void Start ()
    {
    }

    void Update ()
    {
        

        ClickHandler();
    }

    void OnCollisionEnter2D(Collision2D  col)
    {
        Debug.Log(Mathf.Abs(col.relativeVelocity.x - col.relativeVelocity.y));
    }

    void ClickHandler()
    {
        cosX = Mathf.Cos((gameObject.transform.eulerAngles.z + 90) * Mathf.PI / 180);
        sinY = Mathf.Sin((gameObject.transform.eulerAngles.z + 90) * Mathf.PI / 180);

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            Move(KeyCode.W);
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            Move(KeyCode.S);

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            Move(KeyCode.A);
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            Move(KeyCode.D);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
            Fire(KeyCode.LeftShift);
        else if (Input.GetKey(KeyCode.Space))
            Fire(KeyCode.Space);

    }

    void Move(KeyCode key)
    {
        if (key == KeyCode.W)
        {
            RigiPlayer.AddForce(new Vector2(cosX * SpeedMoveForward, sinY * SpeedMoveForward), ForceMode2D.Impulse);
        }
        else if (key == KeyCode.S)
        {
            RigiPlayer.AddForce(new Vector2(cosX * SpeedMoveBack * -1, sinY * SpeedMoveBack * -1), ForceMode2D.Impulse);
        }

        if (key == KeyCode.A)
        {
            RigiPlayer.AddTorque(SpeedTurn, ForceMode2D.Impulse);
        }
        else if (key == KeyCode.D)
        {
            RigiPlayer.AddTorque(SpeedTurn * -1, ForceMode2D.Impulse);
        }

    }

    void Fire(KeyCode key)
    {
        if (key == KeyCode.LeftShift && Time.time >= TimerRpm1)
        {
            Instantiate(Bullet, PointGun2.position, PointGun2.rotation);
            Instantiate(Bullet, PointGun3.position, PointGun3.rotation);
            TimerRpm1 = Time.time + RPM1 / 10;
            RigiPlayer.AddForce(new Vector2(cosX * -500, sinY * -500), ForceMode2D.Impulse);
        }

        if (key == KeyCode.Space && Time.time >= TimerRpm2)
        {
            TimerRpm2 = Time.time + RPM2 / 10;
            Instantiate(Bullet2, PointGun1.position, PointGun1.rotation);
        }
    }

}
