using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float rotationSpeed;
    private bool canDash = true;

    bool gameover = false;

    Rigidbody2D rb;
    Camera cam;

    public AudioClip audClip;
    public AudioSource audS;

    [SerializeField] Text score;

    float cpt = 0;
    int scr = 0;

    public float dashDistance = 5f;
    public float dashCooldown = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void setScore()
    {
        cpt += Time.deltaTime;
        if (cpt >=.5f)
        {
            cpt = 0f;
            scr++;
            score.text = scr.ToString("000");
        }
    }

    void Update()
    {
        if (!gameover)
        {

            setScore();

            if (Input.GetKey (KeyCode.RightArrow))
            {
                transform.Rotate (Vector3.forward * (-rotationSpeed) * Time.deltaTime);
            }
            else if (Input.GetKey (KeyCode.LeftArrow))
            {
                transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        // Implementasikan dash
        Vector3 dashPosition = transform.position + transform.right * dashDistance;
        // Lakukan pergerakan dash
        transform.position = dashPosition;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void FixedUpdate()
    {
        if (!gameover)
        {
            rb.AddRelativeForce(new Vector3(moveSpeed*Time.fixedDeltaTime, 0f, 0f));
        }   
    }

    IEnumerator DashCooldown(float cooldownTime)
    {
        canDash = false;
        yield return new WaitForSeconds(cooldownTime);
        canDash = true;
    }

    void PerformDash()
    {
        if (canDash)
        {
            // Implementasi dash (misalnya, menambah kecepatan sementara)
            Debug.Log("Dash performed!");
            StartCoroutine(DashCooldown(5f)); // 5 detik cooldown
        }
        else
        {
            Debug.Log("Dash is on cooldown!");
        }
    }

    void LateUpdate()
    {
        if (!gameover)
        {
            cam.transform.position = new Vector3 (transform.position.x, transform.position.y, cam.transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Coin") && !gameover)
        {
            gameover = true;
            PlayerData playerData = GetComponent<PlayerData>();
            playerData.SaveCoins(); // Simpan koin sebelum pemain mati

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInChildren<ParticleSystem>().Play();
            audS.PlayOneShot(audClip);
            Invoke("Restart", 2f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void IncreaseSpeed(float amount)
    {
        moveSpeed += amount;
        Debug.Log("move speed: +" + moveSpeed);
    }

}
