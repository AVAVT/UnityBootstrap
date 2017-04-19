using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TKQuestUnit : MonoBehaviour {
	public List<string> QuestNames;
	public UnityEvent OnQuestComplete;

	public void QuestCompleted(string questName) {
		if (QuestNames.Contains (questName)) {
			QuestNames.Remove (questName);
			if (QuestNames.Count == 0 && OnQuestComplete != null) {
				OnQuestComplete.Invoke();
			}
		}
	}
}
