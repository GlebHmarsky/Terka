using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  public TileManager tileManager;
  public ItemManager itemManager;
  public PlayerManager player;
  public UIManger uiManger;
  public PlantManager plantManager;
  public TimeManager timeManager;
  public WorldObjectManager worldObjectManager;

  void Awake()
  {

    if (instance != null && instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      instance = this;
    }

    DontDestroyOnLoad(this.gameObject);

    // player = FindObjectOfType<PlayerManager>();
  }

}
