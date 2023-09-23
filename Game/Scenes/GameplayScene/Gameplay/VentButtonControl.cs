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
    public partial class VentButtonControl : Control
    {
        private bool state;

        [Export]
        private FlipButtonControl flipMaskButtonControl = null!;

        [Export]
        private FlipButtonControl flipPanelButtonControl = null!;

        [Export]
        private AnimatedSprite2D ventLightButton = null!;

        public bool IsLightSwitchOn() => state;

        public override void _Ready()
        {
            GuiInput += e =>
            {
                if (flipPanelButtonControl.FlipStage == FlipStage.Unflipped &&
                    flipMaskButtonControl.FlipStage == FlipStage.Unflipped)
                {
                    if (e.IsActionPressed("left_click"))
                    {
                        state = true;
                    }
                    else if (e.IsActionReleased("left_click"))
                    {
                        state = false;
                    }
                }
            };

            MouseExited += () => state = false;
        }

        public override void _Process(double delta)
        {
            ventLightButton.Animation = state ? "On" : "Off";
        }
    }
}
