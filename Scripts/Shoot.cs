using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;  //�ѱ�

    //�Ѿ� �߻�
    public Camera mainCamera;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //�̰� ĸ�� rigidbody constrain�ϸ� �����ߴ���� �����

            //�浹�� ������� ��������� �Ѿ�
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);

            if (Physics.Raycast(ray, out hit,100f))
            {
                transform.LookAt(hit.point);  //Ŭ���� ���� �ٶ󺸱�

                // �浹�� �������κ��� IDamageable ������Ʈ�� �������� �õ�
                var target =
                    hit.collider.GetComponent<IDamageable>();

                // �������� ���� IDamageable ������Ʈ�� �������µ� �����ߴٸ�
                if (target != null)
                {
                    DamageMessage damageMessage;

                    damageMessage.damager = this.gameObject;
                    damageMessage.amount = 25f;
                    damageMessage.hitPoint = hit.point;
                    damageMessage.hitNormal = hit.normal;

                    // ������ OnDamage �Լ��� ������Ѽ� ���濡�� ������ �ֱ�
                    target.ApplyDamage(damageMessage);

                    //�Ѿ� �̵�: �ٵ� �Ѿ��� �� ����
                    Bullet.transform.position = Vector3.MoveTowards(Bullet.transform.position, hit.point, 1f);
                }
            }
            //�浹 ���ص� �߰��� ��
            else
            {
                Bullet.transform.position = Vector3.MoveTowards(Bullet.transform.position, ray.direction * 100f, 1f);
            }

            if (Mathf.Abs(Bullet.transform.position.x) >= 100 || Mathf.Abs(Bullet.transform.position.z) >= 100)
            {
                Bullet.SetActive(false);
                Destroy(Bullet);
            }

        }
    }
    private void OnTriggerEnter(Collider other)  //�浹�ϸ� �������
    {
        if (other.tag == "Enemy")
        {
            Bullet.GetComponent<SphereCollider>().enabled = false;
            Bullet.SetActive(false);
            Destroy(Bullet);
        }
    }
}
