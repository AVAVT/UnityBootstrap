using UnityEngine;

public class SoundService : ISoundService
{
  public void CrossFade(string target, float duration)
  {
    SoundManager.Instance.CrossFade(target, duration);
  }

  public void Play2DSFX(string key)
  {
    SoundManager.Instance.Play2DSFX(key);
  }

  public void Play3DSFX(string key, Vector2 position)
  {
    SoundManager.Instance.Play3DSFX(key, position);
  }

  public void PlayBGM(string key)
  {
    SoundManager.Instance.PlayBGM(key);
  }

  public void StopSFX(string key)
  {
    SoundManager.Instance.StopSFX(key);
  }
}