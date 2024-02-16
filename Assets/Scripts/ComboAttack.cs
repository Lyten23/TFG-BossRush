using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private int clicks;
    [SerializeField] private bool canAttack;

    [SerializeField] private GameObject[] slashes;
    [SerializeField] private GameObject[] slashsTwo;
    [SerializeField] private GameObject[] slashsThree;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        clicks=0;
        canAttack = true;
        DisableSlashes();
        DisableSlashes2();
        DisableSlashes3();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button3)||Input.GetButtonDown("Fire1"))
        {
            InitialCombo();
        }
    }
    void InitialCombo()
    {
        if (canAttack)
        {
            clicks++;
        }
        if(clicks==1)
        {
            _animator.SetInteger("CountAttack",1);
            StartCoroutine(SlashAttack());
        }
    }
    public void VerifyCombo()
    {
        canAttack = false;
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit1") && clicks==1)
        {
            _animator.SetInteger("CountAttack",0);
            canAttack = true;
            clicks = 0;
        }if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit1") && clicks>=2)
        {
            _animator.SetInteger("CountAttack",2);
            canAttack = true;
        }if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit2") && clicks==2)
        {
            _animator.SetInteger("CountAttack",0);
            canAttack = true;
            clicks= 0;
        }if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit2") && clicks>=3)
        {
            _animator.SetInteger("CountAttack",3);
            canAttack = true;
        }if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hit3"))
        {
            _animator.SetInteger("CountAttack",0);
            canAttack = true;
            clicks = 0;
        }
    }

    public void ActiveSecondHitVFX() => StartCoroutine(SlashAttack2());
    public void ActiveThirdHitVFX() => StartCoroutine(SlashAttack3());

    #region SlashesLogic

    IEnumerator SlashAttack()
    {
        for (int i = 0; i < slashes.Length; i++)
        {
            yield return new WaitForSeconds(0.6f);
            slashes[i].gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        DisableSlashes();
    }

    IEnumerator SlashAttack2()
    {
        for (int i = 0; i < slashsTwo.Length; i++)
        {
            yield return new WaitForSeconds(0.2f);
            slashsTwo[i].gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(1);
        DisableSlashes2();
    }
    IEnumerator SlashAttack3()
    {
        for (int i = 0; i < slashsThree.Length; i++)
        {
            yield return new WaitForSeconds(0.2f);
            slashsThree[i].gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(1);
        DisableSlashes3();
    }
    void DisableSlashes()
    {
        for (int i = 0; i < slashes.Length; i++)
        {
            slashes[i].gameObject.SetActive(false);
        }
    }void DisableSlashes2()
    {
        for (int i = 0; i < slashsTwo.Length; i++)
        {
            slashsTwo[i].gameObject.SetActive(false);
        }
    }
    void DisableSlashes3()
    {
        for (int i = 0; i < slashsThree.Length; i++)
        {
            slashsThree[i].gameObject.SetActive(false);
        }
    }
    #endregion
}
