using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class SlotSpawner : MonoBehaviour
{
    #region Cashing
    [SerializeField]
    private LevelGrid[] _levelGrids;

    [SerializeField]
    private SlotDataBase[] _slotDataBases;

    [SerializeField]
    private GameObject _slotsParent;

    [SerializeField]
    private SlotContainer _slotPrefab;

    [SerializeField]
    private TaskController _taskController;

    #endregion

    #region Internal stuff
    private List<SlotContainer> spawnedSlots = new List<SlotContainer>();

    private List<SlotData> _tempSlotDatas = new List<SlotData>();

    private List<string> _usedTasks = new List<string>();

    private SlotDataBase _currentDataBase;
    #endregion

    #region Grid
    private int _rows;
    private int _columns;

    private GridLayoutGroup _gridLayout;

    [SerializeField]
    private int _currentGridIndex;
    #endregion

    #region Booleans
    private bool _allLevelsCompleted = false;

    public bool AllLevelsCompleted => _allLevelsCompleted;

    private bool _isFirstLevel;
    #endregion

    private void Awake()
    {
        _slotsParent.TryGetComponent(out _gridLayout);

        _currentGridIndex = 0;

        _isFirstLevel = true;
    }

    public void SpawnContainers()
    {
        CleanUpSlots();

        SetupGrid();

        RandomizeDataBase();

        _tempSlotDatas.Clear();

        _tempSlotDatas.AddRange(_currentDataBase.SlotDatas);

        _tempSlotDatas.Shuffle();


        for (int i = 0; i < _rows; i++)
        {
            for (int k = 0; k < _columns; k++)
            {
                var slotContainer = Instantiate(_slotPrefab.gameObject, _slotsParent.transform).GetComponent<SlotContainer>();

                if (_isFirstLevel)
                {
                    slotContainer.LoadingFirstLevel();
                }

                SetupSlot(slotContainer, ref _tempSlotDatas);

            }


        }

        _isFirstLevel = false;

        SetTask();
    }


    private void SetupSlot(SlotContainer slot, ref List<SlotData> slotDatas)
    {

        int currentIndex = Random.Range(0, slotDatas.Count);

        SlotData tempSlotData = slotDatas[currentIndex];

        slot.SetSlot(tempSlotData);

        slotDatas.RemoveAt(currentIndex);

        spawnedSlots.Add(slot);
    }

    private void SetTask()
    {
        string task = spawnedSlots[Random.Range(0, spawnedSlots.Count)].Data.ID;

        //check in order not to freeze app due to while loop
        if(_usedTasks.Count < _currentDataBase.SlotDatas.Length)
        {
            while (_usedTasks.Contains(task))
            {
                task = spawnedSlots[Random.Range(0, spawnedSlots.Count)].Data.ID;

            }
        }

        _taskController.SetupTask(task);

        _usedTasks.Add(task);
        
    }

    private void RandomizeDataBase()
    {
        _currentDataBase = _slotDataBases[Random.Range(0, _slotDataBases.Length)];
    }
    
    private void SetupGrid()
    {

        LevelGrid grid = _levelGrids[_currentGridIndex];

        _rows = grid.rows;

        _columns = grid.columns;

        _gridLayout.constraintCount = _columns;

        _currentGridIndex +=1;

        if (_currentGridIndex > _levelGrids.Length - 1)
        {
            _allLevelsCompleted = true;

            _currentGridIndex = 0;
        }
    }

    private void CleanUpSlots()
    {
        if (spawnedSlots.Count < 1) return;

        foreach (var item in spawnedSlots)
        {
            Destroy(item.gameObject);
        }

        spawnedSlots.Clear();
    }

    public void ResetSpawner()
    {
        _currentGridIndex = 0;
        _allLevelsCompleted = false;
        _usedTasks.Clear();
        _isFirstLevel = true;
    }

}


