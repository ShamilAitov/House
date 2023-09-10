using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void Start()
    {
        _alarm.volume = _minVolume;
    }

    public void SoundPlay()
    {
        _alarm.Play();
    }

    public void IncreaseSoundVolume()
    {
        StartCoroutine(ChangeSoundVolume(_maxVolume));
    }

    public void ReductionSoundVolume()
    {
        StartCoroutine(ChangeSoundVolume(_minVolume));

        if (_alarm.volume <= _minVolume)
        {
            _alarm.Stop();
        }
    }

    private IEnumerator ChangeSoundVolume (float volume)
    {
        var volumeChangeTime = new WaitForSeconds(0.01F);
        float shareVolumeChange = 0.1F;

        while (_alarm.volume != volume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, volume, shareVolumeChange * Time.deltaTime);

            yield return volumeChangeTime;
        }
    }
}
