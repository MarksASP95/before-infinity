using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myRigidBody;
    public Movement movement;
    public IUnityService unityService;
    private Vector3 change;
    private Animator animator;
    public AudioSource SwingAudioSrc, DeathAudioSrc;
 

    void Start( )
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        movement = new Movement(speed);
        if (unityService == null)
            unityService = new UnityService();
    }

    private void Update()
    {
        change = Vector2.zero;
        change.x = unityService.GetAxisRaw("Horizontal");
        change.y = unityService.GetAxisRaw("Vertical");
        if (CrossPlatformInputManager.GetButtonDown("attack")){
            StartCoroutine(AttackCo());
        }
        UpdateAnimationAndMove();
    }

    public void Attack()
    {
        SwingAudioSrc.Play();
        CrossPlatformInputManager.SetButtonDown("attack");
        CrossPlatformInputManager.SetButtonUp("attack");
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(
            transform.position + movement.Calculate(change, unityService.GetDeltaTime())
        );
    }
}