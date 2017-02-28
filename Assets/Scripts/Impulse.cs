using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Impulse : MonoBehaviour {

    public bool IsCollision = false;

    public float MinDiractionX = -10, MaxDirectionX = 10, 
                 MinDirectionY = 5, MaxDirectionY = 15, 
                 ImpulsePowerMin = 5, ImpulsePowerMax = 75;

	void Start ()
    {
        	
	}
	
	void Update ()
    {

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (IsCollision)
        {
            float randX = Random.Range(MinDiractionX, MaxDirectionX),
                  randY = Random.Range(MinDirectionY, MaxDirectionY),
                  randPower = Random.Range(ImpulsePowerMin, ImpulsePowerMax);

            coll.transform.parent = null;
            Rigidbody2D rigidbody = coll.gameObject.GetComponent<Rigidbody2D>();

            if (rigidbody != null)
            {
                rigidbody.isKinematic = false;
                rigidbody.AddForce(new Vector2(randX * randPower, randY * randPower), ForceMode2D.Impulse);
            }
        }
    }
}
