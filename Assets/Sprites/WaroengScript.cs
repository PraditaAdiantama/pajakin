using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaroengScript : MonoBehaviour
{
    public Animator transitionAnimator;
    private Animator thisAnimator;

    private void Awake()
    {
        thisAnimator = GetComponent<Animator>();
        thisAnimator.SetBool("Hover", false);
    }

    void OnMouseEnter()
    {
        thisAnimator.SetBool("Hover", true);
    }

    void OnMouseExit()
    {
        thisAnimator.SetBool("Hover", false);
    }

    void OnMouseDown()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);
    }
}
