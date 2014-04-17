﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnItUp.Tmx;
using System.Tuples;
using TurnItUp.Characters;
using TurnItUp.Components;
using TurnItUp.Interfaces;
using Entropy;
using TurnItUp.Pathfinding;
using TurnItUp.Randomization;

namespace TurnItUp.Locations
{
    public class LevelFactory : ILevelFactory
    {
        public ILevelRandomizer LevelRandomizer { get; set; }

        public LevelFactory()
        {
            LevelRandomizer = new LevelRandomizer();
        }

        public void Initialize(ILevel level, LevelInitializationParams initializationParams)
        {
            if (initializationParams.TmxPath != null)
            {
                level.SetUpMap(initializationParams.TmxPath);
                level.SetUpCharacters();
            }

            level.SetUpPathfinder(initializationParams.AllowDiagonalMovement);
        }

        public void Randomize(ILevel level, LevelRandomizationParams randomizationParams)
        {
            if (randomizationParams.LayerName == null || randomizationParams.TileCount == null)
            {
                throw new ArgumentException("<LevelFactory::Randomize> : the randomizationParams have not been initialized with any values.");
            }

            if (randomizationParams.TileMaximum == null)
            {
                LevelRandomizer.Randomize(level, randomizationParams.LayerName, randomizationParams.TileCount.Value);
            }
            else
            {
                LevelRandomizer.Randomize(level, randomizationParams.LayerName, randomizationParams.TileCount.Value, randomizationParams.TileMaximum.Value + 1);
            }

            level.SetUpCharacters();
        }

        public Level BuildLevel(World world)
        {
            return new Level(world);
        }


        public Level BuildLevel(LevelInitializationParams initializationParams, LevelRandomizationParams randomizationParams)
        {
            throw new NotImplementedException();
        }
    }
}