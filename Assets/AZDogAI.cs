using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZDogAI : MonoBehaviour
{
    Transform _destination;
    Animator an;


    public float attackDistance = 1.5f;
    public float attackRotationSpeed = 120;
    public float deadDistroyTime = 10;
    public GameObject rightWeaponHitBox;

    UnityEngine.AI.NavMeshAgent _navMeshagent;


    private float orgSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshagent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        orgSpeed = _navMeshagent.speed;
    }

    private void Awake()
    {

        if (an == null)
            an = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SleepDestroy()
    {

        yield return new WaitForSeconds(deadDistroyTime);
        Destroy(this.gameObject);
    }


    private void FixedUpdate()
    {
        bool isDead = an.GetBool("Dead");
        if (isDead)
        {
            if (_navMeshagent.enabled)
            {
                _navMeshagent.enabled = false;
                StartCoroutine(SleepDestroy());
                rightWeaponHitBox.SetActive(false);
            }



            return;
        }

        _destination = GameObject.FindGameObjectWithTag("Player").transform;
       // MyChar mc = _destination.GetComponent<MyChar>();
        _navMeshagent.SetDestination(_destination.position);

        float dis = Vector3.Distance(this.transform.position, _destination.transform.position);

       /* if (mc.hp <= 0)
        {
            an.SetFloat("Speed", 0);
        }
        else*/
        if (dis > attackDistance)
        {

            an.SetFloat("Speed", 1);
            an.ResetTrigger("LightAttack");
            _navMeshagent.isStopped = false;
            //_navMeshagent.speed = orgSpeed;
            if (_navMeshagent.velocity.magnitude < 0.1f) { an.SetFloat("Speed", 0); }
        }
        else
        {
            an.SetFloat("Speed", 0);
            an.SetTrigger("LightAttack");
            _navMeshagent.isStopped = true;
            _navMeshagent.velocity = new Vector3();
            //_navMeshagent.speed = 0.001f;
            if (!an.GetBool("NoTurn"))
            {
                Vector3 direction = (_destination.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
                transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation , Time.deltaTime *attackRotationSpeed); }

       }


        if (an.GetBool("NoTurn")) { _navMeshagent.isStopped = true; }

        bool rightWeaponHit = an.GetBool("RightAttacking");

        if (rightWeaponHitBox != null)
        {
            if (rightWeaponHit)
            {
                rightWeaponHitBox.SetActive(true);
            }
            else
            {
                rightWeaponHitBox.SetActive(false);
            }


        }
    }
}
