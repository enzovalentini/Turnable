﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Tuples;

namespace Turnable.Tiled
{
    public class TileList : Dictionary<Tuple<int, int>, Tile>
    {
        // Layers in a Map tend to be sparse arrays (other than the background layer). A dictionary is a better data store than a 2-dimensional array.

        public TileList()
        {
        }

        public TileList(int width, int height, Data data)
        {
            uint tileGlobalId = 0;

            using (BinaryReader reader = new BinaryReader(data.Contents))
            {
                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        tileGlobalId = reader.ReadUInt32();

                        // The .tmx format uses 0 to indicate a tile that hasn't been set in the editor
                        if (tileGlobalId != 0)
                        {
                            Add(new Tuple<int, int>(col, row), new Tile(tileGlobalId, col, row));
                        }
                    }
                }
            }
        }
    }
}