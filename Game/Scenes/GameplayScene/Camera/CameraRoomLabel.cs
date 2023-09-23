// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.Camera
{
    public partial class CameraRoomLabel : Label
    {
        [Export]
        private CameraButtons cameraButtons = null!;

        private int selectedCamera;

        public static string[] CameraNames => new[]
        {
            "Party Room 1",
            "Party Room 2",
            "Party Room 3",
            "Party Room 4",
            "Left Air Vent",
            "Right Air Vent",
            "Main Hall",
            "Parts Service",
            "Show Stage",
            "Game Area",
            "Prize Corner",
            "Kid's Cove"
        };

        public override void _Process(double delta)
        {
            selectedCamera = cameraButtons.Selected;
            Text = CameraNames[selectedCamera];
        }
    }
}
