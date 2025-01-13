using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform player;
    Animator animator;
    public bool isAttackCheck = false;
    int hp = 2;
    bool isStop = false;
    Renderer[] renderers;
    Color originColor;
    public float navDistance = 15.0f;

    public float spawnItemPossible = 20.0f;
    public GameObject prefabItem;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        navMeshAgent.destination = player.position;
        renderers = this.GetComponentsInChildren<Renderer>();
        originColor = renderers[0].material.color;
    }

    void Update()
    {
        if (isStop || Vector3.Distance(this.transform.position, player.position) > navDistance)
        {
            navMeshAgent.isStopped = true;
            return;
        }
        if (Vector3.Distance(this.transform.position, player.position) < navMeshAgent.stoppingDistance + 3)
        {
                navMeshAgent.isStopped = true;
                StartCoroutine("Attack");
        }
        else
        {
            navMeshAgent.isStopped = false;
            animator.SetBool("isWalk", true);
            navMeshAgent.destination = player.position;
        }
        this.transform.LookAt(player.position);
    }
    IEnumerator Attack()
    {
        if (!isStop)
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetTrigger("isAttack");
            isAttackCheck = true;

            yield return new WaitForSeconds(0.5f);
            isAttackCheck = false;
            if (Vector3.Distance(this.transform.position, player.position) < navMeshAgent.stoppingDistance + 5)
            {
                StartCoroutine("Attack");
            }
            else
            {
                navMeshAgent.isStopped = false;
            }
        }
    }

    public void SetHp(int damage)
    {
        if(!isStop)
        {
            hp -= damage;
            if(hp <= 0)
            {
                hp = 0;
                animator.SetTrigger("Death");
                isAttackCheck = false;
                isStop = true;
                navMeshAgent.isStopped = true;
                Destroy(this.gameObject);
                spawnItem();
                //Invoke("DelayDestroy", 1.5f);
            }
            else
            {
                //foreach(Renderer render inrenderes)
                //{
                //  //render.material.color = render.material.color * hp / maxHp;
                //  //render.material.color = Color.red;
                //}
                StartCoroutine("HitColor");
            }
        }
    }
    void spawnItem()
    {
        Instantiate(prefabItem, this.transform.position, this.transform.rotation);
    }

    IEnumerator HitColor() //½ºÅ¸Æ®ÄÚ·çÆ¾ÀÌ¶û Â¦
    {
        foreach (Renderer render in renderers)
        {
            //render.material.color = render.material.color * hp / maxHP;
            render.material.color = Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Renderer render in renderers)
        {
            //render.material.color = render.material.color * hp / maxHP;
            render.material.color = originColor;
        }
    }
}
