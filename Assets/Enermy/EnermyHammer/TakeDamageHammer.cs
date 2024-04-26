using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageHammer : MonoBehaviour
{
    public int Hp = 40;
    public int PlusScore = 100;
    private ScoreCon scoreControl;
    public GameObject fire;


    private void Start()
    {
      scoreControl =GameObject.Find("KCO").GetComponent<ScoreCon>();
    }
    public void TakeHitHammer(int DmgToHammer)
    {
        Hp -= DmgToHammer;
        StartCoroutine(HitEffect());

        if (Hp <= 0)
        {
            SoundManager.instance.SFX.PlayOneShot(SoundManager.instance.hurtenermy);
            Die();
        }
    }

    private IEnumerator HitEffect()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Die()
    {
        Instantiate(fire,transform.position, Quaternion.identity);
        Debug.Log("ตาย");
        Destroy(gameObject);
        scoreControl.AddPointEnermy();
    }

    
}
