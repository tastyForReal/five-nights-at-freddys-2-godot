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
    public partial class WhatDayScene : Node2D
    {
        [Export]
        private AnimationPlayer animationPlayer = null!;

        private double elapsed;
        private bool fadeOut;
        private float progress;

        public override void _Ready()
        {
            animationPlayer.AnimationFinished += _ =>
            {
                var gameplayScene = GD.Load<PackedScene>("res://Game/Scenes/GameplayScene.tscn");
                GetTree().ChangeSceneToPacked(gameplayScene);
            };
        }

        public override void _Process(double delta)
        {
            elapsed += delta;

            bool isFadeOutReady = !fadeOut && elapsed >= 2;
            if (isFadeOutReady)
            {
                fadeOut = true;
                animationPlayer.Play("FadeOut");
            }
        }
    }
}
