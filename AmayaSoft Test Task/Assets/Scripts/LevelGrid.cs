using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New LevelGrid", menuName = "Level Grid", order = 0)]
public class LevelGrid : ScriptableObject
{
    public int rows;
    public int columns;
}
