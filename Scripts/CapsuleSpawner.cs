using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour
{
    public GameObject spawner;
    BoxCollider spawnerCollider;

    private void Awake()
    {
        spawnerCollider = spawner.GetComponent<BoxCollider>();
        //�ݶ��̴� ���� �������� ĸ�� �����ϱ�
    }

    Vector3 RandomPosition()
    {
        Vector3 originPosition =spawner.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = spawnerCollider.bounds.size.x;
        float range_Z = spawnerCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        float range_Y = Random.Range(2f, 4f);
        Vector3 RandomPostion = new Vector3(range_X, range_Y, range_Z);

        Vector3 spawnPosition = originPosition + RandomPostion;
        return spawnPosition;
    }
    public GameObject capsule;
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());   //3�� �������� ĸ�� ����
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); 

            Instantiate(capsule, RandomPosition(), Quaternion.identity);

        }
    }
}
