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

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.Camera
{
    public partial class CameraScreen : AnimatedSprite2D
    {
        private string[] animationNames = Array.Empty<string>();

        [Export]
        private CameraRoomLabel cameraRoomLabel = null!;

        [Export]
        private BatteryLife batteryLife = null!;

        private SpriteFrames spriteFrames = null!;

        public string View => Animation;

        public override void _Ready()
        {
            spriteFrames = SpriteFrames;
            animationNames = spriteFrames.GetAnimationNames();
        }

        public override void _Process(double delta)
        {
            Frame = 0;

            string? targetAnimation = findTargetAnimation();

            if (!string.IsNullOrEmpty(targetAnimation))
            {
                Animation = targetAnimation;
            }

            if (Input.IsActionPressed("control") && batteryLife.Power > 0)
            {
                Frame = 1;
            }
        }

        private string? findTargetAnimation()
        {
            string? targetAnimation = null;
            int shortestLength = int.MaxValue;

            foreach (string animationName in animationNames)
            {
                bool isAnimationNameValid = animationName.Contains(cameraRoomLabel.Text) &&
                                            animationName.Length < shortestLength;

                if (isAnimationNameValid)
                {
                    targetAnimation = animationName;
                    shortestLength = animationName.Length;
                }
            }

            return targetAnimation;
        }
    }
}
