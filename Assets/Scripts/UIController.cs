using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    UIDocument document;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        document = GetComponent<UIDocument>();
        VisualElement calendarArea = document.rootVisualElement.Q<VisualElement>("CalendarArea");
        Debug.Log(calendarArea.childCount);
        //try populating 
        for (int i = 0; i < 10; i++)
        {
            calendarArea.Add(new Label("Gup"));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
