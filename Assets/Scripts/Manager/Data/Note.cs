using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Note
{
    public float time;         // ��Ʈ ����(�Ǵ� ����) ��Ʈ �� (4 �� 4��Ʈ)
    public Vector2 spawnPos;   // ��Ʈ ���� ��ġ (x, y)�� ����
    public int noteType; //��Ʈ Ÿ�� �ε��� (0 : normal, 1: fast, 2: slow, 3:Triangle, 4: Square, 5: pentagon, 6: Jump)
    public float speed; //�ӵ��� ������� ǥ�� x0.5, x1 �̷� ��
}
