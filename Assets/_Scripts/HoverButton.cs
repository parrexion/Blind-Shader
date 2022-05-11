using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler {

	public AudioClip hoverSfx;


	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
		AudioController.instance.PlaySfx(hoverSfx);
	}
}
