using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI timeFinalText;
    private float time = 0f;

    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;

    public Button playButton;
    public Button exitButton;
    public Button replayButton;

    public AudioClip jumpSound;
    public AudioSource audioSource;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotateForce = 5;
    //[SerializeField] private float moveForce = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] private bool isGameActive = true;
    [SerializeField] private bool isWin = false;

    void Awake()
    {
        playButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(Exit);
        replayButton.onClick.AddListener(Restart);

    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Time.timeScale = 0f;
        gameWinScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time : " + time.ToString("0.00");
        timeFinalText.text = "Time : " + time.ToString("0.00");

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
            audioSource.PlayOneShot(jumpSound);
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
        Destroy(timeText);
    }

    public void Restart()
    {
        //SceneManager.LoadScene("Main");
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
}
