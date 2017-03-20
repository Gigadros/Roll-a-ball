using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    int count;
	//float moveHorizontal, moveVerticle;
	Vector3 movement;
    public float speed;
    public Text countText, winText;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        count = 0;
		//moveHorizontal = 0f;
        //moveVerticle = 0f;
		movement = new Vector3(0f,0f,0f);
    }

    void Start()
    {
        SetCountText();
    }

    void FixedUpdate () {
        //moveHorizontal = Input.GetAxis("Horizontal");
        //moveVerticle = Input.GetAxis("Vertical");
        //movement.x = moveHorizontal;
		//movement.z = moveVerticle;
		movement.x = Input.GetAxis("Horizontal");
		movement.z = Input.GetAxis("Vertical");
        rb.AddForce(movement * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = count.ToString();
        if(count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}