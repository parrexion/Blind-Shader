using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HoverButton : MonoBehaviour, IPointerEnterHandler {

	public AudioClip hoverSfx;


	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
		if(GetComponent<Button>().interactable)
			AudioController.instance.PlaySfx(hoverSfx, 0.75f);
	}
}
