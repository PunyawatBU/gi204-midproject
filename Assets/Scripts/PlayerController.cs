using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;

    public Button playButton;
    public Button exitButton;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotateForce = 5;
    //[SerializeField] private float moveForce = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] private bool isGameActive = true;
    [SerializeField] private bool isWin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        playButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(Exit);
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Time.timeScale = 0f;
        gameOverScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(moveForce * Vector3.forward);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(moveForce * Vector3.back);
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(moveForce * Vector3.left);
            transform.Rotate(Vector3.down * Time.deltaTime * rotateForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(moveForce * Vector3.right);
            transform.Rotate(Vector3.up * Time.deltaTime * rotateForce);
            
        }

        if (Input.GetKey(KeyCode.Space)&& isOnGround)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            isOnGround = false;
        }

        if (!isGameActive)
        {
            GameOver();
        }
        if (isWin)
        {
            GameWin();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            isGameActive = false;
        }
        if (collision.gameObject.CompareTag("GameOverZone"))
        {
            isGameActive = false;
        }
        if (collision.gameObject.CompareTag("WinZone"))
        {
            isWin = true;
        }

    }
    void Exit()
    {
        Application.Quit();
    }

    void StartGame()
    {
        Time.timeScale = 1f;
        titleScreen.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        gameWinScreen.SetActive(true);
    }

    public void Restart()
    {
        //SceneManager.LoadScene("Main");
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
}
