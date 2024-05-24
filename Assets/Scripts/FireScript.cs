using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPre;
    [SerializeField] GameObject pistolGunPipe;
    [SerializeField] GameObject pistolSound;
    [SerializeField] GameObject shotgunPipe;
    [SerializeField] GameObject shotGunSound;
    
    GameObject currentPipe;

    public Weapon CurrentWeapon = Weapon.Shotgun;

    [SerializeField] static float recoilReduction = 0.6f;

    static Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ActivateFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(Time.timeScale != 0)
            {
                if(CurrentWeapon == Weapon.Shotgun)
                {
                    currentPipe = shotgunPipe;

                    Destroy(Instantiate(shotGunSound), 1f);

                    for (int i = 0; i < 5; i++)
                    {
                        Fire(0.5f);
                    }
                }
                else if(CurrentWeapon == Weapon.Pistol)
                {
                    currentPipe = pistolGunPipe;

                    Destroy(Instantiate(pistolSound), 1f);

                    Fire(1.5f);
                }
            }
        }
    }

    void Fire(float damage)
    {
        GameObject bullet = Instantiate(bulletPre, currentPipe.transform.position, currentPipe.transform.parent.transform.rotation);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.SetDamage(damage);
        bullet.transform.Rotate(0, 0, Random.Range(-10, 10));
    }

    public static void GetRecoil(Vector2 bulletVelocity)
    {
        rb.velocity = new Vector2((-bulletVelocity.x) * recoilReduction, (-bulletVelocity.y) * recoilReduction) + new Vector2(rb.velocity.x * 0.2f, rb.velocity.y * 0.2f);
    }
}

public enum Weapon
{
    Pistol,
    Shotgun
}