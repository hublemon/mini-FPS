using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    //���� ���ϴ� �ֵ����� �ϰ������� DamageMessage �ֱ�
    bool ApplyDamage(DamageMessage damageMessage);
}
