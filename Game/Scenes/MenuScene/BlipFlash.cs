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
    public partial class BlipFlash : AnimatedSprite2D
    {
        private const double alpha_change_time = 0.1;
        private const double visibility_time = 0.3;

        private readonly Random random;

        private double alphaChangeInterval;
        private double visibilityInterval;
        private double elapsed;

        public BlipFlash()
        {
            elapsed = 0;
            alphaChangeInterval = alpha_change_time;
            visibilityInterval = visibility_time;
            random = new Random();
        }

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
                    A8 = byte.MaxValue - (random.Next(50) + 200)
                };
            }

            if (elapsed >= visibilityInterval)
            {
                visibilityInterval += visibility_time;
                Visible = random.Next(3) == 1;
            }
        }
    }
}
