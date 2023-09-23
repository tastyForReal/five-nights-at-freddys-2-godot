// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using FiveNightsAtFreddys.Game.Scenes.GameplayScene.NightProgress;
using FiveNightsAtFreddys.Game.Scenes.GameplayScene.UserInterface;
using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.Gameplay
{
    public partial class GameplayScene : Node2D
    {
        [Export]
        private FlipButtonControl flipMaskButtonControl = null!;

        [Export]
        private FlipButtonControl flipPanelButtonControl = null!;

        [Export]
        private CanvasItem flipPanelButton = null!;

        [Export]
        private CanvasItem flipMaskButton = null!;

        [Export]
        private NightProgressLayer nightProgress = null!;

        public override void _Process(double delta)
        {
            bool resetButtons = GetViewport().GetMousePosition().Y < 680;

            if (resetButtons &&
                flipPanelButtonControl.FlipStage == FlipStage.Unflipped &&
                flipMaskButtonControl.FlipStage == FlipStage.Unflipped)
            {
                flipPanelButton.Show();
                flipMaskButton.Show();
            }

            if (resetButtons &&
                flipPanelButtonControl.FlipStage == FlipStage.Flipped &&
                flipMaskButtonControl.FlipStage == FlipStage.Unflipped)
            {
                flipPanelButton.Show();
            }

            if (resetButtons &&
                flipPanelButtonControl.FlipStage == FlipStage.Unflipped &&
                flipMaskButtonControl.FlipStage == FlipStage.Flipped)
            {
                flipMaskButton.Show();
            }

            if (flipPanelButtonControl.FlipStage == FlipStage.Flipping ||
                flipMaskButtonControl.FlipStage == FlipStage.Flipping)
            {
                flipPanelButton.Hide();
                flipMaskButton.Hide();
            }

            if (flipPanelButtonControl.FlipStage == FlipStage.Unflipping ||
                flipMaskButtonControl.FlipStage == FlipStage.Unflipping)
            {
                flipPanelButton.Hide();
                flipMaskButton.Hide();
            }

            if (nightProgress.Hour == 6)
            {
                // Do nothing for now. Will add a scene for this in the future.
            }
        }
    }
}
