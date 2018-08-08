using UnityEngine;
using Entitas;

public interface ISoundService
{
  void Play2DSFX(string key);
  void Play3DSFX(string key, Vector2 position);
  void StopSFX(string key);
  void PlayBGM(string key);
  void CrossFade(string target, float duration);
}