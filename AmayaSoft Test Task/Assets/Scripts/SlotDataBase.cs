using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SlotDataBase", menuName = "Slot Data Base", order = 0)]
public class SlotDataBase : ScriptableObject
{
    [SerializeField]
    private SlotData[] _slotDatas;

    public SlotData[] SlotDatas => _slotDatas;
}
