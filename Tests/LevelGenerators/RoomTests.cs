﻿using System;
using NUnit.Framework;
using Turnable.Components;
using Turnable.LevelGenerators;
using System.Collections.Generic;
using Turnable.Utilities;
using Turnable.Api;

namespace Tests.LevelGenerators
{
    [TestFixture]
    public class RoomTests
    {
        [Test]
        public void Room_ImplementsTheIBoundedInterface()
        {
            Rectangle chunkBounds = new Rectangle(new Position(0, 0), 7, 5);
            Chunk chunk = new Chunk(chunkBounds);
            Rectangle roomBounds = new Rectangle(new Position(1, 1), new Position(2, 2));
            Room room = new Room(chunk, roomBounds);

            Assert.That(room, Is.InstanceOf<IBounded>());
        }

        [Test]
        public void Constructor_InitializesAllProperties()
        {
            Rectangle chunkBounds = new Rectangle(new Position(0, 0), 7, 5);
            Chunk chunk = new Chunk(chunkBounds);
            Rectangle roomBounds = new Rectangle(new Position(1, 1), new Position(2, 2));
            Room room = new Room(chunk, roomBounds);

            Assert.That(room.ParentChunk, Is.SameAs(chunk));
            Assert.That(room.Bounds, Is.SameAs(roomBounds));
            Assert.That(chunk.Room, Is.SameAs(room));
            Assert.That(room.Corridors, Is.Not.Null);
        }

        [Test]
        public void ToString_DisplaysBottomLeftAndTopLeftCorners()
        {
            Chunk parentChunk = new Chunk(new Rectangle(new Position(0, 0), new Position(100, 100)));
            Room room = new Room(parentChunk, new Rectangle(new Position(0, 0), new Position(10, 10)));

            Assert.That(room.ToString(), Is.EqualTo("BottomLeft: (0, 0); TopRight: (10, 10)"));
        }

        // TODO: Test that if any corners are out of the chunk, the construction is invalid (use the bounds checking feature of parent chunk)
    }
}
