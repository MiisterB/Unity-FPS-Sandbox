using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Animator animator;

    [SerializeField] public int maxAmmo;
    [SerializeField] public int currentAmmo;
    [SerializeField] public float realoadTime;
    private bool isReloading = false;

    [SerializeField] public float damage;
    [SerializeField] public float range;
    [SerializeField] public float impactForce;
    [SerializeField] public float fireRate;

    private float nextTimeToFire = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmmo <= 0 && !isReloading)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        animator.SetBool("isReloading", true);

        yield return new WaitForSeconds(realoadTime - 0.4f);

        animator.SetBool("isReloading", false);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        RaycastHit hit;

        if(currentAmmo > 0)
        {
            currentAmmo--;
            muzzleFlash.Play();

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 0.5f);
            }
        }
    }
}
