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
    public partial class Static : AnimatedSprite2D
    {
        private const double alpha_change_time = 0.09;

        private readonly Random random;

        private double alphaChangeInterval;
        private double elapsed;

        public Static()
        {
            elapsed = 0;
            alphaChangeInterval = alpha_change_time;
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
                    A8 = byte.MaxValue - (50 + random.Next(100))
                };
            }
        }
    }
}
