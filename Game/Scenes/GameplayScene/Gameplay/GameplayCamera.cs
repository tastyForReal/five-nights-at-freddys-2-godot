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

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.Gameplay
{
    public partial class GameplayCamera : Camera2D
    {
        private const float max_scroll_speed = 7;
        private const float buffer_zone = 128;
        private const float max_position_x = 584;
        private const float left_rect_right_edge_x = 384;
        private const float right_rect_left_edge_x = 640;

        [Export]
        private FlipButtonControl flipPanelButtonControl = null!;

        public override void _Process(double delta)
        {
            if (flipPanelButtonControl.FlipStage != FlipStage.Unflipped)
            {
                return;
            }

            var mousePosition = GetViewport().GetMousePosition();

            float scrollSpeed = 0;

            if (mousePosition.X <= left_rect_right_edge_x)
            {
                float distance = left_rect_right_edge_x - mousePosition.X;
                float percentage = Math.Clamp(distance / buffer_zone, 0, 1);
                scrollSpeed = Mathf.Lerp(0, -max_scroll_speed, percentage);
            }
            else if (mousePosition.X >= right_rect_left_edge_x)
            {
                float distance = mousePosition.X - right_rect_left_edge_x;
                float percentage = Math.Clamp(distance / (left_rect_right_edge_x - buffer_zone), 0, 1);
                scrollSpeed = Mathf.Lerp(0, max_scroll_speed, percentage);
            }

            var newPosition = Position;
            newPosition.X += scrollSpeed;
            newPosition.X = Mathf.Clamp(newPosition.X, 0, max_position_x);
            Position = newPosition;
        }
    }
}
