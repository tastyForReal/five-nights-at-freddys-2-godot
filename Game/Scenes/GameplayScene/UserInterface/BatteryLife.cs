// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.UserInterface
{
    public partial class BatteryLife : AnimatedSprite2D
    {
        private const double flashing_time = 0.2;
        private double elapsed;

        private IGlobalVariables globalVariables = null!;

        [Export]
        private Label counter = null!;

        private float maxPower;
        public float Power { get; set; }

        public override void _Ready()
        {
            globalVariables = GetNode<IGlobalVariables>("/root/GlobalVariables");

            maxPower = Mathf.Max(8000 - (globalVariables.Night * 1000), 3000);

            Power = maxPower;
        }

        public override void _Process(double delta)
        {
            elapsed += delta;

            if (Power <= 0)
            {
                Hide();
                return;
            }

            counter.Text = $"{Power}";

            if (Frame == 0 && elapsed >= flashing_time)
            {
                elapsed = 0;
                Visible = !Visible;
            }

            float progress = Mathf.Clamp(Power, 0, maxPower);
            float normalized = Mathf.InverseLerp(0, maxPower, progress);
            int frame = Mathf.RoundToInt(Mathf.Lerp(0, SpriteFrames.GetFrameCount("default"), normalized));
            Frame = frame;
        }
    }
}
