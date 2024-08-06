using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Star : MonoBehaviour
{
    public float timeBonus = 5f;
    public UnityEvent<float> addTime;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        addTime.AddListener(GameObject.FindGameObjectWithTag("TimeManager").GetComponent<Timer>().AddTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioManager.PlaySound(audioManager.collect);
            addTime.Invoke(timeBonus);
            Destroy(gameObject);
        }
    }
}
