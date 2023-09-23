// Five Nights at Freddy's 2: Godot Open Source
// Made by tastyForReal (2023)
// Licensed under the MIT license.
// See the LICENSE file in the repository root for full license text.
//
// Five Nights at Freddy's 2
// Copyright (c) 2014-2023 Scott Cawthon

using System.Text.Json;
using Godot;

namespace FiveNightsAtFreddys.Game.Scenes.MenuScene
{
    public partial class MenuScene : Node2D
    {
        private const string what_day_scene_path = "res://Game/Scenes/WhatDayScene.tscn";

        private double elapsed;

        private int level;

        private Option option;
        private bool updatedOnce;

        private IGlobalVariables globalVariables = null!;

        [Export]
        private AudioStreamPlayer blipSound = null!;

        [Export]
        private Control continueButton = null!;

        [Export]
        private Label continueSelector = null!;

        [Export]
        private Control newGameButton = null!;

        [Export]
        private Label newGameSelector = null!;

        [Export]
        private Label nightText = null!;

        private FileAccess? json;
        private SaveInfo? saveInfo;

        public override void _Ready()
        {
            globalVariables = GetNode<IGlobalVariables>("/root/GlobalVariables");

            newGameSelector = newGameButton.GetNode<Label>("../Selector");
            continueSelector = continueButton.GetNode<Label>("../Selector");

            newGameButton.MouseEntered += () =>
            {
                if (option == Option.NewGame)
                {
                    return;
                }

                option = Option.NewGame;
                newGameSelector.Show();
                continueSelector.Hide();
                nightText.Hide();
                globalVariables.Night = 1;
                blipSound.Play();
            };

            newGameButton.GuiInput += handleButtonClicked;

            continueButton.MouseEntered += () =>
            {
                if (option == Option.Continue)
                {
                    return;
                }

                option = Option.Continue;
                newGameSelector.Hide();
                continueSelector.Show();
                nightText.Show();
                globalVariables.Night = level;
                blipSound.Play();
            };

            continueButton.GuiInput += handleButtonClicked;
        }

        private void handleButtonClicked(InputEvent e)
        {
            if (e.IsAction("left_click"))
            {
                var whatDayScene = ResourceLoader.Load<PackedScene>(what_day_scene_path);
                GetTree().ChangeSceneToPacked(whatDayScene);
            }
        }

        public override void _Process(double delta)
        {
            update();

            if (saveInfo != null)
            {
                level = saveInfo.Level;
            }

            nightText.Text = $"Night {level}";

            if (updatedOnce)
            {
                return;
            }

            if (level > 1)
            {
                option = Option.Continue;
                newGameSelector.Hide();
                continueSelector.Show();
                nightText.Show();
                globalVariables.Night = level;
            }
            else
            {
                option = Option.NewGame;
                newGameSelector.Show();
                continueSelector.Hide();
                nightText.Hide();
            }

            updatedOnce = true;
        }

        private void update()
        {
            using (var updatedJson = FileAccess.Open("user://save.json", FileAccess.ModeFlags.Read))
            {
                if (updatedJson != null)
                {
                    var updatedSaveInfo = JsonSerializer.Deserialize<SaveInfo>(updatedJson.GetAsText());
                    updatedJson.Close();

                    if (updatedSaveInfo != null)
                    {
                        if (json == null || !json.GetAsText().Equals(updatedJson.GetAsText()))
                        {
                            saveInfo = updatedSaveInfo;
                        }

                        json = updatedJson;
                    }
                }
                else
                {
                    saveInfo = new SaveInfo();
                }
            }
        }

        public override void _ExitTree()
        {
            json?.Dispose();
        }

        private enum Option
        {
            NewGame,
            Continue
        }
    }
}
