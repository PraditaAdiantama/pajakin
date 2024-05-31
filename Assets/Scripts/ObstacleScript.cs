using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public TextMeshPro TextMesh;

    private string word = "PAJK";
    private char letter;

    void Start()
    {
        letter = word[Random.Range(0, 4)];
        TextMesh.text = letter.ToString();
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if(transform.position.x < -10){
            Destroy(gameObject);
        }
    }

    public char GetWord()
    {
        return letter;
    }
}
