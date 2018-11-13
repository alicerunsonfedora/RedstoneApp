using System;
namespace Redstone
{

    //Create a new base object with some basic properties
    public class NerdBoxObject
    {

        public int MappedMatrixInteger; //Assign a numerical ID to the block's resource
        public int MappedMatrixDefaultLocation = Resource.Drawable.dirt; //Assign the texture from the Resources folder
        public double[,] ToggleableValues = new double[,] { { 0, Resource.Drawable.dirt }, { 0, Resource.Drawable.grass_side }}; //If there are different variants, they can be called here.
        public bool IsToggleable = false;

        public NerdBoxObject()
        {
        }
    }

    // The following objects below are inherited from the NerdBoxObject.

    #region Blocks

    //Core Redstone (Ore, Block)
    public class RedstoneCore: NerdBoxObject
    {
        public RedstoneCore()
        {
            MappedMatrixInteger = 0;
            //Note: no MappedMatrixDefaultLocation for Redstone Core as it related to two different blocks
            IsToggleable = true;

            //Ore
            ToggleableValues[0, 0] = 0.25;
            ToggleableValues[0, 1] = Resource.Drawable.redstone_ore;


            //Block
            ToggleableValues[1, 0] = 0.5;
            ToggleableValues[1, 1] = Resource.Drawable.redstone_block;
        }
    }

    //Command Block
    public class CommandBlock : NerdBoxObject
    {
        public CommandBlock()
        {
            MappedMatrixInteger = 1;
            MappedMatrixDefaultLocation = Resource.Drawable.command_block;
            IsToggleable = false;
        }
    }

    //Redstone Repeater
    public class RedstoneRepeater : NerdBoxObject
    {
        public RedstoneRepeater()
        {
            MappedMatrixInteger = 2;
            MappedMatrixDefaultLocation = Resource.Drawable.repeater_off;
            IsToggleable = true;

            ToggleableValues[0, 0] = 0.25;
            ToggleableValues[0, 1] = MappedMatrixDefaultLocation;

            ToggleableValues[1, 0] = 0.50;
            ToggleableValues[1, 1] = Resource.Drawable.repeater_on;
            
        }
    }

    //Redstone Lamp
    public class RedstoneLamp : NerdBoxObject
    {
        public RedstoneLamp()
        {
            MappedMatrixInteger = 3;
            MappedMatrixDefaultLocation = Resource.Drawable.redstone_lamp_off;
            IsToggleable = true;

            ToggleableValues[0, 0] = 0.25;
            ToggleableValues[0, 1] = MappedMatrixDefaultLocation;

            ToggleableValues[1, 0] = 0.5;
            ToggleableValues[1, 1] = Resource.Drawable.redstone_lamp_on;

        }
    }

    //Redstone Comparator
    public class RedstoneComparator: NerdBoxObject
    {
        public RedstoneComparator()
        {
            MappedMatrixInteger = 4;
            MappedMatrixDefaultLocation = Resource.Drawable.comparator_off;
            IsToggleable = true;

            ToggleableValues[0, 0] = 0.25;
            ToggleableValues[0, 1] = MappedMatrixDefaultLocation;

            ToggleableValues[1, 0] = 0.5;
            ToggleableValues[1, 1] = Resource.Drawable.comparator_on;

        }
    }

    //Quartz Block
    public class QuartzBlock: NerdBoxObject
    {
        public QuartzBlock()
        {
            MappedMatrixInteger = 5;
            MappedMatrixDefaultLocation = Resource.Drawable.quartz_block_side;
            IsToggleable = false;
        }
    }

    //Piston Block
    public class Piston : NerdBoxObject
    {
        public Piston()
        {
            MappedMatrixInteger = 6;
            MappedMatrixDefaultLocation = Resource.Drawable.piston_top_normal;
            IsToggleable = true;


            //Normal
            ToggleableValues[0, 0] = 0.25;
            ToggleableValues[0, 1] = MappedMatrixDefaultLocation;


            //Sticky
            ToggleableValues[1, 0] = 0.5;
            ToggleableValues[1, 1] = Resource.Drawable.piston_top_sticky;
        }
    }
    #endregion
}
