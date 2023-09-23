// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using System.Collections.Generic;
using System.Linq;
using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.Camera
{
    public partial class CameraButtons : CanvasLayer
    {
        private readonly List<AnimatedSprite2D> buttons = new List<AnimatedSprite2D>();

        [Export]
        private AudioStreamPlayer blipSound = null!;

        public int Selected { get; private set; } = 8;

        public override void _Ready()
        {
            buttons.AddRange(GetChildren().Cast<AnimatedSprite2D>());

            for (int i = 0; i < buttons.Count; i++)
            {
                int buttonIndex = i;
                buttons[i].GetChild<Control>(0).GuiInput += e =>
                {
                    if (e.IsActionPressed("left_click") && Selected != buttonIndex)
                    {
                        Selected = buttonIndex;
                        blipSound.Play();
                    }
                };
            }
        }

        public override void _Process(double delta)
        {
            foreach (var button in buttons)
            {
                if (button.Frame == 1)
                {
                    button.Frame = 0;
                    break;
                }
            }

            buttons[Selected].Frame = 1;
        }
    }
}
