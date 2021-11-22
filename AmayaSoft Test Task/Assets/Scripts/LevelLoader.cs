using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private SlotSpawner _slotSpawner;

    [SerializeField]
    private GameObject _restartCanvas;

    [SerializeField]
    private UnityEvent _OnAllLevelsCompleted;

    [SerializeField]
    private UnityEvent _OnLoadingNewLevel;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }


    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {

        LoadNewLevel();

    }



    public void LoadNewLevel()
    {
        if (_slotSpawner.AllLevelsCompleted)
        {
            _OnAllLevelsCompleted?.Invoke();
            return;
        }

        _OnLoadingNewLevel?.Invoke();
    }
    

    

}


