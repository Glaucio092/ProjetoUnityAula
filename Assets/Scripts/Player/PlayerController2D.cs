using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement")]
    // valores de velocidade de deslocamento e salto
    public  float moveSpeed = 5f;
    public  float jumpForce = 8f;

    [Header("Animator")]
    public Animator anim;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // unity vai procurar o componente Rigidbody no comeco da cena 
       rb = GetComponent<Rigidbody2D>(); 
       if (anim == null) anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      // --- salto---
      // --- salto esta mapeado na barra de espaco
      if (Input.GetButtonDown("Jump") && isGrounded)
      {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
      }  

      anim.SetFloat("Speed", Mathf.Abs(moveInput));
      anim.SetBool("IsGrounded", isGrounded);
    }
    void FixedUpdate()
    {
        // --- movimento horizontal ---
    float moveInput = Input.GetAxis("Horizontal");
    rb.linearVelocity = new Vector2(moveInput * moveSpeed,rb.linearVelocity.y);

    }
    // --- verificar o chao
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        isGrounded = false;
    }
}
