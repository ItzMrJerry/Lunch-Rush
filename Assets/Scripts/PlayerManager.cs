using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int Score;
    public int Combo;

    public TextMeshProUGUI ScoreGame;
    public TextMeshProUGUI ComboGame;
    public TextMeshProUGUI ScoreEnd;
    public TextMeshProUGUI Hi_Combo;
    public Animator anim;
    private PlayerMovement PMovement;

    public GameObject finishMenu;

    public BossBehaviour boss;
    private int Hi_combo;
    private void Start()
    {
        PMovement = GetComponent<PlayerMovement>();
    }
    public void AddScore(int score)
    {
        Score += score;
        
        ScoreGame.text = "Score " + Score;
        
    }
    public void AddCombo(bool isCombo)
    {
        if (Combo > Hi_combo)
        {
        Hi_combo = Combo;

        }
        if (isCombo)
        {
            Combo++; 
            ComboGame.text = "combo " + Combo;
        }
        else
        {
            Combo = 0;
            
            ComboGame.text = "";
            
        }
    }
    public void AttackAnim()
    {
        int animNumber = Random.Range(0, 2);
        if (animNumber == 0)
        {
            anim.Play("AttackAnimTemp");
        }
        if (animNumber == 1)
        {
            anim.Play("Attack2AnimTemp");
        }
        PMovement.CancelGravity();
    }
    public void IsGrounded(bool isgrounded)
    {
        anim.SetBool("IsGrounded",isgrounded);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FinishLine")
        {
            finishMenu.SetActive(true); 
        }
        
        if (collision.gameObject.name == "BossTrigger")
        {
            boss.AttackMode = true;
            ScoreEnd.text = "Score <color=yellow>" + Score;
            Hi_Combo.text = "hi-combo <color=yellow>" + Hi_combo;
        }
    }
}
