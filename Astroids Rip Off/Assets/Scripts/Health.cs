using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 15f;

    [SerializeField]
    private int _team = 0;

    private float _currentHealth;

    public int Team => _team;
    public float HealthPercent => _currentHealth/_maxHealth;

    public void ApplyDamage(float damage)
    {
        if(_currentHealth <= 0)
        {
            return;
        }

        _currentHealth = Mathf.Clamp( _currentHealth - damage, 0, _maxHealth );

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }
}
