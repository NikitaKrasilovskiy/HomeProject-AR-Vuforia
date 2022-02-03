using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenDoor : MonoBehaviour, IPointerClickHandler
{
    private Animator animator;
    public void OnPointerClick(PointerEventData eventData)
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Open");
    }
}
