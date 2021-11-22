using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SlotContainer : MonoBehaviour
{
    #region Cashing
    [SerializeField]
    private Image _image;

    [SerializeField]
    private string _id;

    private TaskController _taskController;
    private LevelLoader _levelLoader;

    private SlotData _data;

    public SlotData Data => _data;
    #endregion

    #region UnityEvents
    [SerializeField]
    private UnityEvent _OnAnsweringCorrect;

    [SerializeField]
    private UnityEvent _OnAnsweringIncorrect;

    [SerializeField]
    private UnityEvent _OnLoadingFirstLevel;
    #endregion


    public void Start()
    {
        _taskController = FindObjectOfType<TaskController>();
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void SetSlot(SlotData data)
    {
        _data = data;

        _image.sprite = _data.Sprite;
        _id = _data.ID;
    }

    public void CheckSlot()
    {
        if(_id == _taskController.TaskID)
        {

            _OnAnsweringCorrect?.Invoke();

        }
        else
        {
            _OnAnsweringIncorrect?.Invoke();

        }
    }


    public void LoadNewLevelDelay(float delay)
    {
        StartCoroutine(LoadNewLevelDelayCoroutine(delay));
    }

    private IEnumerator LoadNewLevelDelayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        _levelLoader.LoadNewLevel();
    }

    public void LoadingFirstLevel()
    {
        _OnLoadingFirstLevel?.Invoke();
    }
}
