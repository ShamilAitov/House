using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private Animator _animator;
    private float _minVolume = 0;
    private float _maxVolume = 1;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _alarm.volume = _minVolume;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (GetPlayer(collision))
        {
            _animator.SetBool("IsOpen", true);
            _alarm.Play();
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (GetPlayer(collision))
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maxVolume, 0.1F * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (GetPlayer(collision))
        {
            _animator.SetBool("IsOpen", false);

            StartCoroutine(SoundReduction());

            if (_alarm.volume <= _minVolume)
            {
                _alarm.Stop();
            }
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

    private bool GetPlayer(Collider collision)
    {
        return collision.TryGetComponent<Player>(out Player player);
    }

}
