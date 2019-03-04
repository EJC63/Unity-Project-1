using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
	public GameObject top, bottom;
	public float velocity;
	
	private float endPosition, spriteHeight;
	
    // Start is called before the first frame update
    void Start()
    {
    	spriteHeight = bottom.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
    	endPosition = top.transform.position.y + spriteHeight;
    	bottom.transform.position = new Vector2(bottom.transform.position.x, bottom.transform.position.y + spriteHeight);
        
    }

    // Update is called once per frame
    void Update()
    {
    	movePiece(bottom);
    	movePiece(top);
    	
    	if (top.transform.position.y >= endPosition) {
    		resetPiece(top);
    	}
    	if (bottom.transform.position.y >= endPosition) {
    		resetPiece(bottom);	
    	}
    	
    	
        
    }
    
	void resetPiece(GameObject piece) {
		piece.transform.position = new Vector2(piece.transform.position.x, piece.transform.position.y - spriteHeight * 2);
	}
	void movePiece(GameObject piece) {
		piece.transform.Translate(new Vector2(0f, transform.up.y * (velocity/100)));
	}
		

	
}
