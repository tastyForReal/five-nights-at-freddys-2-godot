// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using System;
using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.NightProgress
{
    public partial class NightProgressLayer : CanvasLayer
    {
        private const double hour_change_time = 70;
        private double hourChangeInterval = hour_change_time;
        private double elapsed;

        private IGlobalVariables globalVariables = null!;

        [Export]
        private Label nightHour = null!;

        [Export]
        private Label nightLevel = null!;

        [Export]
        private Label currentTime = null!;

        private DateTime time = DateTime.Today;

        public int Hour => time.Hour;

        public override void _Ready()
        {
            globalVariables = GetNode<IGlobalVariables>("/root/GlobalVariables");
        }

        public override void _Process(double delta)
        {
            elapsed += delta;

            nightLevel.Text = $"Night {globalVariables.Night}";
            nightHour.Text = $"{time:h tt}";

            var timeSpan = TimeSpan.FromSeconds(elapsed);
            currentTime.Text = $@"{timeSpan:mm\:ss\.fff}";

            if (elapsed >= hourChangeInterval)
            {
                hourChangeInterval += hour_change_time;
                time = time.AddHours(1);
            }
        }
    }
}
