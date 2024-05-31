using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlaneScript : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private Rigidbody2D rb2D;
    private Animator animator;
    private int health = 3;
    private bool isDragging = false;

    [SerializeField] private float dragSpeed = 50f;

    public TextMeshProUGUI healthText, wordText;
    public string correctText = "PAJAK";
    public GameObject transition;

    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 targetPosition = mousePosition + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, dragSpeed * Time.deltaTime);
        }
        healthText.text = health.ToString();
    }

    void OnMouseDown()
    {
        isDragging = true;
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        offset = transform.position - mousePosition;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ObstacleScript obstacleScript = collider.GetComponent<ObstacleScript>();

        if(correctText[wordText.text.Length] == obstacleScript.GetWord())
        {
            wordText.text += obstacleScript.GetWord();

            if(wordText.text.Trim() == correctText)
            {
                StartCoroutine(Restart());
            }
        }else{
            health -= 1;                

            if(health ==  0)
            {
                Die();
            }
        }   

        Destroy(collider.gameObject);
    }
  
    IEnumerator Restart()
    {
        Transition transitionScript = transition.GetComponent<Transition>();

        yield return new WaitForSeconds(1);

        transitionScript.TriggerStart();
    }

    private void Die()
    {
        isDragging = false;
        rb2D.constraints = RigidbodyConstraints2D.None;
        animator.SetTrigger("Died");
    }
}
