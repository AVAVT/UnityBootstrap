using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TKAudioManager : MonoBehaviour
{
	public static TKAudioManager Instance { get; private set; }

	[SerializeField]
	public List<TKSound> sfxs;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);

			foreach (TKSound sfx in sfxs) {
				sfx.key = sfx.key.Trim ().ToLower ();
			}
		}
	}

	public void PlaySfxWithKey (string key)
	{
		PlaySfxWithKey (key, Vector3.zero);
	}

	public void PlaySfxWithKey (string key, Vector3 position)
	{
		AudioSource.PlayClipAtPoint (sfxs.Find ((sound) => {
			return sound.key.Trim ().ToLower () == key;
		}).audio, position);
	}
}

[System.Serializable]
public class TKSound
{
	public string key;
	public AudioClip audio;
}