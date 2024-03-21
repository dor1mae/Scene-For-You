using UnityEngine;

public class MovementController : InitClass
{
    private Player _player;
    private Vector2 _position;
    private Rigidbody2D _rb;
    private float _speed;

    public override void Init()
    {
        _player = GetComponentInParent<Player>();
        _rb = GetComponentInParent<Rigidbody2D>();
        _speed = _player.Dexterity.Value;
    }

    // Update is called once per frame
    void Update()
    {
        _position.x = Input.GetAxisRaw("Horizontal");
        _position.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _position * _speed * Time.fixedDeltaTime);
    }
}
