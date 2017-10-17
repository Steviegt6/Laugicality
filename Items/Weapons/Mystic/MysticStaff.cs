using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Laugicality;

namespace Laugicality.Items.Weapons.Mystic
{
	public class MysticStaff : MysticItem
    {
        public string tt = "";
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Staff of a true Mystic \nRight click while holding to change Mysticism");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 8;
            //item.magic = true;
            item.mana = 4;
            item.width = 28;
			item.height = 30;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MysticBall");
			item.shootSpeed = 6f;
		}

        
        
        /*
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            damage = (int) modPlayer.mysticDamage;
            knockBack = modPlayer.mysticDuration;
            return true;
        }*/

        /*
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ObsidiumBar", 16);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

        //Mystic Stuff
        public override bool AltFunctionUse(Player player)
        {

            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticMode += 1;
            if (modPlayer.mysticMode > 3) modPlayer.mysticMode = 1;
            return true;
        }/*
        public override bool CanUseItem(Player player)
        {
            return true;
            if (player.altFunctionUse == 2)
            {
                
            }
        }*/
        public override void HoldItem(Player player)
        {
            
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            //Main.NewText(modPlayer.mysticMode.ToString(), 200, 200, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

            if (modPlayer.mysticMode  == 1)
            {
                player.AddBuff(mod.BuffType("Destruction"), 1, true);
                item.damage = 12;
                item.mana = 8;
                item.useTime = 24;
                item.useAnimation = 24;
                item.shootSpeed = 6f;
            }
            else if(modPlayer.mysticMode == 2)
            {
                player.AddBuff(mod.BuffType("Illusion"), 1, true);
                item.damage = 8;
                item.mana = 4;
                item.useTime = 18;
                item.useAnimation = 18;
                item.shootSpeed = 14f;
            }
            else if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                item.damage = 6;
                item.mana = 2;
                item.useTime = 12;
                item.useAnimation = 12;
                item.shootSpeed = 8f;
            }
        }

        public virtual void GetWeaponDamage(Player player, ref int damage)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            item.damage = (int)(item.damage*modPlayer.mysticDamage);
        }
        
        /*
        public override bool CanRightClick()
        {
                return true;
        }
        
        public override void RightClick(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticMode += 1;
            if (modPlayer.mysticMode > 3) modPlayer.mysticMode = 1;
        }*/
	}
}