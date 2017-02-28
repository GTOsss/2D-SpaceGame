using UnityEngine;
using System.Collections;

public class Clash : MonoBehaviour {

    public GameObject Debris1;
    public GameObject Debris2;
    public float CountDebris1 = 1;
    public float CountDebris2 = 1;

    void Start ()
    {
	
	}
	
	void Update ()
    {
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Enemy")
            MiniExplosion(collision);
    }

    void MiniExplosion(Collision2D col)
    {
        float scale = Mathf.Abs(col.relativeVelocity.x - col.relativeVelocity.y) * 2;
        scale = Mathf.Clamp(scale, 4, 14);

        if (Debris1 != null)
            for (int i = 0; i < CountDebris1; i++)
            {
                ((GameObject)Instantiate(Debris1, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, -599), transform.rotation)).transform.localScale = new Vector3(scale, scale, scale);
            }

        float scale2 = Mathf.Abs(col.relativeVelocity.x - col.relativeVelocity.y) / 4;
        scale2 = Mathf.Clamp(scale, 30, 35);

        if (Debris2 != null)
            for (int i = 0; i < CountDebris2; i++)
            {
                ((GameObject)Instantiate(Debris2, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, -599), transform.rotation)).transform.localScale = new Vector3(scale2, scale2, scale2);
            }
    }
}
