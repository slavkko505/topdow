using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayewrCollisions : MonoBehaviour
{
    public Canvas canvasPlayerPlusCoisn;
    public Animator textAnim;
    public Text coinText;
        
    private UnityEvent collisionEnter = new UnityEvent();
    
    public AudioClip mapSound;
    public AudioClip battleSound;
    private AudioSource myAudio;


    private float posX;
    private float posY;
    private void Start()
    {
        if(canvasPlayerPlusCoisn != null)
            canvasPlayerPlusCoisn.enabled = false;
        
        collisionEnter.AddListener(EffectPickUpChest);
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayOneShot(mapSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chest")
        {
            if (collisionEnter != null)
            {
                coinText.text = collision.gameObject.name;
                collisionEnter.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {   
            if(myAudio.isPlaying)
                myAudio.Stop();
            myAudio.PlayOneShot(battleSound);
            SceneManager.LoadScene("FightScene");
            posX = transform.position.x;
            posY = transform.position.y;
            IsButtleSceneBool.SetIndexEnemy(col.gameObject.GetComponent<Enemy>().enemyIndex);
        }
        
    }

    public void PlayDefaultAudio()
    {
        if(myAudio.isPlaying)
            myAudio.Stop();
        myAudio.PlayOneShot(mapSound);
    }

    public void LoadPosPlayer()
    {
        transform.position = new Vector3(posX, posY, 0f);
    }

    void EffectPickUpChest()
    {
        StartCoroutine(CoinsEffectOnScreen());
    }

    IEnumerator CoinsEffectOnScreen()
    {
        canvasPlayerPlusCoisn.enabled = true;
        textAnim.SetBool("animText", true);
        
        yield return new WaitForSeconds(0.6f);
        
        canvasPlayerPlusCoisn.enabled = false;
        textAnim.SetBool("animText", false);

    }
}
