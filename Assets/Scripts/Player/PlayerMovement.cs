using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    public float TopLocationY;
    public float BottemLocationY;

    public Transform PlayerVisual;
    private Animator anim;
    public bool isGrounded = true;
    public float AirTime;
    private PlayerManager PM;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        PM = GetComponent<PlayerManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            DashUp();
            CancelGravity();
        }
        if (Input.GetKeyDown(KeyCode.F) && !isGrounded || Input.GetKeyDown(KeyCode.E) && !isGrounded)
        {
            DashDown();
        }
    }

    public void CancelGravity()
    {
        StopAllCoroutines();
        StartCoroutine(Gravity());
    }

    private void DashUp()
    {
        anim.Play("DashUp");
        isGrounded = false;
        PM.IsGrounded(false);
            
        
    }
    private void DashDown()
    {
        anim.Play("DashDown");
        isGrounded = true;
        PM.IsGrounded(true);
    }
    IEnumerator Gravity()
    {
       
        yield return new WaitForSeconds(AirTime);
        DashDown();


    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(Speed * Time.deltaTime,0,0);
    }
}
