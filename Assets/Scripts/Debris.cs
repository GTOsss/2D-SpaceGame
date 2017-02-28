using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {

    public float ImpulsMin = 5, ImpulsMax = 75;
    public float xDirMin = -1, xDirMax = 1; 
    public float yDirMin = -1, yDirMax = 1;


    void Start ()
    {
        float impuls = Random.Range(ImpulsMin, ImpulsMax);
        float xDir = Random.Range(xDirMin, xDirMax);
        float yDir = Random.Range(yDirMin, yDirMax);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(xDir * impuls, yDir * impuls), ForceMode2D.Impulse);
        Destroy(gameObject, Random.Range(1,100) / 10f);
    }

    void Update ()
    {
	
	}
}
