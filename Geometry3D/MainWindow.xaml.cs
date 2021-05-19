using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Geometry3D
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public class Sphere
		{
			private readonly struct PointKey
			{
				public int Parallel { get; }

				public int Meridian { get; }

				public PointKey(int parallel, int meridian)
				{
					Parallel = parallel;
					Meridian = meridian;
				}
			}

			public double Radius { get; }

			public int Parallels { get; }

			public int Meridians { get; }

			public List<Point3D> Points { get; private set; }

			public List<int> Indices { get; private set; }

			public List<Vector3D> Normals { get; private set; }

			public Sphere(double radius, int parallels, int meridians)
			{
				Radius = radius;
				Parallels = parallels;
				Meridians = meridians;
			}

			private readonly Dictionary<PointKey, int> _hash = new Dictionary<PointKey, int>();

			private int InitPoint(int parallelIndex, int meridianIndex)
			{
				meridianIndex = parallelIndex == 0 || parallelIndex == Parallels ? 0 : meridianIndex % Meridians;

				var key = new PointKey(parallelIndex, meridianIndex);

				if (!_hash.TryGetValue(key, out var index))
				{
					var pStep = Math.PI / Parallels;
					var mStep = 2 * Math.PI / Meridians;
					var pStart = -Math.PI / 2D;
					var mStart = -parallelIndex * mStep / 2D;
					var pAngle = pStart + pStep * parallelIndex;
					var mAngle = mStart + mStep * meridianIndex;

					var x = Radius * Math.Cos(pAngle) * Math.Sin(mAngle);
					var y = Radius * Math.Cos(pAngle) * Math.Cos(mAngle);
					var z = Radius * Math.Sin(pAngle);
					var point = new Point3D(x, y, z);
					index = Points.Count;
					Points.Add(point);
					_hash[key] = index;
				}

				return index;
			}

			public void Render()
			{
				Points = new List<Point3D>();
				Indices = new List<int>();
				Normals = new List<Vector3D>();

				for (var p = 0; p < Parallels; p++)
				{
					for (var m = 0; m < Meridians; m++)
					{
						var index1 = InitPoint(p, m);
						var index2 = InitPoint(p, m + 1);
						var index3 = InitPoint(p + 1, m + 1);
						var index4 = InitPoint(p + 1, m);

						
						Indices.Add(index1);
						Indices.Add(index2);
						Indices.Add(index3);

						var centroid1 = GetCentroid(Points[index1], Points[index2], Points[index3]);
						//Normals.Add(centroid1 - default(Point3D));
						Normals.Add(Vector3D.CrossProduct(Points[index1] - Points[index2], Points[index1] - Points[index3]));

						Indices.Add(index1);
						Indices.Add(index3);
						Indices.Add(index4);
						var centroid2 = GetCentroid(Points[index1], Points[index3], Points[index4]);
						//Normals.Add(centroid2 - default(Point3D));
						Normals.Add(Vector3D.CrossProduct(Points[index1] - Points[index3], Points[index4] - Points[index3]));

					}
				}
			}
		}

		private static Point3D GetCentroid(Point3D p1, Point3D p2, Point3D p3) => new Point3D(
			(p1.X + p2.X + p3.X) / 3D,
			(p1.Y + p2.Y + p3.Y) / 3D,
			(p1.Z + p2.Z + p3.Z) / 3D);

		public MainWindow()
		{
			InitializeComponent();

			var sphere = new Sphere(1, 100,100);
			sphere.Render();

			Sphere3D.Positions = new Point3DCollection(sphere.Points);
			Sphere3D.TriangleIndices = new Int32Collection(sphere.Indices);
			//Sphere3D.Normals = new Vector3DCollection(sphere.Normals);
		}
	}
}
