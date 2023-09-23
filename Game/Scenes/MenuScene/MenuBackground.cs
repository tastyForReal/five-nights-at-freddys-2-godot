// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using System;
using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.MenuScene
{
    public partial class MenuBackground : AnimatedSprite2D
    {
        private const double alpha_change_time = 0.3;
        private const double frame_change_time = 0.1;

        private readonly Random random = new Random();

        private double alphaChangeInterval = alpha_change_time;
        private double frameChangeInterval = frame_change_time;
        private double elapsed;

        public override void _Process(double delta)
        {
            elapsed += delta;

            if (elapsed >= alphaChangeInterval)
            {
                alphaChangeInterval += alpha_change_time;
                Modulate = new Color
                {
                    R8 = byte.MaxValue,
                    G8 = byte.MaxValue,
                    B8 = byte.MaxValue,
                    A8 = byte.MaxValue - random.Next(250)
                };
            }

            if (elapsed >= frameChangeInterval)
            {
                frameChangeInterval += frame_change_time;
                int randomFrame = random.Next(50);
                Frame = randomFrame < SpriteFrames.GetFrameCount("default") ? randomFrame : 0;
            }
        }
    }
}
