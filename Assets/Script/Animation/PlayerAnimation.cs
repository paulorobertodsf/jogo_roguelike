using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer sprite;


    void start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float velocidadeX = this.rigidBody.linearVelocity.x;
        float velocidadeY = this.rigidBody.linearVelocity.y;

        if (velocidadeX > 0)
        {
            this.animator.SetBool("run", true);
            this.animator.SetBool("right", true);
            this.animator.SetBool("left", false);
            this.animator.SetBool("up", false);
            sprite.flipX = false;
        }else if(velocidadeX < 0)
        {
            this.animator.SetBool("run", true);
            this.animator.SetBool("right", false);
            this.animator.SetBool("left", true);
            this.animator.SetBool("up", false);
            sprite.flipX = true;
        }else if (velocidadeY < 0  && velocidadeX == 0)
        {
            this.animator.SetBool("run", true);
            this.animator.SetBool("right", false);
            this.animator.SetBool("left", false);
            this.animator.SetBool("up", false);
        }else if (velocidadeY > 0 && velocidadeX == 0)
        {
            this.animator.SetBool("run", true);
            this.animator.SetBool("right", false);
            this.animator.SetBool("left", false);
            this.animator.SetBool("up", true);
        }
        else
        {
            this.animator.SetBool("run", false);
            this.animator.SetBool("right", false);
            this.animator.SetBool("left", false);  
            this.animator.SetBool("up", false);
        }
    }

}
