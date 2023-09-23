// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

namespace FiveNightsAtFreddys.Game
{
    public class SaveInfo
    {
        public int Level { get; set; } = 1;
        public bool? NightFiveCompleted { get; set; }
        public bool? NightSixCompleted { get; set; }
        public bool[]? CompletedChallenges { get; set; }
    }
}
