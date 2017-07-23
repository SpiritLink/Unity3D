using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanimControl : MonoBehaviour {

    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;
    public GameObject pBullet;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;

	void Start () {
        pcController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

    }
	
	void Update () {
        CharacterControl_Slerp();
        Keyboard();
	}

    private void CharacterControl_Slerp()
    {
        animator.SetFloat("Speed", pcController.velocity.magnitude);

        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        // 루트값 삽입
        if(direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction, 
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }

        pcController.Move(direction * runSpeed * Time.deltaTime);
    } // << : CharacterControl_Slerp()

    void Keyboard()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack")) return;
            if (animator.GetCurrentAnimatorStateInfo(1).IsName("attack")) return;

            animator.SetTrigger("Attack_Trigger");
        }
    }
}
