using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKQuestSystem : MonoBehaviour {

	private static TKQuestSystem instance;
	
	public void QuestCompleted(string questName) {
		foreach (TKQuestUnit questUnit in GetComponents<TKQuestUnit>()) {
			questUnit.QuestCompleted (questName);
		}

		print (questName);
	}

	private void Start() {
		instance = this;
	}

	public static TKQuestSystem getInstance() {
		return instance;
	}
}
