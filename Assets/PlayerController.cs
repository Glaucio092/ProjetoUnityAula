using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 15f; // Para o movimento não ser "seco"
    
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Captura a entrada do teclado (A/D ou Setas)
        moveInput = Input.GetAxisRaw("Horizontal");

        // Lógica para virar o sprite
        if (moveInput > 0 && !facingRight) Flip();
        else if (moveInput < 0 && facingRight) Flip();
    }

    void FixedUpdate()
    {
        // Movimenta a Ellen fisicamente
        float targetSpeed = moveInput * moveSpeed;
        rb.linearVelocity = new Vector2(Mathf.MoveTowards(rb.linearVelocity.x, targetSpeed, acceleration * Time.fixedDeltaTime), rb.linearVelocity.y);
        
        // Envia a velocidade real para o Animator (Isso controla a transição!)
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}