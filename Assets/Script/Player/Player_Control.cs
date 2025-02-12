using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
    public Transform StartPos;
    private Scene scene;
    public string currentScene;
    public ParticleSystem particle;
    private ParticleSystem particleInstance;
    private sceneManager sceneManager;
    public int currentPoints = 0;
    public int currentHp;
    public int enemyKilled;
    public float force;
    public float jumpPwr;
    public float climb;
    private float Timer;
    public bool isJumping = false;
    private bool isClimbing = false;
    public bool Have_Key = false;
    public int keys;
    public bool combat;
    private float fallTreshold = -5f;
    public GameObject ParticleSpawn;
    private bool isFalling;
    [SerializeField] private bool useSpawnPoint = true;
    public bool CanMove = true;
    private float CheckDelay;
    // Start is called before the first frame update
    void Start()
    {
        if (useSpawnPoint)
        {
            if (transform.position == Vector3.zero)
            {
                transform.position = StartPos.position;
            }
        }
        scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        CanMove = true;
        updateHighscore();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        combat = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDelay = Time.fixedTime;
        currentHp = GetComponent<Player_Hp>().HP;
        fallCheck();
        Keys.SetText(keys.ToString());
        Point.SetText(currentPoints.ToString());
        PointStoreage.TotalHp = currentHp;
        if(CheckDelay > 0.5f)
        {
            EnemyCheck();
            CheckDelay = 0;
        }
        if (!combat && CanMove)
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
        this.currentScene = data.Scene;
        this.keys = data.keyCount;
        this.currentHp = data.HpCount;
        this.currentPoints = data.PointCount;
        this.enemyKilled = data.enemyKilledCount;
    }

    public void SaveData(ref GameData data)
    {
        data.Scene = this.currentScene;
        data.enemyKilledCount = this.enemyKilled;
        data.HpCount = this.currentHp;
        data.keyCount = this.keys;
        data.PointCount = this.currentPoints;
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

    private void EnemyCheck()
    {
        var enemy = GameObject.FindWithTag("Enemy");

        if(enemy != null)
        {
            combat = true;
        }
        else if(enemy == null)
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

    public void KeyCheck(int key)
    {
        this.keys += key;
        if(keys <= 0)
        {
            Have_Key = false;
        }
        else if(keys >= 1)
        {
            Have_Key=true;
        }
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

    private void ClimbingLadder()
    {
        AudioManager.PlayAudio(SoundType.StairClimbing);
    }
}