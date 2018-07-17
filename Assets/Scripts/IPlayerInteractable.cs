using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInteractable {
	bool IsInteractable();
	void Interact();
	void ShowInteractionPrompt();
	void HideInteractionPrompt();
}
