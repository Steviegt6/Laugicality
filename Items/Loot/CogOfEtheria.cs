using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class CogOfEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Annihilation");
            Tooltip.SetDefault("Killing an enemy while in the Etherial boosts your damage by 20% for 10 seconds. Killing another enemy in this time resets the timer and stacks the bonus.");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
                modPlayer.EtherCog = true;
        }
    }
}