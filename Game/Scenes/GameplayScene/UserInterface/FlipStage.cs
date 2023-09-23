// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

namespace FiveNightsAtFreddys.Game.Scenes.GameplayScene.UserInterface
{
    /// <summary>
    /// Enumeration representing different stages of flipping.
    /// </summary>
    public enum FlipStage
    {
        /// <summary>
        /// The camera panel or mask is currently in the process of flipping.
        /// </summary>
        Flipping,

        /// <summary>
        /// The camera panel or mask has been fully flipped.
        /// </summary>
        Flipped,

        /// <summary>
        /// The camera panel or mask is currently in the process of unflipping.
        /// </summary>
        Unflipping,

        /// <summary>
        /// The camera panel or mask has been fully unflipped.
        /// </summary>
        Unflipped
    }
}
