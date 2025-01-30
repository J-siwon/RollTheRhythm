using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Note
{
    public float time;         // 노트 등장(또는 판정) 비트 수 (4 면 4비트)
    public Vector2 spawnPos;   // 노트 스폰 위치 (x, y)로 저장
    public int noteType; //노트 타입 인덱스 (0 : normal, 1: fast, 2: slow, 3:Triangle, 4: Square, 5: pentagon, 6: Jump)
    public float speed; //속도는 배속으로 표기 x0.5, x1 이런 식
}
