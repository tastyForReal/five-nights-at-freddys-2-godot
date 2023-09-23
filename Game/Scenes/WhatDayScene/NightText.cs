// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.WhatDayScene
{
    public partial class NightText : Label
    {
        private readonly string[] levels = { "1st", "2nd", "3rd", "4th", "5th", "6th", "7th" };

        private IGlobalVariables globalVariables = null!;

        public override void _Ready()
        {
            globalVariables = GetNode<IGlobalVariables>("/root/GlobalVariables");
            Text = $"12:00 AM\n\n{levels[globalVariables.Night - 1]} Night";
        }
    }
}
