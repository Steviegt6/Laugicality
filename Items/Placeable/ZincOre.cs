using Laugicality.Tiles;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class ZincOre : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A crucial component of Brass");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = ModContent.TileType<Zinc>();
        }
    }
}