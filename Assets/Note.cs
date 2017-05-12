using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
    Rigidbody2D rb;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
        rb.velocity = new Vector2(0, -4);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
