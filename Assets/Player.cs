using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
	public Text Score;
	public Text Message;
	public Slider Health;
	private int PlayerScore = 0;
	private Rigidbody2D rb;
	private float Bounds = 7f;
	public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	if (transform.position.x > Bounds)
    	{
    		transform.position = new Vector3(Bounds, transform.position.y, -1f);
    		rb.velocity = new Vector2(0, 0);
    	
    	}else if (transform.position.x < -Bounds)
    	{
    		transform.position = new Vector3(-Bounds, transform.position.y, -1f);
    		rb.velocity = new Vector2(0, 0);
    	}
    	
        
    }
    
	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
		{
			rb.AddForce(Vector2.left * speed);
		}
		if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
		{
			rb.AddForce(Vector2.right * speed);
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Coin")
		{
			Debug.Log("CoinPickUp");
			col.gameObject.SetActive(false);
			PlayerScore += 10;
			Score.text = "Score: "+ PlayerScore;
		}
		if (col.tag == "Anchor")
		{
			Debug.Log("AnchorHit");
			col.gameObject.SetActive(false);
		}
	}
		
}
