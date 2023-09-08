using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private float _minVolume = 0;
    private float _maxVolume = 1;

    void Start()
    {
        _alarm.volume = _minVolume;
    }

    public void ALarmPlay()
    {
        _alarm.Play();
    }

    public void IncreaseAlarm()
    {
        _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maxVolume, 0.1F * Time.deltaTime);
    }

    public void AlarmReduction()
    {
        StartCoroutine(SoundReduction());

        if (_alarm.volume <= _minVolume)
        {
            _alarm.Stop();
        }
    }

    private IEnumerator SoundReduction()
    {
        while (_alarm.volume > _minVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _minVolume, 0.1F * Time.deltaTime);

            yield return new WaitForSeconds(0.01F);
        }
    }
}
