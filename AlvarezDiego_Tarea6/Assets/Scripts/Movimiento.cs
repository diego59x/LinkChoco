using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D rb2d;
    public Sprite linkH;
    private bool flag = false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //GetComponent<SpriteRenderer>().sprite = linkh;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Jump();

        Vector3 newScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0.0f)
            newScale.x = 1.0f;
        else if (Input.GetAxis("Horizontal") < 0.0f)
            newScale.x = -1.0f;
        transform.localScale = newScale;
    }
    void Jump()
    {
        if (rb2d)
            if (Mathf.Abs(rb2d.velocity.y) < 0.05f)
                rb2d.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        if (rb2d)
        {
            rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal") * 6, 0));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rock2") && (flag == false))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("rock1"))
        {
            flag = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = linkH;
            Destroy(collision.gameObject);
        }
    }
   
}
