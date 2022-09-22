using Autobattler.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Grid))]
public class LevelGenerator : MonoBehaviour
{
    private Grid grid;
    public Grid Grid
    {
        get {
            if (grid == null)
            {
                grid = GetComponent<Grid>();
            }
            return grid;
        }
        private set { grid = value; } 
    }

    [SerializeField] private LevelTiles tileSprites = null;
    [SerializeField] private GameObject tilemapPrefab = null;
    [SerializeField] private List<AbstractTilemapFactory> tileFactories = null;

    private UnityEvent CleanMapEvent;

    public void GenerateLevel(LevelConfigData levelConfig)
    {
        ClearLevel();
        FocusCameraOnLevel(levelConfig);

        foreach(AbstractTilemapFactory f in tileFactories)
        {
            f.Init(transform, tilemapPrefab);
            f.WriteTiles(levelConfig, tileSprites);
            CleanMapEvent.AddListener(f.CleanTilemap);
        }
    }

    private void FocusCameraOnLevel(LevelConfigData levelConfig)
    {
        var levelWidth = levelConfig.GridWidth;
        var levelHeight = levelConfig.GridHeight;

        Camera.main.transform.position = new Vector3(levelWidth / 4f, levelHeight / 4f, -1);
        Camera.main.orthographicSize = levelWidth / 4f;
    }

    private void ClearLevel()
    {
        if(CleanMapEvent == null)
        {
            CleanMapEvent = new UnityEvent();
        }

        CleanMapEvent.Invoke();
        CleanMapEvent.RemoveAllListeners();
    }
}
