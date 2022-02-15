using System;
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    [SerializeField] Animator myAnim;
    [SerializeField] public SpriteRenderer spriteRender;
    public float speed = 100f;

    Vector3 moveDelta;
    bool isRun = false;
    
    void Update()
    {
        if (!IsButtleSceneBool.GetindexxBattleScene())
        {
            Movement();
            gameObject.transform.localScale = Vector3.one;
        }
        else
        {
            myAnim.SetBool("isRun", false);
            gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
        }
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        moveDelta = new Vector3(x, y, 0f);

        if (moveDelta.x > 0)
        {
            spriteRender.flipX = false;
        }
        else if (moveDelta.x < 0)
        {
            spriteRender.flipX = true;
        }

        if (x != 0 || y != 0)
        {
            myAnim.SetBool("isRun", !isRun);
        }
        else
        {
            myAnim.SetBool("isRun", isRun);
        }

        transform.position += (moveDelta * Time.deltaTime * speed);
    }
}
