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
            return makeCube(y, y, 0, 1);
        }

        private ModelVisual3D makeCube(double x, double y, double z, double s)
        {
            MeshGeometry3D triangleMesh = new MeshGeometry3D();

            triangleMesh.Positions.Add(new Point3D(x-s, y-s, z-s));
            triangleMesh.Positions.Add(new Point3D(x-s, y-s, z+s));
            triangleMesh.Positions.Add(new Point3D(x-s, y+s, z-s));
            triangleMesh.Positions.Add(new Point3D(x-s, y+s, z+s));
            triangleMesh.Positions.Add(new Point3D(x+s, y-s, z-s));
            triangleMesh.Positions.Add(new Point3D(x+s, y-s, z+s));
            triangleMesh.Positions.Add(new Point3D(x+s, y+s, z-s));
            triangleMesh.Positions.Add(new Point3D(x+s, y+s, z+s));
            
            triangleMesh.TriangleIndices.Add(0);
            triangleMesh.TriangleIndices.Add(3);
            triangleMesh.TriangleIndices.Add(1);
            triangleMesh.TriangleIndices.Add(0);
            triangleMesh.TriangleIndices.Add(2);
            triangleMesh.TriangleIndices.Add(3);

            triangleMesh.TriangleIndices.Add(3);
            triangleMesh.TriangleIndices.Add(7);
            triangleMesh.TriangleIndices.Add(2);
            triangleMesh.TriangleIndices.Add(7);
            triangleMesh.TriangleIndices.Add(6);
            triangleMesh.TriangleIndices.Add(2);

            triangleMesh.TriangleIndices.Add(1);
            triangleMesh.TriangleIndices.Add(7);
            triangleMesh.TriangleIndices.Add(3);
            triangleMesh.TriangleIndices.Add(1);
            triangleMesh.TriangleIndices.Add(5);
            triangleMesh.TriangleIndices.Add(7);

            triangleMesh.TriangleIndices.Add(4);
            triangleMesh.TriangleIndices.Add(7);
            triangleMesh.TriangleIndices.Add(5);
            triangleMesh.TriangleIndices.Add(4);
            triangleMesh.TriangleIndices.Add(6);
            triangleMesh.TriangleIndices.Add(7);

            triangleMesh.TriangleIndices.Add(1);
            triangleMesh.TriangleIndices.Add(5);
            triangleMesh.TriangleIndices.Add(0);
            triangleMesh.TriangleIndices.Add(5);
            triangleMesh.TriangleIndices.Add(4);
            triangleMesh.TriangleIndices.Add(0);

            triangleMesh.TriangleIndices.Add(0);
            triangleMesh.TriangleIndices.Add(6);
            triangleMesh.TriangleIndices.Add(2);
            triangleMesh.TriangleIndices.Add(0);
            triangleMesh.TriangleIndices.Add(4);
            triangleMesh.TriangleIndices.Add(6);

            Vector3D normal = new Vector3D(0, 1, 0);
            triangleMesh.Normals.Add(normal);
            triangleMesh.Normals.Add(normal);
            triangleMesh.Normals.Add(normal);

            Material material = new DiffuseMaterial(new SolidColorBrush(Colors.Red));

            return new ModelVisual3D { Content = new GeometryModel3D(triangleMesh, material) };
        }

        private void DockPanel_KeyDown(object sender, KeyEventArgs e)
        {
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

        private Point lastPos;
        private bool rotating;

        private void mainViewport_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lastPos = Mouse.GetPosition(mainViewport);
            rotating = true;

            HitTestResult res = VisualTreeHelper.HitTest(mainViewport, lastPos);

            if (res != null && res.VisualHit != null)
            {
                ((GeometryModel3D)((ModelVisual3D)res.VisualHit).Content).Material = new DiffuseMaterial(new SolidColorBrush(Colors.Green));
            }
        }

        private void mainViewport_MouseMove(object sender, MouseEventArgs e)
        {
            rotating = rotating && e.LeftButton == MouseButtonState.Pressed;

            if (rotating)
            {
                Point pos = Mouse.GetPosition(mainViewport);
                cam.LookDirection = rotate(cam.LookDirection, cam.UpDirection, 0.2 * (pos.X - lastPos.X));
            }

            lastPos = Mouse.GetPosition(mainViewport);
        }

    }
}
