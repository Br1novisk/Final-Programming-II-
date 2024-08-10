using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Singleton

    public static PlayerController instance;

    void Awake()
    {
        instance = this; 
        if( this  != instance)
        {
            Destroy(gameObject);
        }
        currentHealth = maxHealth;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

    }

    #endregion

    public GameObject player;

    [SerializeField] float MoveSpeed = 5.0f;
    [SerializeField] float LookSpeed = 2.0f;
    [SerializeField] float JumpForce = 5.0f;

    private float _rotationX = 0.0f;
    private bool _isGrounded = true;
    private float _mouseX;

    [SerializeField] private float maxHealth;
    [HideInInspector] 
    public float currentHealth;


    void FixedUpdate()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * MoveSpeed * Time.deltaTime;
        transform.Translate(movement);

        float mouseDeltaX = Input.GetAxis("Mouse X") * LookSpeed;
        _mouseX += mouseDeltaX;

        float mouseY = Input.GetAxis("Mouse Y") * LookSpeed;

        _rotationX -= mouseY;
        float rotationY = Mathf.Clamp(_rotationX, -70f, 70f);

        transform.localRotation = Quaternion.Euler(0, _mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        //Debug.Log(rotationY);
        //Debug.Log(Camera.main.transform.localRotation);

        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    //Damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You died");
        // Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}