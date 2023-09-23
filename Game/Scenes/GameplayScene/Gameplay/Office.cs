// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using FiveNightsAtFreddys.Game.Scenes.GameplayScene.UserInterface;
using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.Gameplay
{
    public partial class Office : AnimatedSprite2D
    {
        private const float buzz_light_volume_db = -10.2165124753198f;

        [Export]
        private BatteryLife batteryLife = null!;

        [Export]
        private AudioStreamPlayer buzzLightAudio = null!;

        [Export]
        private FlipButtonControl flipMaskButtonControl = null!;

        [Export]
        private VentButtonControl leftVentButtonControl = null!;

        [Export]
        private VentButtonControl rightVentButtonControl = null!;

        public override void _Process(double delta)
        {
            Animation = "LightsOff";

            if (Input.IsActionPressed("control") &&
                !leftVentButtonControl.IsLightSwitchOn() &&
                !rightVentButtonControl.IsLightSwitchOn() &&
                flipMaskButtonControl.FlipStage == FlipStage.Unflipped &&
                batteryLife.Power > 0)
            {
                Animation = "FlashlightOn";
                batteryLife.Power--;
            }

            if (leftVentButtonControl.IsLightSwitchOn())
            {
                Animation = "LeftVentLightOn";
            }

            if (rightVentButtonControl.IsLightSwitchOn())
            {
                Animation = "RightVentLightOn";
            }

            buzzLightAudio.VolumeDb = Animation == "LightsOff" ? float.MinValue : buzz_light_volume_db;
        }
    }
}
