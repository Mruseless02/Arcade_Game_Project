using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Security.Cryptography.X509Certificates;

public class Typer : MonoBehaviour
{
    public Wordbank wordbank = null;
    public TMP_Text wordOutput;
    private Animator animator;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    public GameObject[] Projectile;
    public GameObject[] Magic_Skill;
    public int count = 0;
    private int Heal = 10;
    public Transform ProjectileTransform;
    public Transform Skill;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {   
        animator = GetComponent<Animator>();
        SetCurrentWord();
    }
    private void SetCurrentWord()
    {
        currentWord = wordbank.GetWord();
        SetRemainingWord(currentWord);
        
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.FindWithTag("Enemy");
        Skill = Enemy.transform;
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            if (keyPressed.Length == 1)
            {
                EnterLetter(keyPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (isWordComplete())
            {
                GetComponent<Player_Hp>();
                Player_Hp player_Hp = GetComponent<Player_Hp>();
                player_Hp.Healing(Heal);
                var Magic = Random.Range(0, Projectile.Length);
                animator.SetTrigger("Attack");
                if(count < 3)
                {
                    Instantiate(Projectile[Magic], ProjectileTransform.position, Quaternion.identity);
                    count++;
                }
                else if (count >= 3)
                {
                    var skill = Random.Range(0, Magic_Skill.Length);
                    Instantiate(Magic_Skill[skill], Skill.position, Quaternion.identity); count = 0;
                }
                SetCurrentWord();
            }
        }
    }
    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    public bool isWordComplete()
    {
        return remainingWord.Length == 0;
    }
}
