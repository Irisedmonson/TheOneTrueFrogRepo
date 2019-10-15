using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Text flyAmountText;
    public bool isGrounded = false;

    private int _flyAmount;
   

   

    void Start()
    {
        _flyAmount = 0;
        AddFlyCount();
    }

   // Jump Input Code
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // picks up and counts flys
        if (other.gameObject.CompareTag("Fly"))
        {
            other.gameObject.SetActive(false);
            _flyAmount = _flyAmount + 1;
            AddFlyCount();
        }
    }

    //Jump Action Code
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse); 
        }
    }

    void AddFlyCount()
    {
        flyAmountText.text = "Flys: " + _flyAmount.ToString();
    }

}
