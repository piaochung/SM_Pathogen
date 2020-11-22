using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronManager : CharacterManager
{
    public bool BulletAtt = false; // true = 총알 발사, false = 총알 발사 중지


    public float power; //총알파워
    public float maxShotDelay; //총알딜레이
    public float curShotDelay; //총알 발사 딜레이
    public float ShotSpeed;
    public GameObject DronPosShot; // 드론 총알 위치

    public GameObject DronBullet;

    void start()
    {

    }
    void FixedUpdate()
    {
        FireBullet();
        Reload();
      
    }
    void FireBullet() //총알 발사
    {
        if (curShotDelay < maxShotDelay)
            return;


        GameObject bullet = Instantiate(DronBullet, DronPosShot.transform.position, transform.rotation); //총알 오브젝트 생성
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();  //총알 바디
        rigid.AddForce(Vector2.down * ShotSpeed, ForceMode2D.Impulse);

        curShotDelay = 0; //총알 딜레이 추가
        maxShotDelay = 0.8f;

    }
    void Reload() //총알장전 속도
    {
        curShotDelay += Time.deltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}