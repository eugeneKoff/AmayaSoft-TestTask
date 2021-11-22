using UnityEngine;

[System.Serializable]
public class SlotData
{
    [SerializeField]
    private string _id;

    [SerializeField]
    private Sprite _sprite;

    public string ID => _id;

    public Sprite Sprite => _sprite;
}

