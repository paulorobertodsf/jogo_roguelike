using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer sprite;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float velocidadeX = this.rigidBody.linearVelocity.x;
        float velocidadeY = this.rigidBody.linearVelocity.y;

        if (velocidadeX > 0)
        {
            this.animator.SetBool("Right", true);
            this.animator.SetBool("Left", false);
            this.animator.SetBool("Up", false);
            sprite.flipX = false;
        }else if(velocidadeX < 0)
        {
            this.animator.SetBool("Right", false);
            this.animator.SetBool("Left", true);
            this.animator.SetBool("Up", false);
            sprite.flipX = true;
        }else if (velocidadeY < 0 )// && velocidadeX == 0)
        {
            this.animator.SetBool("Right", false);
            this.animator.SetBool("Left", false);
            this.animator.SetBool("Up", false);
        }else if (velocidadeY > 0 )//&& velocidadeX == 0)
        {
            this.animator.SetBool("Right", false);
            this.animator.SetBool("Left", false);
            this.animator.SetBool("Up", true);
        }
    }
}
