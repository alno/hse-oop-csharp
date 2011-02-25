using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;

namespace Wpf3d1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Random random = new Random();

        public Window1()
        {
            InitializeComponent();
        }

        private void addTriangle_Click(object sender, RoutedEventArgs e)
        {           
            this.mainViewport.Children.Add(makeFlatTriangle(random.NextDouble() * 20 - 15));
        }

        private ModelVisual3D makeFlatTriangle(double y)
        {
            return makeTriangle(0, y, 0, 5, y, 0, 0, y, 5);
        }

        private ModelVisual3D makeTriangle(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            MeshGeometry3D triangleMesh = new MeshGeometry3D();

            Point3D point0 = new Point3D(x1, y1, z1);
            Point3D point1 = new Point3D(x2, y2, z2);
            Point3D point2 = new Point3D(x3, y3, z3);

            triangleMesh.Positions.Add(point0);
            triangleMesh.Positions.Add(point1);
            triangleMesh.Positions.Add(point2);

            triangleMesh.TriangleIndices.Add(0); // Важно - порядок обхода
            triangleMesh.TriangleIndices.Add(2);
            triangleMesh.TriangleIndices.Add(1);

            Vector3D normal = new Vector3D(0, 1, 0);
            triangleMesh.Normals.Add(normal);
            triangleMesh.Normals.Add(normal);
            triangleMesh.Normals.Add(normal);

            Material material = new DiffuseMaterial(new SolidColorBrush(Colors.Red));

            return new ModelVisual3D { Content = new GeometryModel3D(triangleMesh, material) };
        }

        private void DockPanel_KeyDown(object sender, KeyEventArgs e)
        {
            PerspectiveCamera cam = ((PerspectiveCamera)mainViewport.Camera);

            if (e.Key == Key.A)
                cam.LookDirection = rotate(cam.LookDirection,cam.UpDirection,10);
            if (e.Key == Key.D)
                cam.LookDirection = rotate(cam.LookDirection,cam.UpDirection,-10);
            if (e.Key == Key.W)
                cam.Position = cam.Position + cam.LookDirection;
            if (e.Key == Key.S)
                cam.Position = cam.Position - cam.LookDirection;
        }

        private Vector3D rotate(Vector3D vec, Vector3D axis, double angle)
        {
            return new RotateTransform3D(new AxisAngleRotation3D(axis, angle)).Transform(vec);
        }
    }
}
