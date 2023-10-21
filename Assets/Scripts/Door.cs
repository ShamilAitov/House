using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Alarm))]
public class Door : MonoBehaviour
{
    private Alarm _alarmSystem;
    private Animator _animator;
    private int _isOpen = Animator.StringToHash("IsOpen");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _alarmSystem = GetComponent<Alarm>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (GetPlayer(collision))
        {
            _animator.SetBool(_isOpen, true);
            _alarmSystem.SoundPlay();
            _alarmSystem.IncreaseSoundVolume();

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (GetPlayer(collision))
        {
            _animator.SetBool(_isOpen, false);
            _alarmSystem.ReduceSoundVolume();
        }
    }

    private bool GetPlayer(Collider collision)
    {
        return collision.TryGetComponent<Player>(out Player player);
    }

}
