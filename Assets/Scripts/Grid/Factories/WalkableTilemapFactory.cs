using Autobattler.Data;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "WalkableTilesFactory", menuName = "AutoBattler/Walkable Tiles Factory")]
public class WalkableTilemapFactory : AbstractTilemapFactory
{
    public override void CleanTilemap()
    {
        base.CleanTilemap();
    }

    public override void Init(Transform parentGrid, GameObject tilemapTemplate)
    {
        base.Init(parentGrid, tilemapTemplate);
    }

    protected override string GenerateTilemapName()
    {
        return "Walkables";
    }

    protected override void PopulateTilemap(LevelConfigData levelConfig, LevelTiles spriteSet)
    {
        PopulatePrimaryMap(levelConfig, spriteSet);
    }

    private void PopulatePrimaryMap(LevelConfigData levelConfig, LevelTiles spriteSet)
    {
        for (int i = 0; i < levelConfig.GridWidth; ++i)
        {
            for (int j = 0; j < levelConfig.GridHeight; ++j)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0), spriteSet.Background);
            }
        }
    }
}
