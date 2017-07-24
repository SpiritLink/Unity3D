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
        Input_Animation();
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

        pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity);
    } // << : CharacterControl_Slerp()

    public bool IsHandUp = false;
    void Input_Animation()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack")) return;
            
            animator.SetTrigger("Attack_Trigger");
            StartCoroutine(Attack_Routine());
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(Slide_ing());
        }

        if(Input.GetMouseButtonDown(0) && !IsHandUp)
        {
            IsHandUp = true;
            animator.SetBool("IsHandUp", IsHandUp);
            StartCoroutine(HandUp_Routine());
        }
    } // << : Keyboard

    IEnumerator Attack_Routine()
    {
        yield return new WaitForSeconds(0.5f);
        BroadcastMessage("Generate");
    }

    IEnumerator Slide_ing()
    {
        animator.SetBool("IsSliding", true);
        yield return new WaitForSeconds(0.3f);

        while(animator.GetCurrentAnimatorStateInfo(0).normalizedTime + 0.3f < 1.0f)
        {
            // normalize TIme 은 0 ~ 1.0 까지임
            yield return null;
        }

        animator.SetBool("IsSliding", false);
    }

    IEnumerator HandUp_Routine()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.0f);

            if (IsHandUp && animator.GetCurrentAnimatorStateInfo(1).IsName("UpperBody.HandUp"))
            {
                if (animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1.0f)
                {
                    // 현재 여기를 안들어감
                    IsHandUp = false;
                    animator.SetBool("IsHandUp", IsHandUp);
                    break;
                }
            } // << : if
        } // << : while
    } // << : func
}
