using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AI : MonoBehaviour
{
    public GameObject target;
    public GameObject ProjectileOBJ;
    public GameObject Projectile2;
    public GameObject effect1;
    public GameObject PosRain;

    private bool dbxproj = false;

    void Update()
    {
        if (target != null)
        {
            if (dbxproj != true)
            {
                StartCoroutine(Skill());
            }
        }
    }

    IEnumerator Skill()
    {   
        dbxproj = true;
        int ran = Random.Range(1, 4);
        Debug.Log(ran);
        if (ran == 1)
        {   
            gameObject.tag = "PaperEnermy";
            effect1.SetActive(true);
            yield return new WaitForSeconds(.3f);
            effect1.SetActive(false);
            for (int i = 0; i < 25; i++)
            {
                GameObject obj = Instantiate(ProjectileOBJ, PosRain.transform.position, PosRain.transform.rotation);
                obj.transform.position += new Vector3(Random.Range(-10,10), 0, 0);
                obj.GetComponent<Rigidbody2D>().velocity = Vector3.up * -10;
                yield return new WaitForSeconds(.2f);
            }
             yield return new WaitForSeconds(1f);
        }
        if (ran == 2)
        {   
            gameObject.tag = "ScissorsEnermy";
            GameObject obj = Instantiate(Projectile2, transform.position + new Vector3(0,2.5f,0), transform.rotation);
            Destroy(obj, 2f);
            yield return new WaitForSeconds(2f);
             yield return new WaitForSeconds(1f);
        }
        if (ran == 3)
        {
            gameObject.tag = "HammerEnermy";
            GameObject obj = Instantiate(Projectile2, transform.position + new Vector3(0,2.5f,0), transform.rotation);
            Destroy(obj, 2f);
            yield return new WaitForSeconds(2f);
             yield return new WaitForSeconds(1f);
        }
        dbxproj = false;
    }
}
