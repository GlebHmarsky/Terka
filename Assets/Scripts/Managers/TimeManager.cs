using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
  public float currentMinutes = 0;
  private int maxMinutesInDay = 1440;
  private int minutesToDisplay, hoursToDisplay, previousHoursToDisplay;

  private float percentageDayComplete;
  private float timeIncrement = 1;
  /// <summary>
  /// Prevents increasing time each frame, now we control it by Unity class Time
  /// </summary>
  private float nextIncrement = 0;
  private float nextRate = 1;

  public Gradient gradient;
  public Light2D environmentLight;

  public TMP_Text hoursText;
  public TMP_Text minutesText;

  public event Action<int> EventTimeChanged;

  void Start()
  {
    SetLightGradient();
    SetClock();
  }

  void Update()
  {
    IncrementTime();
    MakeTimeFaster();
    MakeNormalTime();
  }

  void IncrementTime()
  {
    if (Time.time < nextIncrement) return;

    nextIncrement = Time.time + nextRate;
    currentMinutes += timeIncrement;

    if (currentMinutes >= maxMinutesInDay)
    {
      currentMinutes = 0;
    }

    SetLightGradient();
    SetClock();
  }

  void SetLightGradient()
  {
    percentageDayComplete = currentMinutes / maxMinutesInDay;
    environmentLight.color = gradient.Evaluate(percentageDayComplete);
  }

  void SetClock()
  {
    hoursToDisplay = Mathf.FloorToInt(currentMinutes / 60);
    if (hoursToDisplay >= 24)
    {
      hoursToDisplay = 0;
    }

    minutesToDisplay = (int)currentMinutes % 60;

    if (previousHoursToDisplay != hoursToDisplay)
    {
      previousHoursToDisplay = hoursToDisplay;
      CallEventTimeChanged(hoursToDisplay);
    }

    hoursText.text = hoursToDisplay.ToString("D2");
    minutesText.text = minutesToDisplay.ToString("D2");
  }

  public void CallEventTimeChanged(int hoursToTransmit)
  {
    if (EventTimeChanged != null)
    {
      EventTimeChanged(hoursToTransmit);
    }
  }

  void MakeTimeFaster()
  {
    if (Input.GetKeyDown(KeyCode.Equals))
    {

      timeIncrement += 10;
    }
  }
  void MakeNormalTime()
  {
    if (Input.GetKey(KeyCode.Minus))
    {
      timeIncrement = 1;
    }
  }
}
