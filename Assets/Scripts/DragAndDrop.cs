using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform, targetTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Vector2 originalPostion;
    private Transition transitionScript;

    public GameObject transition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        transitionScript = transition.GetComponent<Transition>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        originalPostion = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!IsPlaced())
        {
            rectTransform.anchoredPosition = originalPostion;
        }
        else
        {
            StartCoroutine(CenterOnTarget());
        }
    }

    private bool IsPlaced()
    {

        if (!CompareTag("food"))
        {
            return false;
        }

        Collider2D[] colliders = Physics2D.OverlapPointAll(rectTransform.position);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("target"))
            {
                targetTransform = collider.GetComponent<RectTransform>();
                return true;
            }
        }

        return false;
    }

    IEnumerator CenterOnTarget()
    {
        rectTransform.sizeDelta = new Vector2(targetTransform.rect.width, targetTransform.rect.height);
        rectTransform.anchoredPosition = targetTransform.anchoredPosition;

        yield return new WaitForSeconds(1);

        transitionScript.TriggerStart();
    }
}
