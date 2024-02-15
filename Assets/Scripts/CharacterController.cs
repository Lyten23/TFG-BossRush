using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] public MeshCollider[] armasColliders;
    void Start()
    {
        DesactiveColliders();
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(horizontalMovement, 0, verticalMovement);
        direction.Normalize();

        transform.position += direction * (speed * Time.deltaTime);

        if (horizontalMovement!=0||verticalMovement!=0)
        {
            animator.SetFloat("XSpeed",horizontalMovement);
            animator.SetFloat("YSpeed", verticalMovement);

            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
            animator.SetFloat("XSpeed",0);
            animator.SetFloat("YSpeed",0);
            
        }
    }
    void ActivateColliders()
    {
        for (int i = 0; i < armasColliders.Length; i++)
        {
            if (armasColliders[i]!=null)
            {
                armasColliders[i].enabled = true;
            }
        }
    }
    public void DesactiveColliders()
    {
        for (int i = 0; i < armasColliders.Length; i++)
        {
            if (armasColliders[i]!=null)
            {
                armasColliders[i].enabled = false;
            }
        }
    }
}
