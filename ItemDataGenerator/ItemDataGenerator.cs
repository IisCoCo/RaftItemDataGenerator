using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[ModTitle("ItemDataGenerator")]
[ModDescription("Generates a detailed list of all items and their settings")]
[ModAuthor("CoCo")]
[ModVersion("1.0")]
[RaftVersion("Update 5")]
public class ItemDataGenerator : Mod
{
    string path = @"D:\items.csv";

    private void Start()
    {
        RConsole.Log("ItemDataGenerator loaded!");
        Generate();
        RConsole.Log("ItemData Generated! at " + path);
    }

    private void Generate()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, false))
        {
            //heading information
            file.WriteLine("Name,UniqueName,UniqueIndex,MaxUses,hideFlags," +
                "buildable Placeable,buildable ReselectOnBuild,buildable GetBlockPrefab(default)," +// buildable GetBlockPrefab(ceiling),buildable GetBlockPrefab(floor),buildable GetBlockPrefab(FloorAndCeiling),buildable GetBlockPrefab(LongWall),buildable GetBlockPrefab(RoofStraight45),buildable GetBlockPrefab(RoofStraight45Inv),buildable GetBlockPrefab(Wall)," +
                "consumeable FoodType,consumeable HungerYield,consumeable ThirstYield,consumeable IsRaw,consumeable ItemAfterUse," +
                "cookable CookingTime,cookable CookingResult,cookable CookingSlotsRequired," +
                "equipment EquipSlotType," +
                "inventory LocalizationTerm,inventory DisplayName,inventory Description,inventory Sprite,inventory StackSize,inventory Stackable," +
                "recipe CraftingCategory,recipe HasSubCategory,recipe HasHiddenSubCategory,recipe LocalizedSubCategory,recipe SubCategory,recipe SubCategoryOrder,recipe FirstItem,recipe AmountToCraft,recipe LearnedFromBeginning,recipe isBlueprint,recipe BlueprintItem," +
                "usable UseButtonCooldown,usable AnimationOnSelect,usable AnimationOnUse,usable ForceAnimationIndex,usable SetTriggering,usable LockItemDuringCooldown,usable ResetTriggerOnDeselect,usable ConsumeUseAmount,usable GetUseButtonName,usable IsUsable,usable AllowHoldButton");

            foreach (Item_Base item in ItemManager.GetAllItems())
            {
                string error = ""; // printed if an exception is called to indicate where the error occurs

                try
                {
                    //Base item
                    error = "check item base";
                    string s = item.name + "," + item.UniqueName + "," + item.UniqueIndex + "," + item.MaxUses + "," + item.hideFlags + ",";

                    //buildable settings
                    error = "check buildable";
                    if (item.settings_buildable != null)
                    {
                        s += item.settings_buildable.Placeable + "," + item.settings_buildable.ReselectOnBuild + ",";

                        if (item.settings_buildable.GetBlockPrefab(DPS.Default) != null)
                        {
                            s += item.settings_buildable.GetBlockPrefab(DPS.Default).name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        /* prefabs that were giving me trouble
                        if (item.settings_buildable.GetBlockPrefab(DPS.Ceiling) != null)
                        {
                            s += item.settings_buildable.GetBlockPrefab(DPS.Ceiling).name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        if (item.settings_buildable.GetBlockPrefab(DPS.Floor) != null)
                        {
                            s += item.settings_buildable.GetBlockPrefab(DPS.Floor).name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        if (item.settings_buildable.GetBlockPrefab(DPS.FloorAndCeiling) != null)
                        {
                            s += item.settings_buildable.GetBlockPrefab(DPS.FloorAndCeiling).name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        if (item.settings_buildable.GetBlockPrefab(DPS.LongWall) != null)
                        {
                            s += item.settings_buildable.GetBlockPrefab(DPS.LongWall).name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        if (item.settings_buildable.GetBlockPrefab(DPS.RoofStraight45) != null)
                        {
                            s += item.settings_buildable.GetBlockPrefab(DPS.RoofStraight45).name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        if (item.settings_buildable.GetBlockPrefab(DPS.RoofStraight45Inv) != null)
                        {
                            s += item.settings_buildable.GetBlockPrefab(DPS.RoofStraight45Inv).name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        if (item.settings_buildable.GetBlockPrefab(DPS.Wall) != null)
                        {
                            s += item.settings_buildable.GetBlockPrefab(DPS.Wall).name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }
                        

                        s += " , , , , , , ,";
                        */
                    }
                    else
                    {
                        s += " , , , , , , , , , ,";
                    }

                    //consumeable settings
                    error = "check consumeable";
                    if (item.settings_consumeable != null)
                    {
                        s += item.settings_consumeable.FoodType + "," + item.settings_consumeable.HungerYield + "," + item.settings_consumeable.ThirstYield + "," + item.settings_consumeable.IsRaw + ",";

                        if (item.settings_consumeable.ItemAfterUse.item != null)
                        {
                            s += item.settings_consumeable.ItemAfterUse.item.name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }
                    }
                    else
                    {
                        s += " , , , , ,";
                    }

                    //cookable settings
                    error = "check cookable";
                    if (item.settings_cookable != null)
                    {
                        s += item.settings_cookable.CookingTime + ",";

                        if (item.settings_cookable.CookingResult.item != null)
                        {
                            s += item.settings_cookable.CookingResult.item.name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        s += item.settings_cookable.CookingSlotsRequired + ",";
                    }
                    else
                    {
                        s += " , , ,";
                    }

                    //equipment settings
                    error = "check equipment";
                    if (item.settings_equipment != null)
                    {
                        s += item.settings_equipment.GetEquipSlotType() + ",";
                    }
                    else
                    {
                        s += " ,";
                    }

                    //inventory settigns
                    error = "check inventory";
                    if (item.settings_Inventory != null)
                    {
                        s += item.settings_Inventory.LocalizationTerm + "," + item.settings_Inventory.DisplayName + ",\"" + item.settings_Inventory.Description + "\",";

                        if (item.settings_Inventory.Sprite != null)
                        {
                            s += item.settings_Inventory.Sprite.name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }

                        s += item.settings_Inventory.StackSize + "," + item.settings_Inventory.Stackable + ",";
                    }
                    else
                    {
                        s += " , , , , , ,";
                    }

                    //recipe settings
                    error = "check recipe";
                    if (item.settings_recipe != null)
                    {
                        s += item.settings_recipe.CraftingCategory + "," + item.settings_recipe.HasSubCategory + "," + item.settings_recipe.HasHiddenSubCategory + "," + item.settings_recipe.LocalizedSubCategory + "," + item.settings_recipe.SubCategory + "," + item.settings_recipe.SubCategoryOrder + ",";

                        error += "a";

                        //if (item.settings_recipe.NewCost != null && item.settings_recipe.NewCost[0] != null && item.settings_recipe.NewCost[0].items != null && item.settings_recipe.NewCost[0].items[0] != null)
                        //{
                        //    error += "b";
                        //    s += item.settings_recipe.NewCost[0].items[0].name + ",";
                        //}
                        //else
                        //{
                        s += " ,";
                        //}

                        error += "c";

                        s += item.settings_recipe.AmountToCraft + "," + item.settings_recipe.LearnedFromBeginning + "," + item.settings_recipe.IsBlueprint + ",";

                        error += "d";

                        if (item.settings_recipe.BlueprintItem != null)
                        {
                            error += "e";
                            s += item.settings_recipe.BlueprintItem.name + ",";
                        }
                        else
                        {
                            s += " ,";
                        }
                    }
                    else
                    {
                        s += " , , , , , , , , , , ,";
                    }

                    //usable settings
                    error = "check usable";
                    if (item.settings_usable != null)
                    {
                        s += item.settings_usable.UseButtonCooldown + "," + item.settings_usable.AnimationOnSelect + "," + item.settings_usable.AnimationOnUse + "," + item.settings_usable.ForceAnimationIndex + "," + item.settings_usable.SetTriggering + "," + item.settings_usable.LockItemDuringCooldown + "," + item.settings_usable.ResetTriggerOnDeselect + "," + item.settings_usable.ConsumeUseAmount + "," + item.settings_usable.GetUseButtonName() + "," + item.settings_usable.IsUsable() + "," + item.settings_usable.AllowHoldButton();
                    }
                    else
                    {
                        s += " , , , , , , , , , ,";
                    }

                    //write item to csv file
                    file.WriteLine(s);
                }
                catch (Exception e)
                {
                    RConsole.Log(item.name);
                    RConsole.Log(error);
                    RConsole.Log(e.StackTrace + e.TargetSite);
                }
            }
        }
    }

    public void Update()
    {
        // Add Your Code Here
    }

    public void OnModUnload()
    {
        RConsole.Log("ItemDataGenerator has been unloaded!");
        Destroy(gameObject);
    }
}