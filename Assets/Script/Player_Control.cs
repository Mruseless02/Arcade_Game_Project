using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour, IDataPresistence
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField]
    private TMP_Text Point;
    [SerializeField]
    private TMP_Text Keys;
    [SerializeField]
    private TMP_Text Highscore;
    [SerializeField]
    private Scene scene;
    public string currentScene;
    public ParticleSystem particle;
    private ParticleSystem particleInstance;
    private sceneManager sceneManager;
    public int currentPoints = 0;
    public int currentHp;
    public float force;
    public float jumpPwr;
    public float climb;
    private float Timer;
    private bool isJumping = false;
    private bool isClimbing = false;
    public bool Have_Key = false;
    public int keys;
    public bool combat;
    private float fallTreshold = -5f;
    public GameObject ParticleSpawn;
    private bool isFalling;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        updateHighscore();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        combat = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentHp = GetComponent<Player_Hp>().HP;
        fallCheck();
        Keys.SetText(keys.ToString());
        Point.SetText(currentPoints.ToString());
        Timer += Time.deltaTime;
        combatMode();
        PointStoreage.TotalHp = currentHp;
        if (!combat)
        {
            GetComponent<Typer>().enabled = false;
            playerMove();
        }
        else if (combat)
        {
            GetComponent<Typer>().enabled = true;
        }
    }

    public void LoadData(GameData data)
    { 
        this.currentHp = data.HpCount;
        this.currentPoints = data.PointCount;
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.HpCount = this.currentHp;
        data.PointCount = this.currentPoints;
        data.playerPosition = this.transform.position;
    }

    private void fallCheck()
    {
        if (rb.velocity.y > fallTreshold)
        {
            isFalling = false;
        }
        else if (rb.velocity.y < fallTreshold && !isClimbing)
        {
            animator.Play("Player@Fall");

            CreateParticle();

            isFalling = true;
        }
    }
    private void combatMode()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            combat = false;
        }
    }

    private void playerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-force, rb.velocity.y);
            CreateParticle();
            sprite.flipX = true;
            animator.Play("Player@Run");
            Timer = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(force, rb.velocity.y);

            CreateParticle();

            sprite.flipX = false;
            animator.Play("Player@Run");
            Timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            animator.Play("Player@Jump");

            CreateParticle();

            rb.AddForce(Vector2.up * jumpPwr);
            Timer = 0;
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.W) && isClimbing)
        {
            animator.Play("Player@Climb");
            rb.velocity = new Vector2(rb.velocity.x, climb);
            Timer = 0;
        }
        if (Input.GetKey(KeyCode.S) && isClimbing)
        {
            animator.Play("Player@ClimbDown");
            rb.velocity = new Vector2(rb.velocity.x, -climb);
            Timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.GetChild(2).gameObject.SetActive(true);
            Timer = 0;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            transform.GetChild(2).gameObject.SetActive(false);
            Timer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnActive"))
        {
            combat = true;
        }
        if (collision.CompareTag("Stairs"))
        {
            isClimbing = true;
            rb.gravityScale = 0f;
        }
        if (collision.CompareTag("Traps"))
        {
            isJumping = false;
        }
    }
    public void PointsGain(int Points)
    {
        this.currentPoints += Points; Debug.Log("PointGain");
        PointStoreage.TotalPoint = currentPoints;
        HighScore();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stairs"))
        {
            isClimbing = false;
            rb.gravityScale = 10f;
        }
    }

    public void KeyCheck(int key)
    {
        keys = PointStoreage.Keys;
        this.keys += key;
        if(keys <= 0)
        {
            Have_Key = false;
        }
        else if(keys >= 1)
        {
            Have_Key=true;
        }
        PointStoreage.Keys = keys;
    }
    private void HighScore()
    {
        if (currentPoints > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", currentPoints);
        }
    }

    private void updateHighscore()
    {
        Highscore.text = $"Highscore : {PlayerPrefs.GetInt("Highscore", 0)}";
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void CreateParticle()
    {
        Quaternion Rotation = Quaternion.FromToRotation(Vector2.right, rb.velocity);
        if(GameObject.FindWithTag("Particle") == null)
        {
            particleInstance = Instantiate(particle, ParticleSpawn.transform.position, Rotation);
            particleInstance.transform.parent = ParticleSpawn.transform;
        }
        
    }
    private void PlaySound()
    {
        AudioManager.PlayAudio(SoundType.Steps);
    }
}