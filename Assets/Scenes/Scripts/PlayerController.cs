using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public Text countText;
    public Text winText;
    public Text redText;
    public Text orangeText;
    public Text scoreText;

    private int redMushrooms;
    private int orangeMushrooms;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        redMushrooms = 0;
        orangeMushrooms = 0;

        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Orange Mushroom"))
        {
            other.gameObject.SetActive(false);
            orangeMushrooms++;
            SetCountText();
        } else if (other.gameObject.CompareTag("Red Mushroom"))
        {
            other.gameObject.SetActive(false);
            redMushrooms++;
        } 
    }

    void SetCountText()
    {
        countText.text = "Orange Mushrooms: " + (20 - orangeMushrooms).ToString();
        if (orangeMushrooms >= 20)
        {
            winText.text = "You Win!";
            redText.text = "Red Mushrooms: " + redMushrooms.ToString();
            orangeText.text = "Orange Mushrooms: " + orangeMushrooms.ToString();
            scoreText.text = "Score: " + (orangeMushrooms - redMushrooms).ToString();
            countText.text = "";
        }
    }
}
