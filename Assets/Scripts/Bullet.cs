using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public bool ExplosionImpulse = false;
    public bool IsExplosionDebris = false;
    public int ImpulseCoif = 1;

    public GameObject Particles;
    public GameObject ParticlesTEST;
    public GameObject ParticlesTEST2;
    public GameObject Light;

    public int CountDebris1 = 30;
    public int CountDebris2 = 30;

    Rigidbody2D RigiBullet; 

    void Awake()
    {
        RigiBullet = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        float cosX = Mathf.Cos((gameObject.transform.eulerAngles.z + 90) * Mathf.PI / 180);
        float sinY = Mathf.Sin((gameObject.transform.eulerAngles.z + 90) * Mathf.PI / 180);

        RigiBullet.velocity = new Vector2(cosX * 500, sinY * 500);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            Hit(coll);
    }

    void Hit(Collision2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

        Instantiate(Particles, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, -597), transform.rotation);
        Instantiate(ParticlesTEST, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, -598), transform.rotation);
        Instantiate(ParticlesTEST2, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, -599), transform.rotation);

        if(Light != null)
            Instantiate(Light, new Vector3(transform.position.x, transform.position.y, transform.position.z - 20), transform.rotation);


        if (ExplosionImpulse && col.transform.parent != null)
        {
            for (int i = 0; i < col.transform.parent.childCount; i++)
            {
                Impulse impulse = col.transform.parent.GetChild(i).GetComponent<Impulse>();

                if (impulse != null)
                {
                    impulse.ImpulsePowerMin *= ImpulseCoif;
                    impulse.ImpulsePowerMax *= ImpulseCoif;
                    impulse.IsCollision = true;
                }
            }
        }

        Destroy(gameObject);
        Destroy(col.gameObject, 0.1f);

        if(IsExplosionDebris)
            ExplosionDebris(col);
    }

    void ExplosionDebris(Collision2D col)
    {
        Clash clash = col.gameObject.GetComponent<Clash>();

        for (int i = 0; i < CountDebris1; i++)
        {
            Instantiate(clash.Debris1, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, -599), transform.rotation);
        }

        for (int i = 0; i < CountDebris2; i++)
        {
            Instantiate(clash.Debris2, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, -599), transform.rotation);
        }
    }


}
