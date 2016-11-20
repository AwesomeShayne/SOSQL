﻿using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace SOSQL
{
    public abstract class Drawable3D
    {
        private int Height;
        private int Width;
        private int Depth;

        private int X;
        private int Y;
        private int Z;

        private int Transparency;

        public GeometryModel3D GetModel()
        {
            GeometryModel3D model = new GeometryModel3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            mesh.Positions.Add(new Point3D(0, 0, 0));
            mesh.Positions.Add(new Point3D(0, 1, 0));
            mesh.Positions.Add(new Point3D(0, 1, 1));
            mesh.Positions.Add(new Point3D(0, 0, 1));
            mesh.Positions.Add(new Point3D(1, 1, 0));
            mesh.Positions.Add(new Point3D(1, 1, 1));
            mesh.Positions.Add(new Point3D(1, 0, 0));
            mesh.Positions.Add(new Point3D(1, 0, 1));
            //Triangle 1
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(1);
            //Triangle 2
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(2);
            //Triangle 3  
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            //Triangle 4
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(5);
            //Triangle 5
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(0);
            //Triangle 6
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(3);
            //Triangle 7
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(2);
            //Triangle 8
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(5);
            //Triangle 9 - Back 
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(5);
            //Trangle 10 - Back  
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(7);
            model.Geometry = mesh;

            Random Rand = new Random();

            var _R = Rand.Next(0, 256);
            var _G = Rand.Next(0, 256);
            var _B = Rand.Next(0, 256);
            Color _FillColor = Color.FromArgb((byte)Transparency, (byte)_R, (byte)_G, (byte)_B);
            model.Material = new DiffuseMaterial(new SolidColorBrush(_FillColor));
            model.BackMaterial = new DiffuseMaterial(new SolidColorBrush(_FillColor));

            Transform3DGroup both = new Transform3DGroup();
            both.Children.Add(new ScaleTransform3D(Width, Height, Depth));
            both.Children.Add(new TranslateTransform3D(X, Y, Z));
            model.Transform = both;
            return model;
        }
    }
}