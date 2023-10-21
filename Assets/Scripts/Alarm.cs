using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private Coroutine _coroutine;

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
        StopCoroutine();

        _coroutine = StartCoroutine(ChangeSoundVolume(_maxVolume));
    }

    public void ReduceSoundVolume()
    {
        StopCoroutine();

        StartCoroutine(ChangeSoundVolume(_minVolume));

        if (_alarm.volume <= _minVolume)
        {
            _alarm.Stop();
        }
    }

    private IEnumerator ChangeSoundVolume(float volume)
    {
        var volumeChangeTime = new WaitForSeconds(0.01F);
        float shareVolumeChange = 0.1F;

        while (_alarm.volume != volume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, volume, shareVolumeChange * Time.deltaTime);

            yield return volumeChangeTime;
        }
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
