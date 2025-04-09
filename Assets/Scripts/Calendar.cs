using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;
using System.Linq;
public class Calendar : MonoBehaviour
{
    public List<Event> events = new List<Event>();
    public struct Event
    {
        public string eventName;

        public DateTime dateTime;

    }
    void Start()
    {
        DateTime now = DateTime.Now;
        Event testEvent = new Event
        {
            dateTime = now,
            eventName = "test"
        };
        events.Add(testEvent);
        //get events from today
        // List<Event> todayEvents = events.Where((a) => a.dateTime.Date == now.Date).ToList<Event>();
        Dictionary<int, List<Event>> eventDay = new Dictionary<int, List<Event>>();
        //populate month
        for (int i = 0; i <= DateTime.DaysInMonth(now.Year, now.Month); i++)
        {
            eventDay.Add(i, new List<Event>());
        }
        //populate events
        foreach (Event eventInMonth in events)
        {
            eventDay[eventInMonth.dateTime.Day].Add(eventInMonth);
        };
        
    }
    
}
