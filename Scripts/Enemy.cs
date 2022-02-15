using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    public int direction = 1;
    
    private SpriteRenderer _spriteRenderer;
    bool isRotate;

    public int enemyIndex = 1;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!IsButtleSceneBool.GetindexxBattleScene())
        {
            EnemyRun(direction);
            gameObject.transform.localScale = Vector3.one;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
        }
        
        
    }

    void EnemyRun(int direction)
    {
        transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0f, 0f));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "changeDIrection")
        {
            _spriteRenderer.flipX = !isRotate;
            direction *= -1;
            isRotate = !isRotate;
        }
    }
    
}
