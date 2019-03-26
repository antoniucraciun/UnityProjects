using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Player : MovingObject {

    public int wallDamage = 1;
    public int damage = 1;
    public int pointsPerFood = 20;
    public int pointsPerSoda = 40;
    public float restartDelay = 1f;
    public Text foodText;

    private Animator animator;
    private int food = 0;

    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip eatSound1;
    public AudioClip eatSound2;
    public AudioClip drinkSound1;
    public AudioClip drinkSound2;
    public AudioClip gameOver;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        food = GameManager.instance.foodPoints;
        foodText.text = "Food: " + food;
        base.Start();
    }

    private void Update()
    {
        if (!GameManager.instance.playerTurn)
        {
            return;
        }
        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            vertical = 0;
        }
        if (horizontal != 0 || vertical != 0)
        {
            if (AttemptMove<Wall>(horizontal, vertical)== false)
            {
                AttemptMove<Enemy>(horizontal, vertical);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            Invoke("Restart", restartDelay);
            enabled = false;
        }
        else if (collision.tag == "Food")
        {
            food += pointsPerFood;
            foodText.text = "+" + pointsPerFood + " Food: " + food;
            SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Soda")
        {
            food += pointsPerSoda;
            foodText.text = "+" + pointsPerSoda + " Food: " + food;
            SoundManager.instance.RandomizeSfx(drinkSound1, drinkSound2);
            collision.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        GameManager.instance.foodPoints = food;
    }

    protected override bool AttemptMove<T>(int xDir, int yDir)
    {
        food--;
        GameManager.instance.playerTurn = false;
        foodText.text = "Food: " + food;
        bool canMove = base.AttemptMove<T>(xDir, yDir);
        RaycastHit2D hit;
        if (Move(xDir, yDir, out hit))
        {
            SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
        }
        CheckIfGameOver();
        return canMove;
    }

    protected override bool OnCantMove<T>(T component)
    {
        if (component is Wall)
        {
            Wall hitWall = component as Wall;
            hitWall.DamageWall(wallDamage);
            animator.SetTrigger("PlayerChop");
            return true;
        }
        if (component is Enemy)
        {
            Enemy hitEnemy = component as Enemy;
            hitEnemy.TakeDamage(damage);
            animator.SetTrigger("PlayerChop");
            return true;
        }
        return false;
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void LoseFood(int loss)
    {
        animator.SetTrigger("PlayerHit");
        food -= loss;
        foodText.text = "-" + loss + " Food: " + food;
        CheckIfGameOver();
    }

    void CheckIfGameOver()
    {
        if (food <= 0)
        {
            SoundManager.instance.PlaySingle(gameOver);
            SoundManager.instance.musicSource.Stop();
            GameManager.instance.GameOver();
        }
    }

}
