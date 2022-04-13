using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossBehaviour : MonoBehaviour
{
    public string Boss_Name;
    public float health;
    public float AttackTime;
    public Vector3 offeset;
    public bool AttackMode;
    

    public BossClass boss = new BossClass("", 0, 0);

   
    private GameObject player;
    private float time;
    public bool TimeUp;
    public GameObject FinishMenu;
    private Animator anim;
    public TextMeshProUGUI CaughtThiefText;
    private AudioSource aud;
    void Start()
    {

        player = GameObject.Find("Player");
        boss.Name = Boss_Name;
        boss.Health = health;
        boss.AttackTime = AttackTime;
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        #region CloseUp Attacking
        if (AttackMode && !TimeUp)
        {

            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("HitAnimColored");
                boss.TakeDamage(1);
                GameObject audioPlayer = new GameObject();
                GameObject go = Instantiate(audioPlayer);
                go.AddComponent<AudioSource>();
                AudioSource punchsound = go.GetComponent<AudioSource>();
                punchsound.volume = Random.Range(0.05f, 0.15f);
                punchsound.pitch = Random.Range(0.8f, 1);
                punchsound.clip = aud.clip;
                punchsound.Play();
                Destroy(go.gameObject, 1f);


                Debug.Log(boss.Health);
                if (boss.Death)
                {
                    FinishMenu.SetActive(true);
                    player.GetComponent<PlayerManager>().Score += 8000;
                    CaughtThiefText.text = "You caught the thief!";
                    Destroy(gameObject);
                }
            }

            time = time + Time.deltaTime;
            if (time >= AttackTime && !TimeUp)
            {
                Debug.Log("You Lost");
                TimeUp = true;
                CaughtThiefText.text = "You didn't catch the thief!";
            }
        }

        if (TimeUp && GetComponent<SpriteRenderer>().enabled != false)
        {
            FinishMenu.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
        }
        #endregion


        //Change Position of boss(Related with attackmode)
        if (AttackMode && offeset.x != 3)
        {
            offeset.x = 3;
        }
        else if (!AttackMode && offeset.x != 15)
        {
            offeset.x = 15f;
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offeset.x, 0 + offeset.y, 0);
    }
}
