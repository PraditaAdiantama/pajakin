using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderButtonScript : MonoBehaviour
{
    private Button thisButton;
    private Canvas parentCanvas;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        parentCanvas = GetComponentInParent<Canvas>();

        thisButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        int orderDone = PlayerPrefs.GetInt("orderDone");
        
        if(orderDone >= 2)
        {
            parentCanvas.enabled = false;
        }
    }
}
