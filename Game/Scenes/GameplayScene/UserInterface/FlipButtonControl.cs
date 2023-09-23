// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.UserInterface
{
    /// <summary>
    /// Control class representing a button for flipping a camera panel or mask.
    /// </summary>
    public partial class FlipButtonControl : Control
    {
        private bool mouseEntered;

        [Export]
        private AnimatedSprite2D flipAnimation = null!;

        [Export]
        private AudioStreamPlayer flippingAudio = null!;

        [Export]
        private AudioStreamPlayer unflippingAudio = null!;

        /// <summary>
        /// Gets the current flip stage.
        /// </summary>
        public FlipStage FlipStage { get; private set; } = FlipStage.Unflipped;

        public override void _Ready()
        {
            flipAnimation.AnimationFinished += () =>
            {
                if (FlipStage == FlipStage.Flipping)
                {
                    FlipStage = FlipStage.Flipped;
                }
                else if (FlipStage == FlipStage.Unflipping)
                {
                    FlipStage = FlipStage.Unflipped;
                }

                flipAnimation.Hide();
            };

            MouseEntered += () =>
            {
                if (mouseEntered || !Visible)
                {
                    return;
                }

                // Prevent the mouse from entering the control area from the bottom
                // so it doesn't get too annoying when flipping too much.
                mouseEntered = true;

                if (FlipStage == FlipStage.Unflipped && !flipAnimation.IsPlaying())
                {
                    FlipStage = FlipStage.Flipping;
                    flipAnimation.Show();
                    flipAnimation.Play();
                    flippingAudio.Play();
                }
                else if (FlipStage == FlipStage.Flipped && !flipAnimation.IsPlaying())
                {
                    FlipStage = FlipStage.Unflipping;
                    flipAnimation.Show();
                    flipAnimation.PlayBackwards();
                    unflippingAudio.Play();
                }
            };
        }

        public override void _Process(double delta)
        {
            float y = GetViewport().GetMousePosition().Y;

            if (y < 680 && mouseEntered)
            {
                mouseEntered = false;
            }
        }
    }
}
