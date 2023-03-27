using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Health _health;

    [SerializeField]
    private Image _fillBar;

    // Update is called once per frame
    void Update()
    {
        _fillBar.fillAmount = _health == null ? 0f : _health.HealthPercent;
    }
}
