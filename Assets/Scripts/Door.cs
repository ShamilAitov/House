using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AlarmSystem))]
public class Door : MonoBehaviour
{
    private AlarmSystem _alarmSystem;
    private Animator _animator;
    private int _isOpen = Animator.StringToHash("IsOpen");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _alarmSystem = GetComponent<AlarmSystem>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (GetPlayer(collision))
        {
            _animator.SetBool(_isOpen, true);
            _alarmSystem.ALarmPlay();
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (GetPlayer(collision))
        {
            _alarmSystem.IncreaseAlarm();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (GetPlayer(collision))
        {
            _animator.SetBool(_isOpen, false);
            _alarmSystem.AlarmReduction();
        }
    }

    private bool GetPlayer(Collider collision)
    {
        return collision.TryGetComponent<Player>(out Player player);
    }

}
