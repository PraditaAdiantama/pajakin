using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int nextScene;

    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void TriggerStart(){
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation(){
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(nextScene);
    }
}
