using System.Collections;
using System.Collections.Generic;using System.IO;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyType",menuName = "Enemy",order = 1)]

public class FileSo : ScriptableObject
{
    public int hp;
    public float speed;
    public int damage;
    
}
