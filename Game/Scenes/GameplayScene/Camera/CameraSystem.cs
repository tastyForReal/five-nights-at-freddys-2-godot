// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using FiveNightsAtFreddys.Game.Scenes.GameplayScene.UserInterface;
using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.Camera
{
    public partial class CameraSystem : CanvasLayer
    {
        [Export]
        private CanvasLayer cameraButtons = null!;

        [Export]
        private CanvasLayer cameraScreenLayer = null!;

        [Export]
        private FlipButtonControl flipButtonControl = null!;

        public override void _Process(double delta)
        {
            Visible = flipButtonControl.FlipStage == FlipStage.Flipped;

            cameraScreenLayer.Visible = Visible;
            cameraButtons.Visible = Visible;
        }
    }
}
