using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _taskText;

    [SerializeField]
    private string _taskID;

    public string TaskID => _taskID;
    

    public void SetupTask(string id)
    {
        _taskID = id;
        _taskText.text = "Find " + _taskID;
    }
}
