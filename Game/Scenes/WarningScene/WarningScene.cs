// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.WarningScene
{
    public partial class WarningScene : Node
    {
        [Export]
        private PackedScene menuScene = null!;

        [Export]
        private AnimationPlayer player = null!;

        public override void _Ready()
        {
            player.AnimationFinished += handleAnimationFinished;
        }

        private void handleAnimationFinished(StringName animName)
        {
            GetTree().ChangeSceneToPacked(menuScene);
        }

        public override void _Process(double delta)
        {
            if (Input.IsActionPressed("left_click") &&
                player.CurrentAnimationPosition is >= 1 and < 6)
            {
                player.Seek(6);
            }
        }
    }
}
