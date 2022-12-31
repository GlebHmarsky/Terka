using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IPlaceableObject
{
  public Vector2Int position { get; set; }
  public string plantName;
  public PlantData data;

  public SpriteRenderer spriteRenderer;

  private int stage = 0;
  private int stagesCount;

  public Plant(Vector2Int position, string name)
  {
    this.position = position;
    this.plantName = name;
  }

  private void Start()
  {
    stagesCount = data.sprites.Count;
    UpdateStageSprite();
    GameManager.instance.timeManager.EventTimeChanged += OnHoursChange;
    spriteRenderer.sortingOrder = 0;
  }

  public void IncreaseStage()
  {
    if (stage + 1 >= stagesCount) return;

    stage++;
    spriteRenderer.sortingOrder = 1;
    UpdateStageSprite();
  }

  public void DowngradeStage()
  {
    if (stage == 0) return;

    stage--;
    if (stage == 0)
    {
      spriteRenderer.sortingOrder = 0;
    }
    else
    {
      spriteRenderer.sortingOrder = 1;
    }

    UpdateStageSprite();
  }

  public bool CanBeHarvested()
  {
    return stage + 1 == stagesCount;
  }

  public void Harvest()
  {
    if (!CanBeHarvested()) return;
    data.Action.PerformAction(this.gameObject);
  }

  void OnHoursChange(int hours)
  {
    IncreaseStage();
  }

  void UpdateStageSprite()
  {
    Sprite sprite = data.sprites[stage];
    spriteRenderer.sprite = sprite;
  }
}
