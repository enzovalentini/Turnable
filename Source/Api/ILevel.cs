﻿using Entropy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Turnable.Components;
using Turnable.Locations;

namespace Turnable.Api
{
    public interface ILevel
    {
        // ----------------
        // Public interface
        // ----------------

        // Methods
        bool IsCollidable(Position position);

        // Properties
        IMap Map { get; set; }
        IPathfinder Pathfinder { get; set; }
        ICharacterManager CharacterManager { get; set; }
        Level.SpecialLayersCollection SpecialLayers { get; set; }
        IModelManager ModelManager { get; set; }
        IViewport Viewport { get; set; }
        IVisionCalculator VisionCalculator { get; set; }

        // -----------------
        // Private interface
        // -----------------

        // Methods
        void InitializeSpecialLayers();
        void SetUpViewport();
        void SetUpViewport(int width, int height);
        void SetUpViewport(Position mapOrigin, int width, int height);
        void SetUpVisionCalculator();
        void SetUpCharacterManager();
        void SetUpModelManager();
        void SetLayer(string name, int width, int height, SpecialLayer specialLayer);
    }
}
