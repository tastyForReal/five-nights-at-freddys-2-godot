// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using System;
using FiveNightsAtFreddys.Game.Scenes.GameplayScene.UserInterface;
using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.Gameplay
{
    public partial class Mask : TextureRect
    {
        private const float deep_breaths_sound_volume_db = -13.8629436111989f;

        private const double frequency = 1.5;
        private const double amplitude = 10;

        private double elapsed;

        private Vector2 initialPosition;

        [Export]
        private AudioStreamPlayer deepBreathsSound = null!;

        [Export]
        private FlipButtonControl flipButtonControl = null!;

        public override void _Ready()
        {
            initialPosition = Position;
        }

        public override void _Process(double delta)
        {
            Visible = flipButtonControl.FlipStage == FlipStage.Flipped;
            deepBreathsSound.VolumeDb = Visible ? deep_breaths_sound_volume_db : float.MinValue;

            elapsed += delta;

            double xOffset = amplitude * 2 * Math.Cos(frequency * elapsed);
            double yOffset = amplitude * Math.Sin(frequency * elapsed * 2);

            Position = initialPosition + new Vector2((float)xOffset, (float)yOffset);
        }
    }
}
