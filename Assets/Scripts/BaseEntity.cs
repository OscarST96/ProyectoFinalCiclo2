using UnityEngine;
public interface BehaviourEntity
{
    public void Attack();
    public void GetDamage();
    public void Movement(Rigidbody2D rigidbody2D, float velocity, float directionX);
}
public class BaseEntity : MonoBehaviour, BehaviourEntity
{
    public void Attack()
    {

    }
    public void GetDamage()
    {

    }

    public void Movement(Rigidbody2D rigidbody2D, float velocity, float x)
    {
        Vector2 movement = new Vector2(x * velocity, rigidbody2D.linearVelocity.y);
        rigidbody2D.linearVelocity = movement;
    }
    public void Jump(Rigidbody2D rigidbody2D, float JumpForce, bool OnJump)
    {
        if (OnJump)
        {
            rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
