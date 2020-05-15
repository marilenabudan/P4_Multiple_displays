using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;

    private Rigidbody rb;
    private int count;
    private bool gameOn;

    void Start ()
    {
      rb = GetComponent<Rigidbody>();
      gameOn = true;
      count = 0;
      SetCountText();

    }

    void FixedUpdate()
    {
     
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);

        if (rb.position.y < -1f){
            Restart();
        }

        if (!gameOn)
        {
            rb.Sleep();
         
        }
    
      
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Pick up gold")){
        other.gameObject.SetActive(false);
        count = count + 5;
        SetCountText();
      }
      if (other.gameObject.CompareTag("Pick up rose")){
        other.gameObject.SetActive(false);
        count = count + 3;
        SetCountText();
      }
      if (other.gameObject.CompareTag("Pick up blue")){
        other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
      }
    }

    void SetCountText()
    {
      countText.text = count.ToString();
      if (count >= 36){
            gameOn = false;
            Invoke("Restart", 2f);
      }
    }

    void Restart()
    {
        FindObjectOfType<GameManager>().Restart();
    }
}
