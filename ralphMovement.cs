
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ralphMovement : MonoBehaviour
{
    private Rigidbody2D ralphRigidBody;
    [SerializeField] private float horSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private bool doubleJump;

    public GameObject RalphEffect;
    private shake cameraShake;

    [SerializeField] private Animator ralphAnim;

    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;

    public bool shielded;
    [SerializeField] private GameObject shield;

    [SerializeField] private float upShootSpeed = 10;
    [SerializeField] private float sideshootSpeed = 20;
    [SerializeField] private float bordershootSpeed = 20;


    [SerializeField] private AudioClip shieldSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip doubleJumpSound;
    [SerializeField] private AudioClip biteSound;
    [SerializeField] private AudioClip fallSound;

    private void Start()
    {
        shielded = false;
        cameraShake = GameObject.FindGameObjectWithTag("ShakeTag").GetComponent<shake>();
        ralphRigidBody = GetComponent<Rigidbody2D>();
        ralphAnim = GetComponent<Animator>();
    }

    private void Awake()
    {
        ralphRigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HealthScript healthScript = GetComponent<HealthScript>();
        if (healthScript != null && healthScript.currHealth <= 0)
        {
            //Debug.Log("Health is zero, reloading scene...");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        float movX = SimpleInput.GetAxis("Horizontal");
        ralphRigidBody.velocity = new Vector2(movX * horSpeed, ralphRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        ralphAnim.SetBool("groundedBool", isGrounded());
    }

    public void Jump()
    {
        if (isGrounded())
        {
            ralphRigidBody.velocity = new Vector2(ralphRigidBody.velocity.x, jumpForce);
            ralphAnim.SetTrigger("RalphJump");
            doubleJump = true;

            //cameraShake.ShakeFunction();

            AudioManager.instance.PlaySound(jumpSound);
        }
        else if (doubleJump)
        {
            ralphAnim.SetTrigger("RalphJump");
            ralphRigidBody.velocity = new Vector2(ralphRigidBody.velocity.x, jumpForce);
            Instantiate(RalphEffect, transform.position, Quaternion.identity);
            doubleJump = false;
            cameraShake.ShakeFunction();

            AudioManager.instance.PlaySound(doubleJumpSound);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool IsShielded()
    {
        return shielded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShieldTag"))
        {
            shield.SetActive(true);
            Debug.Log("shield activated");

            Invoke("CancelShield", 10f);

            AudioManager.instance.PlaySound(shieldSound);


        }

        if (collision.CompareTag("saw"))
        {
            transform.Translate(Vector2.right * sideshootSpeed * Time.deltaTime);
            Debug.Log("Shot");

            AudioManager.instance.PlaySound(biteSound);
        }

        if (collision.CompareTag("hole"))
        {
            transform.Translate(Vector2.up * upShootSpeed * Time.deltaTime);
            Debug.Log("Shot");

            AudioManager.instance.PlaySound(fallSound);
        }
        if (collision.CompareTag("border"))
        {
            transform.Translate(Vector2.left * bordershootSpeed * Time.deltaTime);
            Debug.Log("Shot");


        }


    }

    public void CancelShield()
    {
        shield.SetActive(false);
    }



}






